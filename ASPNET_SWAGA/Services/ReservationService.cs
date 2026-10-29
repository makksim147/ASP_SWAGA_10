using ASPNET_SWAGA.Common;
using ASPNET_SWAGA.Models;
using ASPNET_SWAGA.Models.CreateDTO;
using ASPNET_SWAGA.Models.DTO;
using ASPNET_SWAGA.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ASPNET_SWAGA.Services;

public class ReservationService : IReservationService
{
    private readonly IReservationRepository _reservations;
    private readonly IProductRepository _products;
    private readonly IUserRepository _users;
    private readonly IMapper _mapper;

    public ReservationService(
        IReservationRepository reservations,
        IProductRepository products,
        IUserRepository users,
        IMapper mapper)
    {
        _reservations = reservations;
        _products = products;
        _users = users;
        _mapper = mapper;
    }

    public async Task<PagedResult<ReservationDTO>> GetPageAsync(int page, int pageSize, CancellationToken ct = default)
    {
        page = Math.Max(page, 1);
        pageSize = Math.Clamp(pageSize, 1, 100);

        var items = await _reservations.GetPageAsync(page, pageSize, ct);
        var total = await _reservations.CountAsync(ct);

        return new PagedResult<ReservationDTO>(_mapper.Map<List<ReservationDTO>>(items), total);
    }

    public async Task<ServiceResult<ReservationDTO>> GetByIdAsync(int id, CancellationToken ct = default)
    {
        var reservation = await _reservations.GetByIdWithDetailsAsync(id, ct);
        if (reservation is null)
            return ServiceResult<ReservationDTO>.NotFound($"Резервация с id {id} не найдена.");

        return ServiceResult<ReservationDTO>.Ok(_mapper.Map<ReservationDTO>(reservation));
    }

    public async Task<ServiceResult<ReservationDTO>> ReserveAsync(ReserveProductDTO dto, CancellationToken ct = default)
    {
        if (dto.CountItems <= 0)
            return ServiceResult<ReservationDTO>.Validation("Количество должно быть больше нуля.");

        if (!await _users.ExistsAsync(dto.IdUser, ct))
            return ServiceResult<ReservationDTO>.Validation("Указанный id пользователя не существует.");

        var product = await _products.GetByIdAsync(dto.IdProducts, ct);
        if (product is null)
            return ServiceResult<ReservationDTO>.Validation("Указанный id товара не существует.");

        if (product.StockCount < dto.CountItems)
            return ServiceResult<ReservationDTO>.Conflict(
                $"Недостаточно товара на складе: доступно {product.StockCount}, запрошено {dto.CountItems}.");

        product.StockCount -= dto.CountItems;

        var reservation = new Reservation
        {
            IdUser = dto.IdUser,
            IdProducts = dto.IdProducts,
            CountItems = dto.CountItems,
            ReservedAt = DateTime.UtcNow
        };
        await _reservations.AddAsync(reservation, ct);

        try
        {
            await _reservations.SaveChangesAsync(ct);
        }
        catch (DbUpdateConcurrencyException)
        {
            return ServiceResult<ReservationDTO>.Conflict("Остаток товара только что изменился. Повторите попытку.");
        }
        catch (DbUpdateException)
        {
            return ServiceResult<ReservationDTO>.Conflict("Не удалось сохранить резервацию из-за ограничений базы данных.");
        }

        return await GetByIdAsync(reservation.ReservationsId, ct);
    }

    public async Task<ServiceResult<ReservationDTO>> CancelAsync(int reservationId, CancellationToken ct = default)
    {
        var reservation = await _reservations.GetActiveWithProductAsync(reservationId, ct);
        if (reservation is null)
            return ServiceResult<ReservationDTO>.NotFound(
                $"Активная резервация с id {reservationId} не найдена (её нет или она уже отменена).");

        reservation.IdProductsNavigation.StockCount += reservation.CountItems;
        reservation.ReleasedAt = DateTime.UtcNow;

        try
        {
            await _reservations.SaveChangesAsync(ct);
        }
        catch (DbUpdateConcurrencyException)
        {
            return ServiceResult<ReservationDTO>.Conflict("Данные только что изменились. Повторите попытку.");
        }
        catch (DbUpdateException)
        {
            return ServiceResult<ReservationDTO>.Conflict("Не удалось отменить резервацию из-за ограничений базы данных.");
        }

        return await GetByIdAsync(reservation.ReservationsId, ct);
    }
}

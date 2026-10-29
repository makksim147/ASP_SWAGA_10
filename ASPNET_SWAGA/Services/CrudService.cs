using ASPNET_SWAGA.Common;
using ASPNET_SWAGA.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ASPNET_SWAGA.Services;

public abstract class CrudService<TEntity, TDto, TCreate, TUpdate, TPatch>
    : ICrudService<TDto, TCreate, TUpdate, TPatch>
    where TEntity : class
{
    protected readonly IRepository<TEntity> Repository;
    protected readonly IMapper Mapper;

    protected CrudService(IRepository<TEntity> repository, IMapper mapper)
    {
        Repository = repository;
        Mapper = mapper;
    }

    protected virtual Task<ServiceResult> ValidateCreateAsync(TCreate dto, CancellationToken ct) =>
        Task.FromResult(ServiceResult.Ok());

    protected virtual Task<ServiceResult> ValidateUpdateAsync(int id, TUpdate dto, CancellationToken ct) =>
        Task.FromResult(ServiceResult.Ok());

    protected virtual Task<ServiceResult> ValidatePatchAsync(int id, TPatch dto, CancellationToken ct) =>
        Task.FromResult(ServiceResult.Ok());

    public async Task<PagedResult<TDto>> GetPageAsync(int page, int pageSize, CancellationToken ct = default)
    {
        page = Math.Max(page, 1);
        pageSize = Math.Clamp(pageSize, 1, 100);

        var items = await Repository.GetPageAsync(page, pageSize, ct);
        var total = await Repository.CountAsync(ct);

        return new PagedResult<TDto>(Mapper.Map<List<TDto>>(items), total);
    }

    public async Task<ServiceResult<TDto>> GetByIdAsync(int id, CancellationToken ct = default)
    {
        var entity = await Repository.GetByIdWithDetailsAsync(id, ct);
        if (entity is null)
            return ServiceResult<TDto>.NotFound($"Запись с id {id} не найдена.");

        return ServiceResult<TDto>.Ok(Mapper.Map<TDto>(entity));
    }

    public async Task<ServiceResult<TDto>> CreateAsync(TCreate dto, CancellationToken ct = default)
    {
        var validation = await ValidateCreateAsync(dto, ct);
        if (!validation.IsSuccess)
            return ServiceResult<TDto>.Fail(validation);

        var entity = Mapper.Map<TEntity>(dto);
        await Repository.AddAsync(entity, ct);

        var saveError = await TrySaveAsync(ct);
        if (saveError is not null)
            return ServiceResult<TDto>.Fail(saveError);

        // Перечитываем запись со связанными данными, чтобы ответ содержал вложенные объекты.
        var created = await Repository.GetByIdWithDetailsAsync(Repository.GetKey(entity), ct);
        return ServiceResult<TDto>.Ok(Mapper.Map<TDto>(created!));
    }

    public async Task<ServiceResult> UpdateAsync(int id, TUpdate dto, CancellationToken ct = default)
    {
        var entity = await Repository.GetByIdAsync(id, ct);
        if (entity is null)
            return ServiceResult.NotFound($"Запись с id {id} не найдена.");

        var validation = await ValidateUpdateAsync(id, dto, ct);
        if (!validation.IsSuccess)
            return validation;

        Mapper.Map(dto, entity);
        Repository.Update(entity);

        return await TrySaveAsync(ct) ?? ServiceResult.Ok();
    }

    public async Task<ServiceResult> PatchAsync(int id, TPatch dto, CancellationToken ct = default)
    {
        var entity = await Repository.GetByIdAsync(id, ct);
        if (entity is null)
            return ServiceResult.NotFound($"Запись с id {id} не найдена.");

        var validation = await ValidatePatchAsync(id, dto, ct);
        if (!validation.IsSuccess)
            return validation;

        Mapper.Map(dto, entity); // профиль PATCH переносит только непустые поля
        Repository.Update(entity);

        return await TrySaveAsync(ct) ?? ServiceResult.Ok();
    }

    public async Task<ServiceResult> DeleteAsync(int id, CancellationToken ct = default)
    {
        var entity = await Repository.GetByIdAsync(id, ct);
        if (entity is null)
            return ServiceResult.NotFound($"Запись с id {id} не найдена.");

        Repository.Remove(entity);

        return await TrySaveAsync(ct) ?? ServiceResult.Ok();
    }

    /// <summary>Сохраняет изменения; ошибки БД превращает в понятный Conflict вместо 500.</summary>
    protected async Task<ServiceResult?> TrySaveAsync(CancellationToken ct)
    {
        try
        {
            await Repository.SaveChangesAsync(ct);
            return null;
        }
        catch (DbUpdateConcurrencyException)
        {
            return ServiceResult.Conflict("Данные были изменены другим запросом. Повторите попытку.");
        }
        catch (DbUpdateException)
        {
            return ServiceResult.Conflict(
                "Операция нарушает ограничения базы данных: значение уже существует или запись связана с другими данными.");
        }
    }
}

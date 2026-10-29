using ASPNET_SWAGA.Models.CreateDTO;
using ASPNET_SWAGA.Models.DTO;
using ASPNET_SWAGA.Services;
using Microsoft.AspNetCore.Mvc;

namespace ASPNET_SWAGA.Controllers;

[Route("api/[controller]")]
public class ReservationController : ApiControllerBase
{
    private readonly IReservationService _service;

    public ReservationController(IReservationService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<List<ReservationDTO>>> GetAll(
        [FromQuery] int page = 1, [FromQuery] int pageSize = 10, CancellationToken ct = default)
    {
        var result = await _service.GetPageAsync(page, pageSize, ct);
        AddTotalCountHeader(result.TotalCount);
        return Ok(result.Items);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ReservationDTO>> GetById(int id, CancellationToken ct)
    {
        var result = await _service.GetByIdAsync(id, ct);
        return result.IsSuccess ? Ok(result.Value) : Failure(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(ReservationDTO), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult<ReservationDTO>> Reserve([FromBody] ReserveProductDTO dto, CancellationToken ct)
    {
        var result = await _service.ReserveAsync(dto, ct);
        if (!result.IsSuccess)
            return Failure(result);

        return CreatedAtAction(nameof(GetById), new { id = result.Value!.ReservationsId }, result.Value);
    }

    [HttpPost("{id:int}/cancel")]
    [ProducesResponseType(typeof(ReservationDTO), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ReservationDTO>> Cancel(int id, CancellationToken ct)
    {
        var result = await _service.CancelAsync(id, ct);
        return result.IsSuccess ? Ok(result.Value) : Failure(result);
    }
}

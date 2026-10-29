using ASPNET_SWAGA.Services;
using Microsoft.AspNetCore.Mvc;

namespace ASPNET_SWAGA.Controllers;


[Route("api/[controller]")]
public abstract class CrudControllerBase<TDto, TCreate, TUpdate, TPatch> : ApiControllerBase
{
    private readonly ICrudService<TDto, TCreate, TUpdate, TPatch> _service;

    protected CrudControllerBase(ICrudService<TDto, TCreate, TUpdate, TPatch> service)
    {
        _service = service;
    }

    protected abstract int GetId(TDto dto);

    [HttpGet]
    public async Task<ActionResult<List<TDto>>> GetAll(
        [FromQuery] int page = 1, [FromQuery] int pageSize = 10, CancellationToken ct = default)
    {
        var result = await _service.GetPageAsync(page, pageSize, ct);
        AddTotalCountHeader(result.TotalCount);
        return Ok(result.Items);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<TDto>> GetById(int id, CancellationToken ct)
    {
        var result = await _service.GetByIdAsync(id, ct);
        return result.IsSuccess ? Ok(result.Value) : Failure(result);
    }

    [HttpPost]
    public async Task<ActionResult<TDto>> Create([FromBody] TCreate dto, CancellationToken ct)
    {
        var result = await _service.CreateAsync(dto, ct);
        if (!result.IsSuccess)
            return Failure(result);

        return CreatedAtAction(nameof(GetById), new { id = GetId(result.Value!) }, result.Value);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] TUpdate dto, CancellationToken ct)
    {
        var result = await _service.UpdateAsync(id, dto, ct);
        return result.IsSuccess ? NoContent() : Failure(result);
    }

    [HttpPatch("{id:int}")]
    public async Task<IActionResult> Patch(int id, [FromBody] TPatch dto, CancellationToken ct)
    {
        var result = await _service.PatchAsync(id, dto, ct);
        return result.IsSuccess ? NoContent() : Failure(result);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id, CancellationToken ct)
    {
        var result = await _service.DeleteAsync(id, ct);
        return result.IsSuccess ? NoContent() : Failure(result);
    }
}

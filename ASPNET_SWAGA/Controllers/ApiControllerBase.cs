using ASPNET_SWAGA.Common;
using Microsoft.AspNetCore.Mvc;

namespace ASPNET_SWAGA.Controllers;

[ApiController]
public abstract class ApiControllerBase : ControllerBase
{
    protected ActionResult Failure(ServiceResult result) => result.Error switch
    {
        ServiceError.NotFound => Problem(detail: result.Message, statusCode: StatusCodes.Status404NotFound, title: "Не найдено"),
        ServiceError.Validation => Problem(detail: result.Message, statusCode: StatusCodes.Status400BadRequest, title: "Некорректный запрос"),
        ServiceError.Conflict => Problem(detail: result.Message, statusCode: StatusCodes.Status409Conflict, title: "Конфликт"),
        _ => Problem(detail: result.Message, statusCode: StatusCodes.Status500InternalServerError)
    };

    protected void AddTotalCountHeader(int totalCount) =>
        Response.Headers["X-Total-Count"] = totalCount.ToString();
}

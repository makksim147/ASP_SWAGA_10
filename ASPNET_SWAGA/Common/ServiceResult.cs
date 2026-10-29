namespace ASPNET_SWAGA.Common;

/// <summary>Тип ошибки бизнес-логики. Сервисы ничего не знают про HTTP — перевод в статус-коды делает контроллер.</summary>
public enum ServiceError
{
    None,
    NotFound,
    Validation,
    Conflict
}

public class ServiceResult
{
    public ServiceError Error { get; init; } = ServiceError.None;
    public string? Message { get; init; }
    public bool IsSuccess => Error == ServiceError.None;

    public static ServiceResult Ok() => new();
    public static ServiceResult NotFound(string message) => new() { Error = ServiceError.NotFound, Message = message };
    public static ServiceResult Validation(string message) => new() { Error = ServiceError.Validation, Message = message };
    public static ServiceResult Conflict(string message) => new() { Error = ServiceError.Conflict, Message = message };
}

public class ServiceResult<T> : ServiceResult
{
    public T? Value { get; init; }

    public static ServiceResult<T> Ok(T value) => new() { Value = value };
    public new static ServiceResult<T> NotFound(string message) => new() { Error = ServiceError.NotFound, Message = message };
    public new static ServiceResult<T> Validation(string message) => new() { Error = ServiceError.Validation, Message = message };
    public new static ServiceResult<T> Conflict(string message) => new() { Error = ServiceError.Conflict, Message = message };

    public static ServiceResult<T> Fail(ServiceResult failed) => new() { Error = failed.Error, Message = failed.Message };
}

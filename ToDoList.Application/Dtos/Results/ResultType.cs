namespace ToDoList.Application.Dtos.Results;

public enum ResultType
{
    Ok,
    Invalid,
    Unauthorized,
    PartialOk,
    NotFound,
    PermissionDenied,
    Unexpected,
    Created
}

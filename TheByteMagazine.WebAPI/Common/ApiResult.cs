namespace TheByteMagazine.WebAPI.Common;

public class ApiResult<T> : ApiResponse
{
    public T? Data { get; set; }

    public static ApiResult<T> Success(T data, string? message = null) => new ApiResult<T>
    {
        IsSuccess = true,
        Message = message,
        Data = data
    };
}


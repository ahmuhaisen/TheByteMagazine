using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace TheByteMagazine.WebAPI.Common;

public class ApiResponse
{
    public bool IsSuccess { get; set; }
    public string? Message { get; set; }

    public static ApiResponse Failure(string message) => new ApiResponse
    {
        IsSuccess = false,
        Message = message
    };

    public static ApiResponse Failure(ModelStateDictionary modelState) => new ApiResponse
    {
        IsSuccess = false,
        Message = string.Join(", ", modelState.Values.First().RawValue)
    };

    public static ApiResponse Success() => new ApiResponse
    {
        IsSuccess = true
    };
}
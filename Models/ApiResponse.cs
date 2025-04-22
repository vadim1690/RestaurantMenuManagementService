namespace RestaurantMenuManagementService.Models
{
    public class ApiResponse
    {
        public string? Message { get; set; }
        public bool Success { get; set; }

        public List<string> Errors { get; set; } = new List<string>();

        public string ResponseId { get; set; } = Guid.NewGuid().ToString();
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        public static ApiResponse SuccessResponse(string? message = null)
        {
            return new ApiResponse { Message = message ,Success= true};
        }

        public static ApiResponse<T> SuccessResponse<T>(T data, string? message = null)
        {
            return new ApiResponse<T>
            {
                Message = message,
                Success = true,
                Data = data
            };
        }
        public static ApiResponse ErrorResponse(string? message = null,List<string>? errors = null)
        {
            return new ApiResponse { Message = message, Success = false,Errors = errors ?? [] };
        }
    }


    public class ApiResponse<T> : ApiResponse
    {
        public T? Data { get; set; }
    }
}

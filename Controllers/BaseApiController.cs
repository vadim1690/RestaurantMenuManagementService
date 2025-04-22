using Microsoft.AspNetCore.Mvc;
using RestaurantMenuManagementService.Models;

namespace RestaurantMenuManagementService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseApiController : ControllerBase
    {
        protected ActionResult<ApiResponse> ApiOk(string? message = null)
        {
            return Ok(ApiResponse.SuccessResponse(message));
        }

        protected ActionResult<ApiResponse> ApiCreated(string? message = null)
        {
            return StatusCode(StatusCodes.Status201Created,
                ApiResponse.SuccessResponse(message ?? "Resource created successfully"));
        }

        protected ActionResult<ApiResponse> ApiNoContent(string? message = null)
        {
            return StatusCode(StatusCodes.Status204NoContent,
                ApiResponse.SuccessResponse(message));
        }


        protected ActionResult<ApiResponse<T>> ApiOk<T>(T data,string? message = null)
        {
            return Ok(ApiResponse.SuccessResponse(data,message));
        }

        protected ActionResult<ApiResponse<T>> ApiCreated<T>(T data,string? message = null)
        {
            return StatusCode(StatusCodes.Status201Created,
                ApiResponse.SuccessResponse(data, message ?? "Resource created successfully"));
        }

    }
}

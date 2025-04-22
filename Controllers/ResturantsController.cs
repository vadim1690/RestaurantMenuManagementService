using Microsoft.AspNetCore.Mvc;
using RestaurantMenuManagementService.DTOs.AuditLog;
using RestaurantMenuManagementService.DTOs.Category;
using RestaurantMenuManagementService.DTOs.Item;
using RestaurantMenuManagementService.DTOs.Resturant;
using RestaurantMenuManagementService.Models;
using RestaurantMenuManagementService.Services.ResturantService;

namespace RestaurantMenuManagementService.Controllers
{

    public class ResturantsController : BaseApiController
    {
        private readonly IResturantService _resturantService;

        public ResturantsController(IResturantService resturantService)
        {
            _resturantService = resturantService;
        }

        [HttpGet("{resturantId}/categories")]
        public async Task<ActionResult<ApiResponse<GetCategoriesResponseDto>>> GetCategories(Guid resturantId)
        {
            return ApiOk(await _resturantService.GetCategories(resturantId));  
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<List<ResturantDto>>>> GetResturants()
        {
            return ApiOk(await _resturantService.GetResturants());
        }

        [HttpPost("{resturantId}/categories")]
        public async Task<ActionResult<ApiResponse<CreatedCategoryDto>>> CreateCategory(Guid resturantId, [FromBody] CreateCategoryDto dto)
        {
            return ApiCreated(await _resturantService.CreateCategory(resturantId,dto));
        }

        [HttpPut("{resturantId}/categories/{categoryId}")]
        public async Task<ActionResult<ApiResponse<UpdatedCategoryDto>>> UpdateCategory(Guid resturantId, Guid categoryId, [FromBody] UpdateCategoryDto dto)
        {
            return ApiOk(await _resturantService.UpdateCategory(resturantId,categoryId, dto));
        }


        [HttpDelete("{resturantId}/categories/{categoryId}")]
        public async Task<ActionResult<ApiResponse>> UpdateCategory(Guid resturantId, Guid categoryId)
        {
            await _resturantService.DeleteCategory(resturantId, categoryId);
            return ApiNoContent();
        }

        [HttpGet("{resturantId}/categories/{categoryId}/items")]
        public async Task<ActionResult<ApiResponse<GetMenuItemsDto>>> GetMenuItems(Guid resturantId, Guid categoryId)
        {
            return ApiOk(await _resturantService.GetMenuItems(resturantId,categoryId));
        }

        [HttpPost("{resturantId}/categories/{categoryId}/items")]
        public async Task<ActionResult<ApiResponse<CreatedItemDto>>> CreateItem(Guid resturantId, Guid categoryId, [FromBody] CreateItemDto dto)
        {
            return ApiCreated(await _resturantService.CreateItem(resturantId, categoryId,dto));
        }

        [HttpPut("{resturantId}/categories/{categoryId}/items/{itemId}")]
        public async Task<ActionResult<ApiResponse<UpdatedItemDto>>> CreateItem(Guid resturantId, Guid categoryId, Guid itemId, [FromBody] UpdateItemDto dto)
        {
            return ApiOk(await _resturantService.UpdateItem(resturantId, categoryId,itemId, dto));
        }

        [HttpPatch("{resturantId}/categories/{categoryId}/items/{itemId}/availability")]
        public async Task<ActionResult<ApiResponse<AvailabilityUpdatedItemDto>>> UpdateItemAvailability(Guid resturantId, Guid categoryId, Guid itemId, [FromBody] UpdateItemAvailabilityDto dto)
        {
            return ApiOk(await _resturantService.UpdateItemAvailability(resturantId, categoryId, itemId, dto));
        }

        [HttpPost("{resturantId}/items/bulk")]
        public async Task<ActionResult<ApiResponse<CreatedItemsBulkDto>>> CreateItemsBulk(Guid resturantId, [FromBody] CreateItemsBulkDto dto)
        {
            return ApiCreated(await _resturantService.CreateItemsBulk(resturantId,  dto));
        }


        [HttpGet("{resturantId}/audit-logs")]
        public async Task<ActionResult<ApiResponse<AuditLogsResponseDto>>> CreateItemsBulk(Guid resturantId, [FromQuery] AuditLogsRequestDto dto)
        {
            var result = await _resturantService.GetAuditLogs(resturantId, dto);
            return ApiOk(result);
        }
    }
}

using RestaurantMenuManagementService.DTOs.AuditLog;
using RestaurantMenuManagementService.DTOs.Category;
using RestaurantMenuManagementService.DTOs.Item;
using RestaurantMenuManagementService.DTOs.Resturant;

namespace RestaurantMenuManagementService.Services.ResturantService
{
    public interface IResturantService
    {
        Task<CreatedCategoryDto> CreateCategory(Guid resturantId, CreateCategoryDto dto);
        Task<CreatedItemDto> CreateItem(Guid resturantId, Guid categoryId, CreateItemDto dto);
        Task<CreatedItemsBulkDto> CreateItemsBulk(Guid resturantId, CreateItemsBulkDto dto);
        Task DeleteCategory(Guid resturantId, Guid categoryId);
        Task<AuditLogsResponseDto> GetAuditLogs(Guid resturantId, AuditLogsRequestDto dto);
        Task<GetCategoriesResponseDto> GetCategories(Guid resturantId);
        Task<GetMenuItemsDto> GetMenuItems(Guid resturantId, Guid categoryId);
        Task<List<ResturantDto>> GetResturants();
        Task<UpdatedCategoryDto> UpdateCategory(Guid resturantId, Guid categoryId, UpdateCategoryDto dto);
        Task<UpdatedItemDto> UpdateItem(Guid resturantId, Guid categoryId, Guid ItemId, UpdateItemDto dto);
        Task<AvailabilityUpdatedItemDto> UpdateItemAvailability(Guid resturantId, Guid categoryId, Guid ItemId, UpdateItemAvailabilityDto dto);
    }
}
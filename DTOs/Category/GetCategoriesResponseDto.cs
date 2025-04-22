namespace RestaurantMenuManagementService.DTOs.Category
{
    public class GetCategoriesResponseDto
    {
        public Guid ResturantId { get; set; }
        public List<CategoryDto> Categories { get; set; } = [];
    }
}

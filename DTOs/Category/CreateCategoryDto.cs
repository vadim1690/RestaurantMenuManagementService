namespace RestaurantMenuManagementService.DTOs.Category
{
    public class CreateCategoryDto
    {
        public required string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; }
    }
}

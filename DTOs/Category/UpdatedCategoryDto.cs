namespace RestaurantMenuManagementService.DTOs.Category
{
    public class UpdatedCategoryDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; }
        public DateTime ModifiedAt { get; set; }
        public Guid Id { get; set; }
    }
}

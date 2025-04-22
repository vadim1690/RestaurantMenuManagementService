using RestaurantMenuManagementService.Models;

namespace RestaurantMenuManagementService.DTOs.Item
{
    public class UpdatedItemDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int DisplayOrder { get; set; }
        public bool IsAvailable { get; set; }
        public decimal Price { get; set; }
        public bool IsVegetarian { get; set; }
        public bool IsVegan { get; set; }
        public bool IsGlutenFree { get; set; }
        public decimal Calories { get; set; }
        public List<string> Allergens { get; set; } = [];
        public int PreparationTime { get; set; }
        public bool IsPromoted { get; set; }
        public List<AvailabilityWindow> AvailabilityWindows { get; set; } = [];
        public DateTime CreatedAt { get; set; }
    }
}

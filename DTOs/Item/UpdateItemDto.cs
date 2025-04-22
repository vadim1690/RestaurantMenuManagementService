using RestaurantMenuManagementService.Models;

namespace RestaurantMenuManagementService.DTOs.Item
{
    public class UpdateItemDto
    {
        public string? Name { get; set; } 
        public string? Description { get; set; }
        public string? ImageUrl { get; set; } 
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
    }
}

using RestaurantMenuManagementService.Models;

namespace RestaurantMenuManagementService.Data.Entities
{
    public class Item : BaseEntity
    {
        public string Name { get; set; } = String.Empty;
        public string ImageUrl { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public int DisplayOrder { get; set; }
        public bool IsAvailable { get; set; }
        public decimal Price { get; set; }
        public bool IsVegetarian { get; set; }
        public bool IsVegan { get; set; }
        public bool IsGlutenFree { get; set; }
        public decimal Calories { get; set; }
        public string Allergens { get; set; } = String.Empty;
        public int PreparationTime { get; set; }
        public bool IsPromoted { get; set; }
        public string AvailabilityWindows { get; set; } = String.Empty;

        public Guid CategoryId { get; set; }

        public virtual Category Category { get; set; }
  
    }
}

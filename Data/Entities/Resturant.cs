using RestaurantMenuManagementService.Models;

namespace RestaurantMenuManagementService.Data.Entities
{
    public class Resturant : BaseEntity
    {
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public string CuisineType { get; set; } = String.Empty;
        public string OperatingHours { get; set; } = String.Empty;

        public virtual ICollection<Category> Categories { get; set; }


    }
}

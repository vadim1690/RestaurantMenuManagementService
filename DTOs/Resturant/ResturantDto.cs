using RestaurantMenuManagementService.Models;

namespace RestaurantMenuManagementService.DTOs.Resturant
{
    public class ResturantDto
    {
        public Guid Id { get; set; } 
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string CuisineType { get; set; } = string.Empty;
        public List<OperationHour> OperatingHours { get; set; } = [];
    }
}

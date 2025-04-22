namespace RestaurantMenuManagementService.DTOs.Item
{
    public class UpdateItemAvailabilityDto
    {
        public  bool IsAvailable { get; set; }
        public  string? UnavailabilityReason { get; set; }
    }
}

namespace RestaurantMenuManagementService.DTOs.Item
{
    public class AvailabilityUpdatedItemDto
    {
        public  Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public  bool IsAvailable { get; set; }
        public DateTime ModifiedAt { get; set; }
        public string? UnavailabilityReason { get; set; }
    }
}

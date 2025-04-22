namespace RestaurantMenuManagementService.DTOs.Item
{
    public class CreateItemsBulkDto
    {
        public Guid CategoryId { get; set; }
        public List<CreateItemDto> Items { get; set; }
    }
}

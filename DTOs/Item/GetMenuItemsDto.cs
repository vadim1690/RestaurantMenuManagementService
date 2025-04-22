namespace RestaurantMenuManagementService.DTOs.Item
{
    public class GetMenuItemsDto
    {
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;

        public List<ItemDto> Items { get; set; } = [];


    }
}

namespace RestaurantMenuManagementService.DTOs.Item
{
    public class CreatedItemsBulkDto
    {
        public int Successfull { get; set; }
        public int Failed { get; set; }

        public List<CreatedItemDto> Items { get; set; } = [];

        public List<string> Errors { get; set; } = [];
    }
}

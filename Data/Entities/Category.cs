namespace RestaurantMenuManagementService.Data.Entities
{
    public class Category:BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; }
        public Guid ResturantId { get; set; }

        public virtual Resturant Resturant { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}

namespace RestaurantMenuManagementService.Data.Entities
{
    public class AuditLog : BaseEntity
    {
        public DateTime Timestamp { get; set; }
        public string Action { get; set; } = String.Empty;
        public string EntityType { get; set; } = String.Empty;
        public string EntityId { get; set; } = String.Empty;
        public string EntityName { get; set; } = String.Empty;
        public string Changes { get; set; } = String.Empty;
    }
}

using System.Text.Json;
using System.Text.Json.Nodes;

namespace RestaurantMenuManagementService.DTOs.AuditLog
{
    public class AuditLogDto
    {
        public Guid Id { get; set; }
        public DateTime Timestamp { get; set; }
        public string Action { get; set; } = String.Empty;
        public string EntityType { get; set; } = String.Empty;
        public string EntityId { get; set; } = String.Empty;
        public string EntityName { get; set; } = String.Empty;
        public Dictionary<string, object>? Changes { get; set; }
    }
}

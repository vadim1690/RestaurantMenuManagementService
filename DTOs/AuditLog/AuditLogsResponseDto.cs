namespace RestaurantMenuManagementService.DTOs.AuditLog
{
    public class AuditLogsResponseDto
    {
        public int TotalCount { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public List<AuditLogDto> Logs { get; set; } = [];
    }
}

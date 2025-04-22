namespace RestaurantMenuManagementService.DTOs.AuditLog
{
    public class AuditLogsRequestDto
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

    }
}

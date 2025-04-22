using RestaurantMenuManagementService.Data;
using RestaurantMenuManagementService.Data.Entities;

namespace RestaurantMenuManagementService.Repositories.AuditLogRepository
{
    public class AuditLogRepository : Repository<AuditLog>, IAuditLogRepository
    {
        public AuditLogRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}

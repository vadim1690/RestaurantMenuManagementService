using EFCore.BulkExtensions;
using RestaurantMenuManagementService.Data;
using RestaurantMenuManagementService.Data.Entities;
// Add this import

namespace RestaurantMenuManagementService.Repositories.ItemRepository
{
    public class ItemRepository : Repository<Item>, IItemRepository
    {
        public ItemRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
        
    }
}
using RestaurantMenuManagementService.Data;
using RestaurantMenuManagementService.Data.Entities;

namespace RestaurantMenuManagementService.Repositories.CategoryRepository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}

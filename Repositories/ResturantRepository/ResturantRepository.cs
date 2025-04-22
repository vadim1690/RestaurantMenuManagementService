using RestaurantMenuManagementService.Data;
using RestaurantMenuManagementService.Data.Entities;

namespace RestaurantMenuManagementService.Repositories.ResturantRepository
{
    public class ResturantRepository : Repository<Resturant>, IResturantRepository
    {
        public ResturantRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}

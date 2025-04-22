using RestaurantMenuManagementService.Data.Entities;
using RestaurantMenuManagementService.Models;
using System.Linq.Expressions;

namespace RestaurantMenuManagementService.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T?> GetByIdAsync(Guid id);
        Task<T?> GetByIdAsync(Guid id, params Expression<Func<T, object>>[] includes);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<IReadOnlyList<T>> ListAsync(params Expression<Func<T, bool>>[] filters);
        Task<PagedResult<T>> GetPagedAsync(PaginationParams pagingParams, params Expression<Func<T, bool>>[] filters);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<bool> ExistsAsync(Guid id);
        Task<int> CountAsync(params Expression<Func<T, bool>>[] filters);
    }
}

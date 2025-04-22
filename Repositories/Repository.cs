using Microsoft.EntityFrameworkCore;
using RestaurantMenuManagementService.Data;
using RestaurantMenuManagementService.Data.Entities;
using RestaurantMenuManagementService.Models;
using System;
using System.Linq.Expressions;

namespace RestaurantMenuManagementService.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly AppDbContext _dbContext;

        public Repository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(Guid id)
        {
            return await _dbContext.Set<T>().AnyAsync(e => e.Id == id);
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<T?> GetByIdAsync(Guid id, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbContext.Set<T>();

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<PagedResult<T>> GetPagedAsync(PaginationParams pagingParams, params Expression<Func<T, bool>>[] filters)
        {
            IQueryable<T> query = _dbContext.Set<T>();

            // Apply filters
            foreach (var filter in filters)
            {
                query = query.Where(filter);
            }

            // Get total count before pagination
            var totalCount = await query.CountAsync();

            // Apply pagination
            var items = await query
                .Skip((pagingParams.PageNumber - 1) * pagingParams.PageSize)
                .Take(pagingParams.PageSize)
                .ToListAsync();

            return new PagedResult<T>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pagingParams.PageNumber,
                PageSize = pagingParams.PageSize
            };
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> ListAsync(params Expression<Func<T, bool>>[] filters)
        {
            IQueryable<T> query = _dbContext.Set<T>();

            foreach (var filter in filters)
            {
                query = query.Where(filter);
            }

            return await query.ToListAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<int> CountAsync(params Expression<Func<T, bool>>[] filters)
        {
            IQueryable<T> query = _dbContext.Set<T>();

            foreach (var filter in filters)
            {
                query = query.Where(filter);
            }

            return await query.CountAsync();
        }
    }
}

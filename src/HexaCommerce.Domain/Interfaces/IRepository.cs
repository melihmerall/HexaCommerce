using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HexaCommerce.Domain.Entities;
using HexaCommerce.Domain.Specifications;

namespace HexaCommerce.Domain.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        // Query methods
        Task<T> GetByIdAsync(Guid id);
        Task<T> GetByIdAsync(Guid id, params Expression<Func<T, object>>[] includes);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includes);
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
        Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate);
        Task<int> CountAsync(Expression<Func<T, bool>> predicate = null);
        
        // Specification pattern methods
        Task<IEnumerable<T>> GetAsync(ISpecification<T> spec);
        Task<T> GetFirstOrDefaultAsync(ISpecification<T> spec);
        Task<int> CountAsync(ISpecification<T> spec);
        
        // Command methods
        Task<T> AddAsync(T entity);
        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);
        Task UpdateAsync(T entity);
        Task UpdateRangeAsync(IEnumerable<T> entities);
        Task DeleteAsync(T entity);
        Task DeleteAsync(Guid id);
        Task DeleteRangeAsync(IEnumerable<T> entities);
        Task DeleteRangeAsync(Expression<Func<T, bool>> predicate);
        
        // Paging
        Task<(IEnumerable<T> Items, int TotalCount)> GetPagedAsync(
            int pageNumber, 
            int pageSize, 
            Expression<Func<T, bool>> predicate = null,
            Expression<Func<T, object>> orderBy = null,
            bool ascending = true,
            params Expression<Func<T, object>>[] includes);
            
        // Specification paging
        Task<(IEnumerable<T> Items, int TotalCount)> GetPagedAsync(ISpecification<T> spec);
    }
} 
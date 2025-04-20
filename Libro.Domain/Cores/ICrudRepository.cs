using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Domain.Cores
{
     public interface ICrudRepository<TEntity, TId>
    {
        Task<IReadOnlyList<TEntity>> FindAllAsync();

        Task<TEntity?> FindByIdAsync(TId id);

        Task<TEntity> SaveAsync(TEntity entity);

        Task<IList<TEntity>> SaveAllAsync(IList<TEntity> entities);

        Task<TEntity?> FindFirstOrDefaultAsync(
            Expression<Func<TEntity, bool>> predicate,
            List<Expression<Func<TEntity, object>>> includes = null,
            bool disableTracking = true
        );

        Task<IList<TEntity>> FindAllAsync(
            Expression<Func<TEntity, bool>> predicate = null,
            List<Expression<Func<TEntity, object>>> includes = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            bool disableTracking = true
        );
    }
}

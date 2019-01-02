using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Optivem.Commons.Persistence
{
    public interface IRepository<TEntity> where TEntity : class
    {
        #region Read

        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? skip = null, int? take = null,
            params Expression<Func<TEntity, object>>[] includes);

        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? skip = null, int? take = null,
            params Expression<Func<TEntity, object>>[] includes);

        TEntity GetSingle(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes);

        Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes);

        TEntity GetSingleOrDefault(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes);

        Task<TEntity> GetSingleOrDefaultAsync(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes);

        TEntity GetFirst(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes);

        Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes);

        TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes);

        Task<TEntity> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes);

        TEntity GetSingleOrDefault(params object[] id);

        Task<TEntity> GetSingleOrDefaultAsync(params object[] id);

        long GetCount(Expression<Func<TEntity, bool>> filter = null);

        Task<long> GetCountAsync(Expression<Func<TEntity, bool>> filter = null);

        bool GetExists(Expression<Func<TEntity, bool>> filter = null);

        Task<bool> GetExistsAsync(Expression<Func<TEntity, bool>> filter = null);

        // TODO: VC: Consider GetExists for the id

        #endregion

        #region Create

        void Add(TEntity entity);

        Task AddAsync(TEntity entity);

        void AddRange(IEnumerable<TEntity> entities);

        Task AddRangeAsync(IEnumerable<TEntity> entities);

        void AddRange(params TEntity[] entities);

        Task AddRangeAsync(params TEntity[] entities);

        #endregion

        #region Update

        void Update(TEntity entity);

        void UpdateRange(IEnumerable<TEntity> entities);

        void UpdateRange(params TEntity[] entities);

        #endregion

        #region Delete

        void Delete(TEntity entity);

        void Delete(object[] id);

        void DeleteRange(IEnumerable<TEntity> entities);

        void DeleteRange(IEnumerable<object[]> ids);

        void DeleteRange(params TEntity[] entities);

        void DeleteRange(params object[][] ids);

        #endregion
    }


    public interface IRepository<TEntity, TId> : IRepository<TEntity>
        where TEntity : class
    {
        #region Read

        TEntity GetSingleOrDefault(TId id);

        Task<TEntity> GetSingleOrDefaultAsync(TId id);

        bool GetExists(TId id);

        Task<bool> GetExistsAsync(TId id);

        #endregion


        #region Delete

        void DeleteRange(IEnumerable<TId> ids);

        void DeleteRange(params TId[] ids);

        #endregion

    }
}

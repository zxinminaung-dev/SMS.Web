using System.Collections.Generic;

namespace WebApplication1.Common
{
    public interface IQueryRepositoryBase<TEntity> where TEntity : IEntity
    {
        TEntity Get(int id);
        List<TEntity> GetAll(QueryOption<TEntity> queryOption);
    }
}

using System.Collections.Generic;

namespace WebApplication1.Common
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        List<TEntity> Get();
        int Save(TEntity entity);   
        int Update(TEntity entity);
        void Delete(TEntity entity);
    }
}

using System.Collections.Generic;
using System.Linq;
using WebApplication1.Data;

namespace WebApplication1.Common
{
    public class QueryableRepository<TEntity> : IQueryRepositoryBase<TEntity> where TEntity : IEntity
    {
        private readonly DatabaseContext _context;
        public QueryableRepository(DatabaseContext databaseContext) 
        { 
            this._context = databaseContext;
        }
        public TEntity Get(int id)
        {
            return _context.Set<TEntity>().Where(x=>x.ID == id).FirstOrDefault();
        }

        public List<TEntity> GetAll(QueryOption<TEntity> queryOption)
        {
            if (queryOption.FilterBy != null)
            {
                if (queryOption.SortOrder == "DESC")
                {
                    return _context.Set<TEntity>().Where(queryOption.FilterBy).Take(queryOption.Take).Skip(queryOption.Skip).OrderByDescending(queryOption.SortBy).ToList();
                }
                else
                {
                    return _context.Set<TEntity>().Where(queryOption.FilterBy).Take(queryOption.Take).Skip(queryOption.Skip).OrderBy(queryOption.SortBy).ToList();
                }
            }
            else
            {
                if (queryOption.SortOrder == "DESC")
                {
                    return _context.Set<TEntity>().Take(queryOption.Take).Skip(queryOption.Skip).OrderByDescending(queryOption.SortBy).ToList();
                }
                else
                {
                    return _context.Set<TEntity>().Take(queryOption.Take).Skip(queryOption.Skip).OrderBy(queryOption.SortBy).ToList();
                }
            }
            
            
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using WebApplication1.Data;

namespace WebApplication1.Common
{
    public class ReadWriteRepositoryBase<TEntity> : IReadWriteRepositoryBase<TEntity> where TEntity : IEntity
    {
        private readonly DatabaseContext _context;
        public ReadWriteRepositoryBase(DatabaseContext context) 
        { 
            this._context = context;
        }
        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _context.SaveChanges();
        }

        public TEntity Get(int id)
        {
          return _context.Set<TEntity>().Where(x=>(int)x.ID == id).FirstOrDefault();
        }

        public List<TEntity> Get()
        {
           return _context.Set<TEntity>().ToList();
        }

        public int Save(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
            return (int)entity.GetType().GetProperty("ID").GetValue(entity);
        }

        public int Update(TEntity entity)
        {
            _context.Set<TEntity>().Attach(entity);
            _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return (int)entity.GetType().GetProperty("ID").GetValue(entity);
        }
    }
}

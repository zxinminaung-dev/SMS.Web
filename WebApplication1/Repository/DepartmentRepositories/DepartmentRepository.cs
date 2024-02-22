using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Data;
using WebApplication1.Model.Entity;

namespace WebApplication1.Repository.DeopartmentRepositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly DatabaseContext _context;
        private ILogger<DepartmentRepository> _logger;
        public DepartmentRepository(DatabaseContext context, ILogger<DepartmentRepository> logger) 
        { 
            _context = context;
            _logger = logger;   
        }

        public void Delete(Department entity)
        {
            _context.Department.Remove(entity);
            _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _context.SaveChanges();
        }

        public Department FindByName(string name)
        {
           return _context.Department.AsQueryable().Where(x=>x.NAME.Equals(name)).FirstOrDefault();
        }

        public Department Get(int id)
        {
            return _context.Department.Where(x=>x.ID==id).FirstOrDefault();  
        }

        public List<Department> Get()
        {
            List<Department> departmentList = new List<Department>(); 
            try
            {
                departmentList = _context.Department.ToList();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
            }
           return departmentList;
        }

        public int Save(Department entity)
        {
            _context.Department.Add(entity);
            _context.SaveChanges();
            return (int)entity.GetType().GetProperty("ID").GetValue(entity);
        }

        public int Update(Department entity)
        {
            _context.Department.Attach(entity);
            _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return (int)entity.GetType().GetProperty("ID").GetValue(entity);
        }
    }
}

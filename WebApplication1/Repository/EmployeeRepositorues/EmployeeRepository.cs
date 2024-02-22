using System.Linq;
using WebApplication1.Common;
using WebApplication1.Data;
using WebApplication1.Model.Entity;

namespace WebApplication1.Repository.EmployeeRepositorues
{
    public class EmployeeRepository : ReadWriteRepositoryBase<Employee>, IEmployeeRepository
    {
        private readonly DatabaseContext _context;
        public EmployeeRepository(DatabaseContext context) 
            : base(context)
        {
            this._context = context;
        }

        public Employee GetByName(string name)
        {
           return _context.Set<Employee>().AsQueryable().Where(x => x.NAME.Equals(name)).FirstOrDefault();
        }
    }
}

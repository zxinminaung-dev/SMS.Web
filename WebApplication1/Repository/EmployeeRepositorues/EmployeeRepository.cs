using WebApplication1.Common;
using WebApplication1.Data;
using WebApplication1.Model.Entity;

namespace WebApplication1.Repository.EmployeeRepositorues
{
    public class EmployeeRepository : ReadWriteRepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(DatabaseContext context) 
            : base(context)
        {
        }
    }
}

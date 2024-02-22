using WebApplication1.Common;
using WebApplication1.Model.Entity;

namespace WebApplication1.Repository.EmployeeRepositorues
{
    public interface IEmployeeRepository: IReadWriteRepositoryBase<Employee>
    {
    }
}

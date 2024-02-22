using WebApplication1.Common;
using WebApplication1.Model.Entity;

namespace WebApplication1.Repository.DeopartmentRepositories
{
    public interface IDepartmentRepository : IRepositoryBase<Department>
    {
        Department FindByName(string name);
    }
}

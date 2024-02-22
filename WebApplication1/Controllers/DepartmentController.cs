using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApplication1.Model.Entity;
using WebApplication1.Repository.DeopartmentRepositories;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : Controller
    {
        IDepartmentRepository _deptRepo;
        public DepartmentController(IDepartmentRepository departmentRepository) 
            :base()
        {  
            this._deptRepo = departmentRepository;
        }
        [HttpGet]
        public JsonResult Get()
        {
            Employee employee = new Employee();
            employee.ID = 1;
            List<Department> deptList = _deptRepo.Get();  
            return Json(deptList);
        }
        [HttpPost]
        public JsonResult Save(Department department)
        {
            int success = _deptRepo.Save(department);
            return Json(success);   
        }
    }
}

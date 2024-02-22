using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApplication1.Model.Entity;
using WebApplication1.Repository.EmployeeRepositorues;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        IEmployeeRepository _employeeRepo;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            this._employeeRepo = employeeRepository;
        }
        [HttpGet]
        public JsonResult Get()
        {
            List<Employee> empList = _employeeRepo.Get();
            return Json(empList);
        }
    }
}

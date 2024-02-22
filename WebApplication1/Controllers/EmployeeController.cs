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
        [HttpGet]
        [Route("getbyid")]
        public JsonResult GetById(int id)
        {
            Employee emp = _employeeRepo.Get(id);
            return Json(emp);
        }
        [HttpGet]
        [Route("getbyname")]
        public JsonResult GetById(string name)
        {
            Employee emp = _employeeRepo.GetByName(name);
            return Json(emp);
        }
    }
}

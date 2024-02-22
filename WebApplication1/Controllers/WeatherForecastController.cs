using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Model.Entity;
using WebApplication1.Repository.DeopartmentRepositories;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : Controller
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private IDepartmentRepository _deptRepo;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, IDepartmentRepository departmentRepository)
        {
            _logger = logger;
            _deptRepo = departmentRepository;
        }

        [HttpGet]
        public JsonResult Get()
        {
            using(var context = new DatabaseContext())
            {
               var departments = context.Department.ToArray();
                return Json(departments);   
            }
        }
        [HttpGet]
        [Route("departmentList")]
        public JsonResult GetDepartmentList()
        {
            List<Department> deptList = _deptRepo.Get();
            return Json(deptList);
        }
        [HttpGet]
        [Route("department")]
        public JsonResult GetDepartment(int id)
        {
            Department dept = _deptRepo.Get(id);
            return Json(dept);
        }
        [HttpGet]
        [Route("getdepartmentbyid")]
        public JsonResult GetDepartmentById()
        {
            int id ;
            string tempId = Request.Query["id"].ToString();
            id = Convert.ToInt32(tempId);
            Department dept = _deptRepo.Get(id);
            return Json(dept);
        }
    }
}

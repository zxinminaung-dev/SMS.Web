using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
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
               var weatherForecast = context.WeatherForecast.ToArray();
                return Json(weatherForecast);   
            }
        }
        [HttpGet]
        [Route("findbyname")]
        public JsonResult Get(string name)
        {
            using (var context = new DatabaseContext())
            {
                var weatherForecast = context.WeatherForecast.Where(x => x.Name==name).FirstOrDefault();
                return Json(weatherForecast);
            }
        }
        [HttpPost]
        public JsonResult Save(WeatherForecast weather)
        {
            using (var context = new DatabaseContext())
            {
                WeatherForecast weatherForecast = new WeatherForecast();
                weatherForecast.Name = weather.Name;
                context.WeatherForecast.Add(weatherForecast);
                context.SaveChanges();
                return Json(new {success=true});
            }
        }
        [HttpGet]
        [Route("getbyid")]
        public JsonResult GetById(int id)
        {
            using (var context = new DatabaseContext())
            {
                WeatherForecast weatherForecast = context.WeatherForecast.Where(x => x.Id == id).FirstOrDefault();
                return Json(weatherForecast);
            }
        }
        [HttpGet]
        [Route("take")]
        public JsonResult TakeRecord(int take)
        {
            using (var context = new DatabaseContext())
            {
                var weatherForecast = context.WeatherForecast.Take(take).ToList();
                return Json(weatherForecast);
            }
        }
        [HttpGet]
        [Route("skipandtake")]
        public JsonResult SkipAndTakeRecord(int take, int skip)
        {
            using (var context = new DatabaseContext())
            {
                var weatherForecast = context.WeatherForecast.Take(take).Skip(skip).ToList();
                return Json(weatherForecast);
            }
        }
        [HttpGet]
        [Route("orderdesc")]
        public JsonResult OrderDesc()
        {
            using (var context = new DatabaseContext())
            {
                var weatherForecast = context.WeatherForecast.OrderByDescending(x=>x.Id).ToList();
                return Json(weatherForecast);
            }
        }
    }
}

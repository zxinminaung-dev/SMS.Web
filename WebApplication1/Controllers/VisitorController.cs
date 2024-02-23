using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WebApplication1.Common;
using WebApplication1.Model.Entity;
using WebApplication1.Repository.VisitorRepositories;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitorController : Controller
    {
        IVisitorRepository _visitorRepo;
        public VisitorController(IVisitorRepository visitorRepository) 
        { 
            this._visitorRepo = visitorRepository;
        }
        [HttpGet]
        public JsonResult Get()
        {
            QueryOption<Visitor> queryOption = new QueryOption<Visitor>();
            queryOption.SortBy =(x=>x.ID);
            queryOption.Take = 2;
            List<Visitor> visitors = _visitorRepo.GetAll(queryOption);
            return Json(visitors);
        }
    }
}

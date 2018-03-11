using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Threading.Tasks;
using API.Infrastructure.PlanExecute;
using AutoMapper;
using Domain.Blogs.DTO;
using Domain.Infrastructure.GenericHandlers;
using Repositories;
using UnitOfWork;
using UnitOfWork.PagedList;
using ILogger = Serilog.ILogger;


namespace API.Controllers
{
    [Route("api/[controller]")]
    public class HomeController
    {
        public HomeController()
        {
        }

        [HttpGet]
        public string Get()
        {
            return "API started";
        }
    }
}

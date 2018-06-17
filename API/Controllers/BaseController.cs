using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UnitOfWork;

namespace API.Controllers
{
    public class BaseController : Controller
    {
        public IUnitOfWork Uow { get; }
        public IMapper Map { get; }

        public BaseController(IMapper mapper,
                IUnitOfWork uow)
        {
            Map = mapper;
            Uow = uow;
        }

        [HttpGet]
        public string Index()
            => "Api Started";
    }
}

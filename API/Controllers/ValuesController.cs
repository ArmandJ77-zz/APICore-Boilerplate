using Microsoft.AspNetCore.Mvc;
using Repositories;
using System.Collections.Generic;
using System.Linq;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        public DatabaseContext _context { get; set; }
        public ValuesController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Blog> Get()
        {
            return _context.Blog.ToList();
        }
    }
}

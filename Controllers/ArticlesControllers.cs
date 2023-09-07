using Microsoft.AspNetCore.Mvc;
using MonApiMSSQL.Models;
using System.Linq;

namespace MonApiMSSQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ArticlesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Articles
        [HttpGet]
        public IActionResult GetArticles()
        {
            var articles = _context.Articles.ToList();
            return Ok(articles);
        }
    }
}

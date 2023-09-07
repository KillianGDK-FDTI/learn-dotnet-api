using Microsoft.AspNetCore.Mvc;
using MonApiMSSQL.Models;

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

        // GET: api/Articles/5
        [HttpGet("id")]
        public IActionResult GetArticleById(int id)
        {
            var article = _context.Articles.FirstOrDefault(a => a.Id == id);
            if (article == null)
            {
                return NotFound("L'article n'existe pas");
            }
            return Ok(article);
        }

        // POST: api/Articles
        [HttpPost]
        public IActionResult PostArticles([FromBody] Article article)
        {
            if (article == null)
            {
                return BadRequest("L'article est vide");
            }

            _context.Articles.Add(article);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetArticleById), new { id = article.Id }, article);
        }
    }
}

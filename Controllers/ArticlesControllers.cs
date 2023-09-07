using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var articles = _context.Articles.Include(article => article.User).ToList();
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

            // Vérifiez si l'utilisateur associé à l'article existe
            var userExists = _context.Users.Any(u => u.Id == article.UserId);
            if (!userExists)
            {
                return BadRequest("L'utilisateur spécifié n'existe pas");
            }

            _context.Articles.Add(article);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetArticleById), new { id = article.Id }, article);
        }

        // DELETE api/Articles
        [HttpDelete]
        public IActionResult DeleteArticles()
        {
            _context.Articles.RemoveRange(_context.Articles);
            _context.SaveChanges();

            return Ok("Tous les articles ont été supprimés");
        }


        // DELETE: api/Articles/5
        [HttpDelete("{id}")]
        public IActionResult DeleteArticle(int id)
        {
            var article = _context.Articles.FirstOrDefault(a => a.Id == id);
            if (article == null)
            {
                return NotFound("L'article n'existe pas");
            }

            _context.Articles.Remove(article);
            _context.SaveChanges();

            return Ok("L'article a été supprimé");
        }
    }
}

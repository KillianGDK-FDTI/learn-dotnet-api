using MediatR;
using Microsoft.EntityFrameworkCore;
using MonApiMSSQL.Models;
using MonApiMSSQL.Queries;
using MonApiMSSQL.DTOs;

namespace MonApiMSSQL.Handlers
{
    public class GetAllBlogQueryHandler : IRequestHandler<GetAllBlogsQuery, List<BlogDto>>
    {
        private readonly AppDbContext _context;

        public GetAllBlogQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<BlogDto>> Handle(GetAllBlogsQuery request, CancellationToken cancellationToken)
        {
            var blogs = await _context.Blogs.Include(b => b.User).ToListAsync();

            return blogs.Select(b => new BlogDto
            {
                Id = b.Id,
                Titre = b.Titre,
                Contenu = b.Contenu,
                UserId = b.UserId,
                UserName = b.User?.Username // Assurez-vous que la classe User a une propriété Name
            }).ToList();
        }
    }
}

using MediatR;
using Microsoft.EntityFrameworkCore;
using MonApiMSSQL.Models;
using MonApiMSSQL.Queries;

namespace MonApiMSSQL.Handlers
{
    public class GetAllBlogsHandler : IRequestHandler<GetAllBlogsQuery, List<Blog>>
    {
        private readonly AppDbContext _context;

        public GetAllBlogsHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Blog>> Handle(GetAllBlogsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Blogs.Include(b => b.User).ToListAsync();
        }
    }
}

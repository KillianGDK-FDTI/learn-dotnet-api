using MediatR;
using Microsoft.EntityFrameworkCore;
using MonApiMSSQL.Models;
using MonApiMSSQL.Queries;

namespace MonApiMSSQL.Handlers
{
    public class GetBlogByIdHandler : IRequestHandler<GetBlogByIdQuery, Blog>
    {
        private readonly AppDbContext _context;

        public GetBlogByIdHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Blog> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Blogs.Include(b => b.User)
                                       .FirstOrDefaultAsync(b => b.Id == request.Id);
        }
    }
}

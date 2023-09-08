using MediatR;
using MonApiMSSQL.Models;
using MonApiMSSQL.Commands;

namespace MonApiMSSQL.Handlers
{
    public class CreateBlogHandler : IRequestHandler<CreateBlogCommand, Blog>
    {
        private readonly AppDbContext _context;

        public CreateBlogHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Blog> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.Titre) || string.IsNullOrEmpty(request.Contenu))
            {
                // Gérez l'erreur comme vous le souhaitez, par exemple en levant une exception.
                throw new ArgumentException("Titre et Contenu ne peuvent pas être null ou vides.");
            }

            var blog = new Blog

            {
                Titre = request.Titre,
                Contenu = request.Contenu,
                UserId = request.UserId
            };

            _context.Blogs.Add(blog);
            await _context.SaveChangesAsync();

            return blog;
        }
    }
}

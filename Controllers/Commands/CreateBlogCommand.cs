using MediatR;
using MonApiMSSQL.Models;

namespace MonApiMSSQL.Commands
{
    public class CreateBlogCommand : IRequest<Blog>
    {
        public string? Titre { get; set; } = null!;
        public string? Contenu { get; set; } = null!;
        public int UserId { get; set; }
    }
}

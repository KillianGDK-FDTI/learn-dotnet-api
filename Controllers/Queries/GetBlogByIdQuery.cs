using MediatR;
using MonApiMSSQL.Models;

namespace MonApiMSSQL.Queries
{
    public class GetBlogByIdQuery : IRequest<Blog>
    {
        public int Id { get; set; }

        public GetBlogByIdQuery(int id)
        {
            Id = id;
        }
    }
}

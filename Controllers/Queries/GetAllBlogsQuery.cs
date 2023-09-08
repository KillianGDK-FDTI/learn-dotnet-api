using MediatR;
using MonApiMSSQL.Models;

namespace MonApiMSSQL.Queries
{
    public class GetAllBlogsQuery : IRequest<List<Blog>>
    {
    }
}

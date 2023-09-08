using MediatR;
using MonApiMSSQL.Models;
using MonApiMSSQL.DTOs;

namespace MonApiMSSQL.Queries
{
    public class GetAllBlogsQuery : IRequest<List<BlogDto>>
    {
    }
}

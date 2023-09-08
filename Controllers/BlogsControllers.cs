using MediatR;
using Microsoft.AspNetCore.Mvc;
using MonApiMSSQL.Queries;

[ApiController]
[Route("api/[controller]")]
public class BlogsController : ControllerBase
{
    private readonly IMediator _mediator;

    public BlogsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllBlogs()
    {
        var blogs = await _mediator.Send(new GetAllBlogsQuery());
        return Ok(blogs);
    }
}

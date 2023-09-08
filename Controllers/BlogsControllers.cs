using MediatR;
using Microsoft.AspNetCore.Mvc;
using MonApiMSSQL.Queries;
using MonApiMSSQL.Commands;

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

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBlogById(int id)
    {
        var blog = await _mediator.Send(new GetBlogByIdQuery(id));

        if (blog == null)
        {
            return NotFound("Blog not found");
        }

        return Ok(blog);
    }

    [HttpPost]
    public async Task<IActionResult> CreateBlog(CreateBlogCommand command)
    {
        var blog = await _mediator.Send(command);

        return CreatedAtAction(nameof(GetBlogById), new { id = blog.Id }, blog);
    }

}

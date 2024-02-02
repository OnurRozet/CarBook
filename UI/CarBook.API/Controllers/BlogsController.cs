using CarBook.Application.Features.Mediator.Commands.BlogCommands;
using CarBook.Application.Features.Mediator.Handlers.FeatureHandlers;
using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly IMediator _metiator;

        public BlogsController(IMediator metiator)
        {
            _metiator = metiator;
        }

        [HttpGet]

        public async Task<IActionResult> BlogList()
        {
            var values = await _metiator.Send(new GetBlogQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> BlogById(int id)
        {
            var values = await _metiator.Send(new GetBlogByIdQuery(id));
            return Ok(values);
        }

        [HttpGet("GetBlogWithAuthorId")]

        public async Task<IActionResult> GetBlogWithAuthorIdv(int id)
        {
            var values = await _metiator.Send(new GetBlogWithAuthorIdQuery(id));
            return Ok(values);
        }
        
        [HttpPost]

        public async Task<IActionResult> CreateBlog(CreateBlogCommand command)
        {
            await _metiator.Send(command);
            return Ok(command);
        }

        [HttpPut]

        public async Task<IActionResult> UpdateBlog(UpdateBlogCommand command)
        {
            await _metiator.Send(command);
            return Ok(command);
        }

        [HttpDelete("id")]

        public async Task<IActionResult> DeleteBlog(int id )
        {
            await _metiator.Send(new RemoveBlogCommand(id));
            return Ok("Blog Silinmiştir");
        }

        [HttpGet("GetLast3BlogsWithAuthor")]

        public async Task<IActionResult> GetLast3BlogsWithAuthor()
        {
          var values =  await _metiator.Send(new GetLast3BlogsWithAuthorQuery());
            return Ok(values);
        }

		[HttpGet("GetAllBlogsWithAuthor")]

		public async Task<IActionResult> GetAllBlogsWİthAuthor()
		{
			var values = await _metiator.Send(new GetAllBlogsWithAuthorQuery());
			return Ok(values);
		}
	}
}

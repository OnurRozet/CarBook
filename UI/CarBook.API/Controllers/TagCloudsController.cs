using CarBook.Application.Features.Mediator.Commands.TagCloudCommands;
using CarBook.Application.Features.Mediator.Handlers.FeatureHandlers;
using CarBook.Application.Features.Mediator.Queries.TagCloudQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TagCloudsController : ControllerBase
	{
		private readonly IMediator _metiator;

		public TagCloudsController(IMediator metiator)
		{
			_metiator = metiator;
		}

		[HttpGet]

		public async Task<IActionResult> TagCloudList()
		{
			var values = await _metiator.Send(new GetTagCloudQuery());
			return Ok(values);
		}

		[HttpGet("{id}")]

		public async Task<IActionResult> TagCloudById(int id)
		{
			var values = await _metiator.Send(new GetTagCloudByIdQuery(id));
			return Ok(values);
		}

        [HttpGet("GetTagCloudWithBlogs")]

        public async Task<IActionResult> TagCloudById()
        {
            var values = await _metiator.Send(new GetTagCloudWithBlogsQuery());
            return Ok(values);
        }

        [HttpGet("GetTagCloudWithByBlogId")]

        public async Task<IActionResult> GetTagCloudByBlogId(int id)
        {
            var values = await _metiator.Send(new GetTagCloudWithByBlogIdQuery(id));
            return Ok(values);
        }

        [HttpPost]

		public async Task<IActionResult> CreateTagCloud(CreateTagCloudCommand command)
		{
			await _metiator.Send(command);
			return Ok(command);
		}

		[HttpPut]

		public async Task<IActionResult> UpdateTagCloud(UpdateTagCloudCommand command)
		{
			await _metiator.Send(command);
			return Ok(command);
		}

		[HttpDelete]

		public async Task<IActionResult> DeleteTagCloud(RemoveTagCloudCommand command)
		{
			await _metiator.Send(command);
			return Ok(command);
		}
	}
}

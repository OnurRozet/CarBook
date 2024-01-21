using CarBook.Application.Features.Mediator.Commands.SocialMediaCommands;
using CarBook.Application.Features.Mediator.Handlers.FeatureHandlers;
using CarBook.Application.Features.Mediator.Queries.SocialMediaQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SocialMediasController : ControllerBase
	{
		private readonly IMediator _metiator;

		public SocialMediasController(IMediator metiator)
		{
			_metiator = metiator;
		}

		[HttpGet]

		public async Task<IActionResult> SocialMediaList()
		{
			var values = await _metiator.Send(new GetSocialMediaQuery());
			return Ok(values);
		}

		[HttpGet("{id}")]

		public async Task<IActionResult> SocialMediaById(int id)
		{
			var values = await _metiator.Send(new GetSocialMediaByIdQuery(id));
			return Ok(values);
		}

		[HttpPost]

		public async Task<IActionResult> CreateSocialMedia(CreateSocialMediaCommand command)
		{
			await _metiator.Send(command);
			return Ok(command);
		}

		[HttpPut]

		public async Task<IActionResult> UpdateSocialMedia(UpdateSocialMediaCommand command)
		{
			await _metiator.Send(command);
			return Ok(command);
		}

		[HttpDelete]

		public async Task<IActionResult> DeleteSocialMedia(RemoveSocialMediaCommand command)
		{
			await _metiator.Send(command);
			return Ok(command);
		}
	}
}

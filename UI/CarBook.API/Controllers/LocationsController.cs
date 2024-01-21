using CarBook.Application.Features.Mediator.Commands.LocationCommands;
using CarBook.Application.Features.Mediator.Handlers.FeatureHandlers;
using CarBook.Application.Features.Mediator.Queries.LocationQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LocationController : ControllerBase
	{
		private readonly IMediator _metiator;

		public LocationController(IMediator metiator)
		{
			_metiator = metiator;
		}

		[HttpGet]

		public async Task<IActionResult> LocationList()
		{
			var values = await _metiator.Send(new GetLocationQuery());
			return Ok(values);
		}

		[HttpGet("{id}")]

		public async Task<IActionResult> LocationById(int id)
		{
			var values = await _metiator.Send(new GetLocationByIdQuery(id));
			return Ok(values);
		}

		[HttpPost]

		public async Task<IActionResult> CreateLocation(CreateLocationCommand command)
		{
			await _metiator.Send(command);
			return Ok(command);
		}

		[HttpPut]

		public async Task<IActionResult> UpdateLocation(UpdateLocationCommand command)
		{
			await _metiator.Send(command);
			return Ok(command);
		}

		[HttpDelete]

		public async Task<IActionResult> DeleteLocation(RemoveLocationCommand command)
		{
			await _metiator.Send(command);
			return Ok(command);
		}
	}
}

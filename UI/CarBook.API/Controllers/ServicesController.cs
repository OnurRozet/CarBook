using CarBook.Application.Features.Mediator.Commands.ServicesCommands;
using CarBook.Application.Features.Mediator.Handlers.FeatureHandlers;
using CarBook.Application.Features.Mediator.Queries.ServicesQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ServicesController : ControllerBase
	{
		private readonly IMediator _metiator;

		public ServicesController(IMediator metiator)
		{
			_metiator = metiator;
		}

		[HttpGet]

		public async Task<IActionResult> ServicesList()
		{
			var values = await _metiator.Send(new GetServicesQuery());
			return Ok(values);
		}

		[HttpGet("{id}")]

		public async Task<IActionResult> ServicesById(int id)
		{
			var values = await _metiator.Send(new GetServicesByIdQuery(id));
			return Ok(values);
		}

		[HttpPost]

		public async Task<IActionResult> CreateServices(CreateServicesCommand command)
		{
			await _metiator.Send(command);
			return Ok(command);
		}

		[HttpPut]

		public async Task<IActionResult> UpdateServices(UpdateServicesCommand command)
		{
			await _metiator.Send(command);
			return Ok(command);
		}

		[HttpDelete("{id}")]

		public async Task<IActionResult> DeleteServices( int id)
		{
			await _metiator.Send(new RemoveServicesCommand(id));
			return Ok("Hizmet Bilgisi Silindi");
		}
	}
}

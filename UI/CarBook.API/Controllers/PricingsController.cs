using CarBook.Application.Features.Mediator.Commands.PricingCommands;
using CarBook.Application.Features.Mediator.Handlers.FeatureHandlers;
using CarBook.Application.Features.Mediator.Queries.PricingQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PricingsController : ControllerBase
	{
		private readonly IMediator _metiator;

		public PricingsController(IMediator metiator)
		{
			_metiator = metiator;
		}

		[HttpGet]

		public async Task<IActionResult> PricingList()
		{
			var values = await _metiator.Send(new GetPricingQuery());
			return Ok(values);
		}

		[HttpGet("{id}")]

		public async Task<IActionResult> PricingById(int id)
		{
			var values = await _metiator.Send(new GetPricingByIdQuery(id));
			return Ok(values);
		}

		[HttpPost]

		public async Task<IActionResult> CreatePricing(CreatePricingCommand command)
		{
			await _metiator.Send(command);
			return Ok(command);
		}

		[HttpPut]

		public async Task<IActionResult> UpdatePricing(UpdatePricingCommand command)
		{
			await _metiator.Send(command);
			return Ok(command);
		}

		[HttpDelete("{id}")]

		public async Task<IActionResult> DeletePricings(int id )
		{
			await _metiator.Send(new RemovePricingCommand(id));
			return Ok("Ödeme Türü Silinmiştir.");
		}
	}
}

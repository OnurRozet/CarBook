using CarBook.Application.Features.Mediator.Handlers.CarPricingHandlers;
using CarBook.Application.Features.Mediator.Queries.CarPricingQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CarPricingsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public CarPricingsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet("GetCarPricingWithCar")]

		public async Task<IActionResult> GetCarPricingWithCarList()
		{
			var values = await _mediator.Send(new GetCarPricingWithCarQuery());
			return Ok(values);
		}

	}
}

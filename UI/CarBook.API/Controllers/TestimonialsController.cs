using CarBook.Application.Features.Mediator.Commands.TestimonialCommands;
using CarBook.Application.Features.Mediator.Handlers.FeatureHandlers;
using CarBook.Application.Features.Mediator.Queries.TestimonialQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TestimonialsController : ControllerBase
	{
		private readonly IMediator _metiator;

		public TestimonialsController(IMediator metiator)
		{
			_metiator = metiator;
		}

		[HttpGet]

		public async Task<IActionResult> TestimonialList()
		{
			var values = await _metiator.Send(new GetTestimonialQuery());
			return Ok(values);
		}

		[HttpGet("{id}")]

		public async Task<IActionResult> TestimonialById(int id)
		{
			var values = await _metiator.Send(new GetTestimonialByIdQuery(id));
			return Ok(values);
		}

		[HttpPost]

		public async Task<IActionResult> CreateTestimonial(CreateTestimonialCommand command)
		{
			await _metiator.Send(command);
			return Ok(command);
		}

		[HttpPut]

		public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialCommand command)
		{
			await _metiator.Send(command);
			return Ok(command);
		}

		[HttpDelete]

		public async Task<IActionResult> DeleteTestimonial(RemoveTestimonialCommand command)
		{
			await _metiator.Send(command);
			return Ok(command);
		}
	}
}

using CarBook.Application.Features.Mediator.Commands.FooterAddressCommands;
using CarBook.Application.Features.Mediator.Handlers.FeatureHandlers;
using CarBook.Application.Features.Mediator.Queries.FooterAddressQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FooterAddressController : ControllerBase
	{
		private readonly IMediator _metiator;

		public FooterAddressController(IMediator metiator)
		{
			_metiator = metiator;
		}

		[HttpGet]

		public async Task<IActionResult> FooterAddressList()
		{
			var values = await _metiator.Send(new GetFooterAddressQuery());
			return Ok(values);
		}

		[HttpGet("{id}")]

		public async Task<IActionResult> FooterAddressById(int id)
		{
			var values = await _metiator.Send(new GetFooterAddressByIdQuery(id));
			return Ok(values);
		}

		[HttpPost]

		public async Task<IActionResult> CreateFooterAddress(CreateFooterAddressCommand command)
		{
			await _metiator.Send(command);
			return Ok(command);
		}

		[HttpPut]

		public async Task<IActionResult> UpdateFooterAddress(UpdateFooterAddressCommand command)
		{
			await _metiator.Send(command);
			return Ok(command);
		}

		[HttpDelete("{id}")]

		public async Task<IActionResult> DeleteFooterAddress( int id)
		{

			await _metiator.Send(new RemoveFooterAddressCommand(id));
			return Ok("Adres Silinmiştir.");
		}
	}
}

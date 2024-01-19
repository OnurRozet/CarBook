﻿using CarBook.Application.Features.Mediator.Commands.FeatureCommands;
using CarBook.Application.Features.Mediator.Handlers.FeatureHandlers;
using CarBook.Application.Features.Mediator.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FeaturesController : ControllerBase
	{
		private readonly IMediator _mediator;

		public FeaturesController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]

		public async Task<IActionResult> FeatureList()
		{
			var values = await _mediator.Send(new GetFeatureQuery());
			return Ok(values);
		}

		[HttpGet("{id}")]

		public async Task<IActionResult> FeatureById(int id)
		{
			var values = await _mediator.Send(new GetFeatureByIdQuery(id));
			return Ok(values);
		}

		[HttpPost]

		public async Task<IActionResult> CreateFeature(CreateFeatureCommand command)
		{
			await _mediator.Send(command);
			return Ok(command);
		}

		[HttpPut]

		public async Task<IActionResult> UpdateFeature(UpdateFeatureCommand command)
		{
			await _mediator.Send(command);
			return Ok(command);
		}

		[HttpDelete]

		public async Task<IActionResult> RemoveFeature(int id)
		{
			await _mediator.Send(new RemoveFeatureCommand(id));
			return Ok("Özellik başarılı bir şekilde silindi");
		}
	}
}
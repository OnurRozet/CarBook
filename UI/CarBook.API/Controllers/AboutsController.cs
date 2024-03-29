﻿using CarBook.Application.Features.CQRS.Commands.AboutCommand;
using CarBook.Application.Features.CQRS.Handlers.AboutHandlers;
using CarBook.Application.Features.CQRS.Queries;
using CarBook.Application.Features.CQRS.Queries.AboutQueries;
using CarBook.Application.Features.CQRS.Results.AboutResults;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.API.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class AboutsController : ControllerBase
	{
		private readonly CreateAboutCommandHandler _createAboutCommandHandler;
		private readonly UpdateAboutCommandHandler _updateAboutCommandHandler;
		private readonly RemoveAboutCommandHandler _removeAboutCommandHandler;
		private readonly GetAboutQueryHandler _getAboutQueryHandler;
		private readonly GetAboutByIdQueryHandler _getAboutByIdQueryHandler;

		public AboutsController(CreateAboutCommandHandler createAboutCommandHandler, UpdateAboutCommandHandler updateAboutCommandHandler, RemoveAboutCommandHandler removeAboutCommandHandler, GetAboutQueryHandler getAboutQueryHandler, GetAboutByIdQueryHandler getAboutByIdQueryHandler)
		{
			_createAboutCommandHandler = createAboutCommandHandler;
			_updateAboutCommandHandler = updateAboutCommandHandler;
			_removeAboutCommandHandler = removeAboutCommandHandler;
			_getAboutQueryHandler = getAboutQueryHandler;
			_getAboutByIdQueryHandler = getAboutByIdQueryHandler;
		}


		[HttpGet]

		public async Task<IActionResult> AboutList()
		{
			var values = await _getAboutQueryHandler.Handle();
			return Ok(values);
		}

		[HttpGet("{id}")]

		public async Task<IActionResult> ABoutById(int id)
		{
			var value = await _getAboutByIdQueryHandler.Handle(new GetAboutByIdQuery(id));
			return Ok(value);
		}

		[HttpPost]
		
		public async Task<IActionResult> CreateAbout(CreateAboutCommand command)
		{
			await _createAboutCommandHandler.Handle(command);
			return Ok(command);
		}

		[HttpDelete("{id}")]

		public async Task<IActionResult> RemoveAbout(int id)
		{
			 await _removeAboutCommandHandler.Handle(new RemoveAboutCommand(id));

			return Ok("hakkımda Bilgisi Silindi");
		}


		[HttpPut]

		public async Task<IActionResult> UpdateAbout(UpdateAboutCommand command)
		{
		  	await _updateAboutCommandHandler.Handle(command);

			return Ok(command);
		}



	}
}

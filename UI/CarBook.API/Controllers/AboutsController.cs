using CarBook.Application.Features.CQRS.Handlers;
using CarBook.Application.Features.CQRS.Queries;
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

		public AboutsController(CreateAboutCommandHandler createAboutCommandHandler, UpdateAboutCommandHandler updateAboutCommandHandler, RemoveAboutCommandHandler removeAboutCommandHandler, GetAboutQueryHandler getAboutQueryHandler)
		{
			_createAboutCommandHandler = createAboutCommandHandler;
			_updateAboutCommandHandler = updateAboutCommandHandler;
			_removeAboutCommandHandler = removeAboutCommandHandler;
			_getAboutQueryHandler = getAboutQueryHandler;
		}

		[HttpGet]

		

		
	}
}

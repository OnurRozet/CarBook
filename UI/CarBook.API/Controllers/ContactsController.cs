using CarBook.Application.Features.CQRS.Commands.ContactCommand;
using CarBook.Application.Features.CQRS.Handlers.ContactHandlers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ContactsController : ControllerBase
	{
		private readonly CreateContactCommandHandler _createContactCommandHandler;
		private readonly UpdateContactCommandHandler _updateContactCommandHandler;
		private readonly RemoveContactCommandHandler _removeContactCommandHandler;
		private readonly GetContactQueryHandler _getContactQueryHandler;
		private readonly GetContactByIdQueryHandler _getContactByIdQueryHandler;

		public ContactsController(CreateContactCommandHandler createContactCommandHandler, UpdateContactCommandHandler updateContactCommandHandler, RemoveContactCommandHandler removeContactCommandHandler, GetContactQueryHandler getContactQueryHandler, GetContactByIdQueryHandler getContactByIdQueryHandler)
		{
			_createContactCommandHandler = createContactCommandHandler;
			_updateContactCommandHandler = updateContactCommandHandler;
			_removeContactCommandHandler = removeContactCommandHandler;
			_getContactQueryHandler = getContactQueryHandler;
			_getContactByIdQueryHandler = getContactByIdQueryHandler;
		}

		[HttpGet]

		public async Task<IActionResult> ContactList()
		{
			var values = await _getContactQueryHandler.Handle();
			return Ok(values);
		}

		[HttpGet("{id}")]

		public async Task<IActionResult> ContactById(int id)
		{
			var value = await _getContactByIdQueryHandler.Handle(new Application.Features.CQRS.Queries.ContactQueries.GetContactByIdQuery(id));
			return Ok(value);
		}

		[HttpPut]

		public async Task<IActionResult> UpdateContact(UpdateContactCommand command)
		{
			await _updateContactCommandHandler.Handle(command);
			return Ok(command);
		}

		[HttpPost]

		public async Task<IActionResult> CreateContact(CreateContactCommand command)
		{
			await _createContactCommandHandler.Handle(command);
			return Ok(command);
		}

		[HttpDelete]

		public async Task<IActionResult> RemoveContact(RemoveContactCommand command)
		{
			await _removeContactCommandHandler.Handle(command);
			return Ok(command);
		}
	}
}

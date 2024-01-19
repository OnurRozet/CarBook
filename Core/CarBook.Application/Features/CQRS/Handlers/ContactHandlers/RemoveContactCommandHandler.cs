using CarBook.Application.Features.CQRS.Commands.ContactCommand;
using CarBook.Application.Interfaces;
using CarBook.Domanin.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.ContactHandlers
{
	public class RemoveContactCommandHandler
	{
		private readonly IRepository<Contact> _repository;

		public RemoveContactCommandHandler(IRepository<Contact> repository)
		{
			_repository = repository;
		}

		public async Task Handle(RemoveContactCommand command)
		{
			var entity = await _repository.GetByIdAsync(command.Id);
			await _repository.DeleteAsync(entity);

		}
	}
}

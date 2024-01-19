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
	public class UpdateContactCommandHandler
	{
		private readonly IRepository<Contact> _repository;

		public UpdateContactCommandHandler(IRepository<Contact> repository)
		{
			_repository = repository;
		}

		public async Task Handle(UpdateContactCommand command)
		{
			var entity = await _repository.GetByIdAsync(command.ContactId);
			entity.SendDate= command.SendDate;
			entity.Email= command.Email;
			entity.Subject= command.Subject;
			entity.Message= command.Message;
			entity.Name= command.Name;
			await _repository.UpdateAsync(entity);

		}
	}
}

using CarBook.Application.Features.CQRS.Commands.CarCommand;
using CarBook.Application.Interfaces;
using CarBook.Domanin.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
	public class RemoveCarCommandHandler
	{
		private readonly IRepository<Car> _repository;

		public RemoveCarCommandHandler(IRepository<Car> repository)
		{
			_repository = repository;
		}

		public async Task Handle(RemoveCarCommand command)
		{
			var entity = await _repository.GetByIdAsync(command.Id);
			await _repository.DeleteAsync(entity);

		}
	}
}

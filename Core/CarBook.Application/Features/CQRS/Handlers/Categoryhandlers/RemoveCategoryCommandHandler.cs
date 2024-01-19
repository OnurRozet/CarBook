using CarBook.Application.Features.CQRS.Commands.CategoryCommand;
using CarBook.Application.Interfaces;
using CarBook.Domanin.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.Categoryhandlers
{
	public class RemoveCategoryCommandHandler
	{
		private readonly IRepository<Category> _repository;

		public RemoveCategoryCommandHandler(IRepository<Category> repository)
		{
			_repository = repository;
		}

		public async Task Handle(RemoveCategoryCommand command)
		{
			var entity = await _repository.GetByIdAsync(command.Id);
			await _repository.DeleteAsync(entity);

		}
	}
}

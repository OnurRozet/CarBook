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
	public class UpdateCategoryCommandHandler
	{
		private readonly IRepository<Category> _repository;

		public UpdateCategoryCommandHandler(IRepository<Category> repository)
		{
			_repository = repository;
		}

		public async Task Handle(UpdateCategoryCommand command)
		{
			var entity = await _repository.GetByIdAsync(command.CategoryId);
			entity.CategoyName = command.CategoyName;
			await _repository.UpdateAsync(entity);

		}
	}
}

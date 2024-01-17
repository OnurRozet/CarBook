using CarBook.Application.Features.CQRS.Commands.BrandCommand;
using CarBook.Application.Interfaces;
using CarBook.Domanin.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.BrandHandlers
{
	public class UpdateBrandCommandHandler
	{
		private readonly IRepository<Brand> _repository;

		public UpdateBrandCommandHandler(IRepository<Brand> repository)
		{
			_repository = repository;
		}

		public async Task Handle(UpdateBrandCommand command)
		{
			var entity = await _repository.GetByIdAsync(command.Id);
			entity.BrandName = command.BrandName;
			await _repository.UpdateAsync(entity);
	
		}
	}
}

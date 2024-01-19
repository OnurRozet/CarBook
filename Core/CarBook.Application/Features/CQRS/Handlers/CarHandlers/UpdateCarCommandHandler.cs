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
	public class UpdateCarCommandHandler
	{
		private readonly IRepository<Car> _repository;

		public UpdateCarCommandHandler(IRepository<Car> repository)
		{
			_repository = repository;
		}

		public async Task Handle(UpdateCarCommand command)
		{
			var entity = await _repository.GetByIdAsync(command.Id);
			entity.Transmission = command.Transmission;
			entity.BigImageUrl = command.BigImageUrl;
			entity.Km=command.Km;
			entity.BigImageUrl=command.BigImageUrl;
			entity.Luggage=command.Luggage;
			entity.Fuel=command.Fuel;
			entity.BrandId=command.BrandId;
			entity.CoverImageUrl=command.CoverImageUrl;
			await _repository.UpdateAsync(entity);

		}
	}
}

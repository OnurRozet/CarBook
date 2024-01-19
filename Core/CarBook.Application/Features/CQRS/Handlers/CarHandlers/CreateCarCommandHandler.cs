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
	public class CreateCarCommandHandler
	{
		private readonly IRepository<Car> _repository;

		public CreateCarCommandHandler(IRepository<Car> repository)
		{
			_repository = repository;
		}

		public async Task Handle(CreateCarCommand command)
		{
			await _repository.CreateAsync(new Car
			{
				Km = command.Km,
				Luggage = command.Luggage,
				Model = command.Model,
				Seat = command.Seat,
				Transmission = command.Transmission,
				Fuel = command.Fuel,
				CoverImageUrl = command.CoverImageUrl,
				BigImageUrl = command.BigImageUrl,
				BrandId = command.BrandId,

			});

		}
	}
}

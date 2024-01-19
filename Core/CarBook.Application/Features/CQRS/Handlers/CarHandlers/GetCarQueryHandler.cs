using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces;
using CarBook.Domanin.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
	public class GetCarQueryHandler
	{
		private readonly IRepository<Car> _repository;

		public GetCarQueryHandler(IRepository<Car> repository)
		{
			_repository = repository;
		}

		public async Task<List<GetCarQueryResult>> Handle()
		{
			var entity = await _repository.GetAllAsync();
			return entity.Select(x => new GetCarQueryResult
			{
				CoverImageUrl = x.CoverImageUrl,
				BrandId = x.BrandId,
				BigImageUrl = x.BigImageUrl,
				Fuel = x.Fuel,
				Luggage = x.Luggage,
				Km = x.Km,
				Model = x.Model,
				Seat = x.Seat,
				Transmission = x.Transmission,
				Id = x.Id,
			}).ToList();

		}
	}
}

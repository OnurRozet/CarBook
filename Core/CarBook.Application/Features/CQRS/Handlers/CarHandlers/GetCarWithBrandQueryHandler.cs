using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Domanin.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
	public class GetCarWithBrandQueryHandler
	{
		private readonly ICarRepository _repository;

		public GetCarWithBrandQueryHandler(ICarRepository repository)
		{
			_repository = repository;
		}

		public  List<GetCarWithBrandQueryResult> Handle()
		{
			var value =  _repository.GetCarWithBrand();

			return value.Select(x => new GetCarWithBrandQueryResult
			{
				BigImageUrl = x.BigImageUrl,
				BrandId = x.BrandId,
				CoverImageUrl = x.CoverImageUrl,
				Fuel=x.Fuel,
				Km=x.Km,
				Luggage=x.Luggage,
				Model=x.Model,
				Transmission=x.Transmission,
				Seat=x.Seat,
				BrandName=x.Brand.BrandName,
				Id=x.Id,
				
			}).ToList();
		}
	}
}

using CarBook.Application.Features.Mediator.Queries.CarPricingQueries;
using CarBook.Application.Features.Mediator.Results.CarPricingResult;
using CarBook.Application.Interfaces.CarPricingInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.CarPricingHandlers
{
	public class GetCarPricingWithCarQueryHandler : IRequestHandler<GetCarPricingWithCarQuery,List<GetCarPricingWithCarResult>>
	{
		private readonly ICarPricingRepository _carPricingRepository;

		public GetCarPricingWithCarQueryHandler(ICarPricingRepository carPricingRepository)
		{
			_carPricingRepository = carPricingRepository;
		}

		public  async Task<List<GetCarPricingWithCarResult>> Handle(GetCarPricingWithCarQuery request, CancellationToken cancellationToken)
		{
			var values =   _carPricingRepository.GetCarWithPricing();
			return values.Select(x => new GetCarPricingWithCarResult
			{
				Amount = x.Amount,
				Model=x.Car.Model,
				CarId=x.CarId,
				CarPricingId=x.CarPricingId,
				CoverImageUrl = x.Car.CoverImageUrl,
				BrandName=x.Car.Brand.BrandName
			}).ToList();
		}
	}
}

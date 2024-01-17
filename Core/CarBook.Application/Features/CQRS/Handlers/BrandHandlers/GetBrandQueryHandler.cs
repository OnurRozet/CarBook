using CarBook.Application.Features.CQRS.Commands.BrandCommand;
using CarBook.Application.Features.CQRS.Results.BannerResults;
using CarBook.Application.Features.CQRS.Results.BrandResults;
using CarBook.Application.Interfaces;
using CarBook.Domanin.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.BrandHandlers
{
	public class GetBrandQueryHandler
	{
		private readonly IRepository<Brand> _repository;

		public GetBrandQueryHandler(IRepository<Brand> repository)
		{
			_repository = repository;
		}

		public async Task<List<GetBrandQueryResult>> Handle()
		{
			var entity = await _repository.GetAllAsync();
			return entity.Select(x=> new GetBrandQueryResult
			{
				BrandId = x.BrandId,
				BrandName = x.BrandName,
				
			}).ToList();

		}
	}
}

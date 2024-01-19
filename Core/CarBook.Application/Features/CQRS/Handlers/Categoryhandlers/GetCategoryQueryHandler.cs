using CarBook.Application.Features.CQRS.Results.CategoryResults;
using CarBook.Application.Interfaces;
using CarBook.Domanin.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.Categoryhandlers
{
	public class GetCategoryQueryHandler
	{
		private readonly IRepository<Category> _repository;

		public GetCategoryQueryHandler(IRepository<Category> repository)
		{
			_repository = repository;
		}

		public async Task<List<GetCategoryQueryResult>> Handle()
		{
			var entity = await _repository.GetAllAsync();
			return entity.Select(x => new GetCategoryQueryResult
			{
				CategoryId = x.CategoryId,
				CategoyName = x.CategoyName,

			}).ToList();

		}
	}
}

using CarBook.Application.Features.CQRS.Queries.CategoryQueries;
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
	public class GetCategoryByIdQueryHandler
	{
		private readonly IRepository<Category> _repository;

		public GetCategoryByIdQueryHandler(IRepository<Category> repository)
		{
			_repository = repository;
		}

		public async Task<GetCategoryByIdQueryResult> Handle(GetCategoryByIdQuery query)
		{
			var value = await _repository.GetByIdAsync(query.Id);

			return new GetCategoryByIdQueryResult
			{
				CategoryId = value.CategoryId,
				CategoyName = value.CategoyName,
			};

		}
	}
}

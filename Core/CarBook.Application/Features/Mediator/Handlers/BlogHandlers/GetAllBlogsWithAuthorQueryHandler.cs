using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Application.Interfaces.BlogInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers
{
	public class GetAllBlogsWithAuthorQueryHandler:IRequestHandler<GetAllBlogsWithAuthorQuery,List<GetAllBlogsWithAuthorQueryResult>>
	{
		private readonly IBlogRepository _repository;

		public GetAllBlogsWithAuthorQueryHandler(IBlogRepository repository)
		{
			_repository = repository;
		}

		public async Task<List<GetAllBlogsWithAuthorQueryResult>> Handle(GetAllBlogsWithAuthorQuery request, CancellationToken cancellationToken)
		{
			var result = _repository.GetALlBlogsWithAuthor();
			return result.Select(x => new GetAllBlogsWithAuthorQueryResult
			{
				AuthorID = x.AuthorID,
				AuthorName = x.Author.Name,
				CategoryID = x.CategoryID,
				CategoryName=x.Category.CategoyName,
				CoverImageUrl = x.CoverImageUrl,
				BlogID = x.BlogID,
				CreatedDate = x.CreatedDate,
				Title = x.Title,
				Description= x.Description,
			}).ToList();
		}
	}
}

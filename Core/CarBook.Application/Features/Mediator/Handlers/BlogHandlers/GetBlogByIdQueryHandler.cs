
using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Application.Interfaces;
using CarBook.Domanin.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Blogs.Mediator.Handlers.BlogHandlers
{
    public class GetBlogByIdQueryHandler : IRequestHandler<GetBlogByIdQuery, GetBlogQueryResult>
	{
		private readonly IRepository<Blog> _repository;

		public GetBlogByIdQueryHandler(IRepository<Blog> repository)
		{
			_repository = repository;
		}
		public async Task<GetBlogQueryResult> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
		{
			var value = await _repository.GetByIdAsync(request.Id);
			return new GetBlogQueryResult
			{
             AuthorID = value.AuthorID,
			 Title = value.Title,
			 Description = value.Description,
			 CreatedDate = value.CreatedDate,
			 CategoryID = value.CategoryID,
			 CoverImageUrl = value.CoverImageUrl,
			 BlogID = value.BlogID
            };
		}
	}
}

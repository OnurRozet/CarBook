using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.BlogInterfaces;
using CarBook.Domanin.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetLast3BlogsWithAuthorHandler : IRequestHandler<GetLast3BlogsWithAuthorQuery, List<GetLast3BlogsWithAuthorResult>>
    {
        private readonly IBlogRepository _repository;

        public GetLast3BlogsWithAuthorHandler(IBlogRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetLast3BlogsWithAuthorResult>> Handle(GetLast3BlogsWithAuthorQuery request, CancellationToken cancellationToken)
        {
            var result =  _repository.GetLast3BlogWithAuthor();

            return result.Select(x=> new GetLast3BlogsWithAuthorResult
            {
                AuthorID = x.AuthorID,
                AuthorName=x.Author.Name,
                CategoryID=x.CategoryID,
                CoverImageUrl=x.CoverImageUrl,
                BlogID=x.BlogID,
                CreatedDate=x.CreatedDate,
                Title=x.Title,
            }).ToList();
        }
    }
}

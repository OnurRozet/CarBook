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
    public class GetBlogWithAuthorIdQueryHandler : IRequestHandler<GetBlogWithAuthorIdQuery, List<GetBlogWithAuthorIdQueryResult>>
    {
        private readonly IBlogRepository _blogRepository;

        public GetBlogWithAuthorIdQueryHandler(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<List<GetBlogWithAuthorIdQueryResult>> Handle(GetBlogWithAuthorIdQuery request, CancellationToken cancellationToken)
        {
            var values = _blogRepository.GetBlogWithAuthorId(request.Id);   
            return values.Select(x=> new GetBlogWithAuthorIdQueryResult
            {
                AuthorDescription=x.Author.Description,
                AuthorName=x.Author.Name,
                AuthorImage=x.Author.ImageUrl,
                Description=x.Description,
                AuthorID=x.AuthorID,
                BlogID=x.BlogID,
                CoverImageUrl=x.CoverImageUrl,
                CreatedDate=x.CreatedDate,
                Title=x.Title,
            }).ToList();
        }
    }
}

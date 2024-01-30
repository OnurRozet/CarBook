using CarBook.Application.Features.Mediator.Queries.TagCloudQueries;
using CarBook.Application.Features.Mediator.Results.TagCloudResults;
using CarBook.Application.Interfaces.TagCloudInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.TagCloudHandlers
{
    public class GetTagCloudByBlogIdQueryHandler : IRequestHandler<GetTagCloudWithByBlogIdQuery, List<GetTagCloudByBlogIdQueryResult>>
    {
        private readonly ITagCloud _repository;

        public GetTagCloudByBlogIdQueryHandler(ITagCloud repository)
        {
            _repository = repository;
        }

        public async Task<List<GetTagCloudByBlogIdQueryResult>> Handle(GetTagCloudWithByBlogIdQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetTagCloudWithByBlogId(request.Id);
            return values.Select(x => new GetTagCloudByBlogIdQueryResult
            {
                BlogId = x.BlogId,
                TagCloudId = x.Id,
                Title = x.Title,
              
            }).ToList();
        }
    }
}

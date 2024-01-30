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
    public class GetTagCloudWithBlogsQueryHandler : IRequestHandler<GetTagCloudWithBlogsQuery, List<GetTagCloudWithBlogsQueryResult>>
    {
        private readonly ITagCloud _repository;

        public GetTagCloudWithBlogsQueryHandler(ITagCloud repository)
        {
            _repository = repository;
        }

        public async Task<List<GetTagCloudWithBlogsQueryResult>> Handle(GetTagCloudWithBlogsQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetTagCloudWithBlogs();
            return values.Select(x => new GetTagCloudWithBlogsQueryResult
            {
                BlogId = x.BlogId,
                TagCloudId = x.Id,
                Title = x.Title,
                BlogName = x.Blog.Title
            }).ToList();
        }
    }
}

using CarBook.Application.Features.Mediator.Queries.FeatureQueries;
using CarBook.Application.Features.Mediator.Results.FeatureResults;
using CarBook.Application.Interfaces;
using CarBook.Domanin.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.FeatureHandlers
{
    public class GetFeatureByIdQueryHandler : IRequestHandler<GetFeatureByIdQuery, GetfeatureByIdQueryResult>
	{
		private readonly IRepository<Feature> _repository;

		public GetFeatureByIdQueryHandler(IRepository<Feature> repository)
		{
			_repository = repository;
		}
		public async Task<GetfeatureByIdQueryResult> Handle(GetFeatureByIdQuery request, CancellationToken cancellationToken)
		{
			var value = await _repository.GetByIdAsync(request.Id);
			return new GetfeatureByIdQueryResult
			{
				FeatureId = value.FeatureId,
				Name = value.Name,
			};
		}
	}
}

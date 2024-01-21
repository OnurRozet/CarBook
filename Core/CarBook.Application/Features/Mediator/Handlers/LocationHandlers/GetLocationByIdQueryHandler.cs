using CarBook.Application.Features.Mediator.Queries.LocationQueries;
using CarBook.Application.Features.Mediator.Results.LocationResults;
using CarBook.Application.Interfaces;
using CarBook.Domanin.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.LocationHandlers
{
	internal class GetLocationByIdQueryHandler : IRequestHandler<GetLocationByIdQuery, GetLocationQueryResult>
	{
		private readonly IRepository<Location> _repository;
		public GetLocationByIdQueryHandler(IRepository<Location> repository)
		{
			_repository = repository;
		}
		public async Task<GetLocationQueryResult> Handle(GetLocationByIdQuery request, CancellationToken cancellationToken)
		{
			var value = await _repository.GetByIdAsync(request.Id);
			return new GetLocationQueryResult
			{
				Name=value.Name,
				LocationId=value.LocationId,
			};
		}
	}
}

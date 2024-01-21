using CarBook.Application.Features.Mediator.Queries.ServicesQueries;
using CarBook.Application.Features.Mediator.Results.ServicesResults;
using CarBook.Application.Interfaces;
using CarBook.Domanin.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.ServicesHandlers
{
	internal class GetServicesByIdQueryHandler : IRequestHandler<GetServicesByIdQuery, GetServicesQueryResult>
	{
		private readonly IRepository<Service> _repository;
		public GetServicesByIdQueryHandler(IRepository<Service> repository)
		{
			_repository = repository;
		}
		public async Task<GetServicesQueryResult> Handle(GetServicesByIdQuery request, CancellationToken cancellationToken)
		{
			var value = await _repository.GetByIdAsync(request.Id);
			return new GetServicesQueryResult
			{
				Title=value.Title,
				Description=value.Description,
				IconUrl=value.IconUrl,
				Id = value.Id
			};
		}
	}
}

using CarBook.Application.Features.Mediator.Results.ServicesResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.ServicesQueries
{
	public class GetServicesByIdQuery:IRequest<GetServicesQueryResult>
	{
        public int Id { get; set; }

		public GetServicesByIdQuery(int id)
		{
			Id = id;
		}
	}
}

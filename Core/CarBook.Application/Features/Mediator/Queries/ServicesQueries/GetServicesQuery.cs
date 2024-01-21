using CarBook.Application.Features.Mediator.Results.ServicesResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.ServicesQueries
{
	public class GetServicesQuery : IRequest<List<GetServicesQueryResult>>
	{
		public int Id { get; set; }
		public string? Title { get; set; }
		public string? Description { get; set; }
		public string? IconUrl { get; set; } 
	}
}

﻿using CarBook.Application.Features.Mediator.Results.PricingResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.PricingQueries
{
	public class GetPricingByIdQuery:IRequest<GetPricingQueryResult>
	{
        public int Id { get; set; }

		public GetPricingByIdQuery(int id)
		{
			Id = id;
		}
	}
}

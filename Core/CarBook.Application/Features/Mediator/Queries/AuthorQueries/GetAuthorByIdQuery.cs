using CarBook.Application.Authors.Mediator.Results.AuthorResults;
using CarBook.Application.Features.Mediator.Results.TestimonialResults;
using MediatR;
using MediatR.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.AuthorQueries
{
    public class GetAuthorByIdQuery:IRequest<GetAuthorQueryResult>
    {
        public int Id { get; set; }

        public GetAuthorByIdQuery(int id)
        {
            Id = id;
        }
    }
}

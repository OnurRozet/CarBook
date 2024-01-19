using CarBook.Application.Features.CQRS.Results.ContactResults;
using CarBook.Application.Interfaces;
using CarBook.Domanin.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.ContactHandlers
{
	public class GetContactQueryHandler
	{
		private readonly IRepository<Contact> _repository;

		public GetContactQueryHandler(IRepository<Contact> repository)
		{
			_repository = repository;
		}

		public async Task<List<GetContactQueryResult>> Handle()
		{
			var entity = await _repository.GetAllAsync();
			return entity.Select(x => new GetContactQueryResult
			{
				ContactId = x.ContactId,
				Name = x.Name,
				Message = x.Message,
				Subject = x.Subject,
				SendDate = x.SendDate,
				Email = x.Email	

			}).ToList();

		}
	}
}

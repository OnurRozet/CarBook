﻿using CarBook.Application.Features.CQRS.Queries.ContactQueries;
using CarBook.Application.Features.CQRS.Results.ContactResults;
using CarBook.Application.Interfaces;
using CarBook.Domanin.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.ContactHandlers
{
	public class GetContactByIdQueryHandler
	{
		private readonly IRepository<Contact> _repository;

		public GetContactByIdQueryHandler(IRepository<Contact> repository)
		{
			_repository = repository;
		}

		public async Task<GetContactByIdQueryResult> Handle(GetContactByIdQuery query)
		{
			var value = await _repository.GetByIdAsync(query.Id);

			return new GetContactByIdQueryResult
			{
				ContactId = value.ContactId,
				Name = value.Name,
				Message = value.Message,
				Subject = value.Subject,
				SendDate = value.SendDate,
				Email = value.Email
			};

		}
	}
}

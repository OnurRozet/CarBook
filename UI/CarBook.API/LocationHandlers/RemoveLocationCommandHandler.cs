﻿using CarBook.Application.Features.Mediator.Commands.LocationCommands;
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
	public class RemoveLocationCommandHandler : IRequestHandler<RemoveLocationCommand>
	{
		private readonly IRepository<Location> _repository;

		public RemoveLocationCommandHandler(IRepository<Location> repository)
		{
			_repository = repository;
		}

		public async Task Handle(RemoveLocationCommand request, CancellationToken cancellationToken)
		{
			var entityForDelete = await _repository.GetByIdAsync(request.Id);
			if (entityForDelete != null)
			{
				await _repository.DeleteAsync(entityForDelete);
			}
		}
	}
}

﻿using CarBook.Application.Features.Mediator.Commands.PricingCommands;
using CarBook.Application.Interfaces;
using CarBook.Domanin.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.PricingHandlers
{
	public class RemovePricingCommandHandler : IRequestHandler<RemovePricingCommand>
	{
		private readonly IRepository<Pricing> _repository;

		public RemovePricingCommandHandler(IRepository<Pricing> repository)
		{
			_repository = repository;
		}

		public async Task Handle(RemovePricingCommand request, CancellationToken cancellationToken)
		{
			var entityForDelete = await _repository.GetByIdAsync(request.Id);
			if (entityForDelete != null)
			{
				await _repository.DeleteAsync(entityForDelete);
			}
		}
	}
}

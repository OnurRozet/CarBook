using CarBook.Application.Features.Mediator.Commands.PricingCommands;
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
	public class UpdatePricingCommandHandler : IRequestHandler<UpdatePricingCommand>
	{
		private readonly IRepository<Pricing> _repository;

		public UpdatePricingCommandHandler(IRepository<Pricing> repository)
		{
			_repository = repository;
		}

		public async Task Handle(UpdatePricingCommand request, CancellationToken cancellationToken)
		{
			var entityForUpdate = await _repository.GetByIdAsync(request.PricingId);
			if (entityForUpdate != null)
			{
				entityForUpdate.PricingName = request.PricingName;
				await _repository.UpdateAsync(entityForUpdate);
			}
		}
	}
}

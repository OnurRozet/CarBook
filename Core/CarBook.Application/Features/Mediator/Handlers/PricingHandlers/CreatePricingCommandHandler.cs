using CarBook.Application.Features.Mediator.Commands.FooterAddressCommands;
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
	internal class CreatePricingCommandHandler : IRequestHandler<CreatePricingCommand>
	{
		private readonly IRepository<Pricing> _repository;

		public CreatePricingCommandHandler(IRepository<Pricing> repository)
		{
			_repository = repository;
		}

		public  async Task Handle(CreatePricingCommand request, CancellationToken cancellationToken)
		{
			await _repository.CreateAsync(new Pricing
			{
				PricingName = request.PricingName
			}) ;
			
		}
	}
}

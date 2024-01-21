using CarBook.Application.Features.Mediator.Commands.FooterAddressCommands;
using CarBook.Application.Features.Mediator.Commands.ServicesCommands;
using CarBook.Application.Interfaces;
using CarBook.Domanin.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.ServicesHandlers
{
		public class CreatePricingCommandHandler : IRequestHandler<CreateServicesCommand>
		{
			private readonly IRepository<Service> _repository;
			public CreatePricingCommandHandler(IRepository<Service> repository)
			{
				_repository = repository;
			}
			public async Task Handle(CreateServicesCommand request, CancellationToken cancellationToken)
			{
				await _repository.CreateAsync(new Service
				{
					Description = request.Description,
					IconUrl = request.IconUrl,
					Title = request.Title
				});
			}
		}
}

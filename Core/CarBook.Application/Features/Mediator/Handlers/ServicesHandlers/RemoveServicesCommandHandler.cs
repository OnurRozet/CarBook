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
	public class RemoveServicesCommandHandler : IRequestHandler<RemoveServicesCommand>
	{
		private readonly IRepository<Service> _repository;

		public RemoveServicesCommandHandler(IRepository<Service> repository)
		{
			_repository = repository;
		}

		public async Task Handle(RemoveServicesCommand request, CancellationToken cancellationToken)
		{
			var entityForDelete = await _repository.GetByIdAsync(request.Id);
			if (entityForDelete != null)
			{
				await _repository.DeleteAsync(entityForDelete);
			}
		}
	}
}

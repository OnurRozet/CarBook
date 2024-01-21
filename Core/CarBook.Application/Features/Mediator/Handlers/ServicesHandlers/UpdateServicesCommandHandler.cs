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
	public class UpdateServicesCommandHandler : IRequestHandler<UpdateServicesCommand>
	{
		private readonly IRepository<Service> _repository;

		public UpdateServicesCommandHandler(IRepository<Service> repository)
		{
			_repository = repository;
		}

		public async Task Handle(UpdateServicesCommand request, CancellationToken cancellationToken)
		{
			var entityForUpdate = await _repository.GetByIdAsync(request.Id);
			if (entityForUpdate != null)
			{
				entityForUpdate.Title = request.Title;
				entityForUpdate.Description = request.Description;
				entityForUpdate.IconUrl = request.IconUrl;
				await _repository.UpdateAsync(entityForUpdate);
			}
		}
	}
}

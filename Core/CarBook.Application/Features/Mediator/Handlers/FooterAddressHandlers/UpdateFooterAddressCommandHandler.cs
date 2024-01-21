using CarBook.Application.Features.Mediator.Commands.FooterAddressCommands;
using CarBook.Application.Interfaces;
using CarBook.Domanin.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.FooterAddressHandlers
{
	public class UpdateFooterAddressCommandHandler : IRequestHandler<UpdateFooterAddressCommand>
	{
		private readonly IRepository<FooterAddress> _repository;

		public UpdateFooterAddressCommandHandler(IRepository<FooterAddress> repository)
		{
			_repository = repository;
		}

		public async Task Handle(UpdateFooterAddressCommand request, CancellationToken cancellationToken)
		{
			var entityForUpdate = await _repository.GetByIdAsync(request.FooterAddressId);
			if (entityForUpdate != null)
			{
				entityForUpdate.Phone = request.Phone;
				entityForUpdate.Address = request.Address;
				entityForUpdate.Description = request.Description;
				entityForUpdate.Email = request.Email;
				await _repository.UpdateAsync(entityForUpdate);
			}
		}
	}
}

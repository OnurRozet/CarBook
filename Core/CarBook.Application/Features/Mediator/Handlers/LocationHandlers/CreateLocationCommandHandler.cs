﻿using CarBook.Application.Features.Mediator.Commands.FooterAddressCommands;
using CarBook.Application.Features.Mediator.Commands.LocationCommands;
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
	internal class CreateLocationCommandHandler : IRequestHandler<CreateLocationCommand>
	{
		private readonly IRepository<Location> _repository;

		public CreateLocationCommandHandler(IRepository<Location> repository)
		{
			_repository = repository;
		}

		public  async Task Handle(CreateLocationCommand request, CancellationToken cancellationToken)
		{
			await _repository.CreateAsync(new Location
			{
				Name = request.Name
			}) ;
			
		}
	}
}

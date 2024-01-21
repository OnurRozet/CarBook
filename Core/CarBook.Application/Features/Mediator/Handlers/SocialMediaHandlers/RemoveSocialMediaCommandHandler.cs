﻿using CarBook.Application.Features.Mediator.Commands.SocialMediaCommands;
using CarBook.Application.Interfaces;
using CarBook.Domanin.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.SocialMediaHandlers
{
	public class RemoveSocialMediaCommandHandler : IRequestHandler<RemoveSocialMediaCommand>
	{
		private readonly IRepository<SocialMedia> _repository;

		public RemoveSocialMediaCommandHandler(IRepository<SocialMedia> repository)
		{
			_repository = repository;
		}

		public async Task Handle(RemoveSocialMediaCommand request, CancellationToken cancellationToken)
		{
			var entityForDelete = await _repository.GetByIdAsync(request.Id);
			if (entityForDelete != null)
			{
				await _repository.DeleteAsync(entityForDelete);
			}
		}
	}
}

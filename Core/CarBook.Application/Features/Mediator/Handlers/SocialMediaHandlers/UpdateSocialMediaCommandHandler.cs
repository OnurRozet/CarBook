using CarBook.Application.Features.Mediator.Commands.SocialMediaCommands;
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
	public class UpdateSocialMediaCommandHandler : IRequestHandler<UpdateSocialMediaCommand>
	{
		private readonly IRepository<SocialMedia> _repository;

		public UpdateSocialMediaCommandHandler(IRepository<SocialMedia> repository)
		{
			_repository = repository;
		}

		public async Task Handle(UpdateSocialMediaCommand request, CancellationToken cancellationToken)
		{
			var entityForUpdate = await _repository.GetByIdAsync(request.SocialMediaId);
			if (entityForUpdate != null)
			{
				entityForUpdate.Name = request.Name;
				entityForUpdate.Url = request.Url;
				entityForUpdate.Icon=request.Icon;
				await _repository.UpdateAsync(entityForUpdate);
			}
		}
	}
}

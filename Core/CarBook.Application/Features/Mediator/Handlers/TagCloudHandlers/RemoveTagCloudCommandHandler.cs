using CarBook.Application.Features.Mediator.Commands.TagCloudCommands;
using CarBook.Application.Interfaces;
using CarBook.Domanin.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.TagCloudHandlers
{
	public class RemoveTagCloudCommandHandler : IRequestHandler<RemoveTagCloudCommand>
	{
		private readonly IRepository<TagCloud> _repository;

		public RemoveTagCloudCommandHandler(IRepository<TagCloud> repository)
		{
			_repository = repository;
		}

		public async Task Handle(RemoveTagCloudCommand request, CancellationToken cancellationToken)
		{
			var entityForDelete = await _repository.GetByIdAsync(request.Id);
			if (entityForDelete != null)
			{
				await _repository.DeleteAsync(entityForDelete);
			}
		}
	}
}

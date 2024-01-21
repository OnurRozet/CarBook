using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Commands.ServicesCommands
{
	public class RemoveServicesCommand : IRequest
	{
		public int Id { get; set; }

		public RemoveServicesCommand(int id)
		{
			Id = id;
		}
	}
}

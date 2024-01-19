using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Services
{
	public static class ServicesRegistration
	{
		public static void AddApplicationService(this IServiceCollection services)
		{
			services.AddMediatR(x=>x.RegisterServicesFromAssembly(typeof(ServicesRegistration).Assembly));
		} 
	}
}

using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Domanin.Entities;
using CarBook.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistance.Repositories.CarRepositories
{
	public class CarRepository : ICarRepository
	{
		private readonly CarBookContext _context;

		public CarRepository(CarBookContext context)
		{
			_context = context;
		}

		public List<Car> GetCarWithBrand()
		{
			var cars=_context.Cars.Include(x => x.Brand).ToList();
			return cars;
			
		}
	}
}

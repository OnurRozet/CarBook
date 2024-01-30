using CarBook.Application.Interfaces.CarPricingInterfaces;
using CarBook.Domanin.Entities;
using CarBook.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistance.Repositories.CarPricingRepositories
{
	public class CarPricingRepository : ICarPricingRepository
	{
		private		readonly CarBookContext _context;

		public CarPricingRepository(CarBookContext context)
		{
			_context = context;
		}

		public List<CarPricing> GetCarWithPricing()
		{
			var values = _context.CarPricings.Include(x => x.Car).Include(x => x.Car.Brand).Include(x => x.Pricing).Where(x=>x.PricingId==1).ToList();
			return values;
		}
	}
}

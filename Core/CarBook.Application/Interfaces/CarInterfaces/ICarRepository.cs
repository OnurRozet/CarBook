using CarBook.Domanin.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces.CarInterfaces
{
	public interface ICarRepository
	{
		List<Car> GetCarWithBrand();
		List<Car> GetLast5CarsWithBrands();
		
	}
}

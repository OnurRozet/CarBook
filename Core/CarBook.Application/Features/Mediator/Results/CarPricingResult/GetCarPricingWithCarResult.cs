using CarBook.Domanin.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Results.CarPricingResult
{
    public class GetCarPricingWithCarResult
    {
		public int CarId { get; set; }
		public int CarPricingId { get; set; }
		public string BrandName { get; set; }
		public string Model { get; set; }
		public decimal Amount { get; set; }
		public string CoverImageUrl { get; set; }
	}
}

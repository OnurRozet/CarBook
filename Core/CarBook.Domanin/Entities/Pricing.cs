using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domanin.Entities
{
	public class Pricing
	{
        public int PricingId { get; set; }
		public string? PricingName { get; set;}
        public List<CarPricing>? CarPricings { get; set; }

    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domanin.Entities
{
	public class Brand
	{
        public int BrandId { get; set; }
        public string? BrandName { get; set; }
        public List<Car> Cars { get; set; }

    }
}

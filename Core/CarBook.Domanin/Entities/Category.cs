﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domanin.Entities
{
	public class Category
	{
        public int CategoryId { get; set; }
        public string? CategoyName { get; set; }
        public List<Blog> Blogs { get; set; }
    }
}

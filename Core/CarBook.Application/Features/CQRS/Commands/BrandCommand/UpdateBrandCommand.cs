﻿using CarBook.Domanin.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Commands.BrandCommand
{
	public class UpdateBrandCommand
	{
        public int Id { get; set; }
        public string? BrandName { get; set; }
	}
}

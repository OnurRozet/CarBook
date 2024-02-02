using CarBook.Application.Features.CQRS.Commands.BrandCommand;
using CarBook.Application.Features.CQRS.Handlers.BrandHandlers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;

namespace CarBook.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BrandsController : ControllerBase
	{
		private readonly CreateBrandCommandHandler _createBrandCommandHandler;
		private readonly UpdateBrandCommandHandler _updateBrandCommandHandler;
		private readonly RemoveBrandCommandHandler _removeBrandCommandHandler;
		private readonly GetBrandQueryHandler _getBrandQueryHandler;
		private readonly GetBrandByIdQueryHandler _getBrandByIdQueryHandler;

		public BrandsController(CreateBrandCommandHandler createBrandCommandHandler, UpdateBrandCommandHandler updateBrandCommandHandler, RemoveBrandCommandHandler removeBrandCommandHandler, GetBrandQueryHandler getBrandQueryHandler, GetBrandByIdQueryHandler getBrandByIdQueryHandler)
		{
			_createBrandCommandHandler = createBrandCommandHandler;
			_updateBrandCommandHandler = updateBrandCommandHandler;
			_removeBrandCommandHandler = removeBrandCommandHandler;
			_getBrandQueryHandler = getBrandQueryHandler;
			_getBrandByIdQueryHandler = getBrandByIdQueryHandler;
		}

		[HttpGet]

		public async Task<IActionResult> BrandList()
		{
			var values = await _getBrandQueryHandler.Handle();
			return Ok(values);
		}

		[HttpGet("{id}")]

		public async Task<IActionResult> BrandById(int id)
		{
			var value = await _getBrandByIdQueryHandler.Handle(new Application.Features.CQRS.Queries.BrandQueries.GetBrandByIdQuery(id));
			return Ok(value);
		}

		[HttpPut]

		public async Task<IActionResult> UpdateBrand(UpdateBrandCommand command)
		{
			await _updateBrandCommandHandler.Handle(command);
			return Ok(command);
		}

		[HttpPost]

		public async Task<IActionResult> CreateBrand(CreateBrandCommand command)
		{
			await _createBrandCommandHandler.Handle(command);
			return Ok(command);
		}

		[HttpDelete("{id}")]

		public async Task<IActionResult> RemoveBrand(int id )
		{
			await _removeBrandCommandHandler.Handle(new RemoveBrandCommand(id));
			return Ok("Marka Bilgisi Silinmiştir.");
		}

		
	}
}

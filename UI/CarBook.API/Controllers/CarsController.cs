using CarBook.Application.Features.CQRS.Commands.CarCommand;
using CarBook.Application.Features.CQRS.Handlers.CarHandlers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CarsController : ControllerBase
	{
		private readonly CreateCarCommandHandler _createCarCommandHandler;
		private readonly UpdateCarCommandHandler _updateCarCommandHandler;
		private readonly RemoveCarCommandHandler _removeCarCommandHandler;
		private readonly GetCarQueryHandler _getCarQueryHandler;
		private readonly GetCarByIdQueryHandler _getCarByIdQueryHandler;
		private readonly GetCarWithBrandQueryHandler _getCarWithBrandQueryHandler;
		private readonly GetLast5CarsWithBrandQueryHandler _getLast5CarsWithBrandQueryHandler;


		public CarsController(CreateCarCommandHandler createCarCommandHandler, UpdateCarCommandHandler updateCarCommandHandler, RemoveCarCommandHandler removeCarCommandHandler, GetCarQueryHandler getCarQueryHandler, GetCarByIdQueryHandler getCarByIdQueryHandler, GetCarWithBrandQueryHandler getCarWithBrandQueryHandler, GetLast5CarsWithBrandQueryHandler getLast5CarsWithBrandQueryHandler)
		{
			_createCarCommandHandler = createCarCommandHandler;
			_updateCarCommandHandler = updateCarCommandHandler;
			_removeCarCommandHandler = removeCarCommandHandler;
			_getCarQueryHandler = getCarQueryHandler;
			_getCarByIdQueryHandler = getCarByIdQueryHandler;
			_getCarWithBrandQueryHandler = getCarWithBrandQueryHandler;
			_getLast5CarsWithBrandQueryHandler = getLast5CarsWithBrandQueryHandler;
		}

		[HttpGet]

		public async Task<IActionResult> CarList()
		{
			var values = await _getCarQueryHandler.Handle();
			return Ok(values);
		}

		[HttpGet("{id}")]

		public async Task<IActionResult> CarById(int id)
		{
			var value = await _getCarByIdQueryHandler.Handle(new Application.Features.CQRS.Queries.CarQueries.GetCarByIdQuery(id));
			return Ok(value);
		}

		[HttpPut]

		public async Task<IActionResult> UpdateCar(UpdateCarCommand command)
		{
			await _updateCarCommandHandler.Handle(command);
			return Ok(command);
		}

		[HttpPost]

		public async Task<IActionResult> CreateCar(CreateCarCommand command)
		{
			await _createCarCommandHandler.Handle(command);
			return Ok(command);
		}

		[HttpDelete("{id}")]

		public async Task<IActionResult> RemoveCar(int id)
		{
			await _removeCarCommandHandler.Handle(new RemoveCarCommand(id));
		
			return Ok("Araç silindi");
		}

		[HttpGet("GetCarWithBrand")]

		public IActionResult GetCarWithBrand()
		{
		  var values =	_getCarWithBrandQueryHandler.Handle();
			return Ok(values);
		}

        [HttpGet("GetLast5CarsWithBrand")]

        public IActionResult GetLast5CarsWithBrand()
        {
            var values = _getLast5CarsWithBrandQueryHandler.Handle();
            return Ok(values);
        }


    }
}

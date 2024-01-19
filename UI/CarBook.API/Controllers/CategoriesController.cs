using CarBook.Application.Features.CQRS.Commands.CategoryCommand;
using CarBook.Application.Features.CQRS.Handlers.Categoryhandlers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoriesController : ControllerBase
	{
		private readonly CreateCategoryCommandHandler _createCategoryCommandHandler;
		private readonly UpdateCategoryCommandHandler _updateCategoryCommandHandler;
		private readonly RemoveCategoryCommandHandler _removeCategoryCommandHandler;
		private readonly GetCategoryQueryHandler _getCategoryQueryHandler;
		private readonly GetCategoryByIdQueryHandler _getCategoryByIdQueryHandler;

		public CategoriesController(CreateCategoryCommandHandler createCategoryCommandHandler, UpdateCategoryCommandHandler updateCategoryCommandHandler, RemoveCategoryCommandHandler removeCategoryCommandHandler, GetCategoryQueryHandler getCategoryQueryHandler, GetCategoryByIdQueryHandler getCategoryByIdQueryHandler)
		{
			_createCategoryCommandHandler = createCategoryCommandHandler;
			_updateCategoryCommandHandler = updateCategoryCommandHandler;
			_removeCategoryCommandHandler = removeCategoryCommandHandler;
			_getCategoryQueryHandler = getCategoryQueryHandler;
			_getCategoryByIdQueryHandler = getCategoryByIdQueryHandler;
		}

		[HttpGet]

		public async Task<IActionResult> CategoryList()
		{
			var values = await _getCategoryQueryHandler.Handle();
			return Ok(values);
		}

		[HttpGet("{id}")]

		public async Task<IActionResult> CategoryById(int id)
		{
			var value = await _getCategoryByIdQueryHandler.Handle(new Application.Features.CQRS.Queries.CategoryQueries.GetCategoryByIdQuery(id));
			return Ok(value);
		}

		[HttpPut]

		public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand command)
		{
			await _updateCategoryCommandHandler.Handle(command);
			return Ok(command);
		}

		[HttpPost]

		public async Task<IActionResult> CreateCategory(CreateCategoryCommand command)
		{
			await _createCategoryCommandHandler.Handle(command);
			return Ok(command);
		}

		[HttpDelete]

		public async Task<IActionResult> RemoveCategory(RemoveCategoryCommand command)
		{
			await _removeCategoryCommandHandler.Handle(command);
			return Ok(command);
		}
	}
}

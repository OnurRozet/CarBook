using CarBook.Application.Features.CQRS.Commands.BannerCommand;
using CarBook.Application.Features.CQRS.Handlers.BannerHandlers;
using CarBook.Application.Features.CQRS.Handlers.BannerHandlers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BannersController : ControllerBase
	{
		private readonly CreateBannerCommandHandler _createBannerCommandHandler;
		private readonly UpdateBannerCommandHandler _updateBannerCommandHandler;
		private readonly RemoveBannerCommandHandler _removeBannerCommandHandler;
		private readonly GetBannerQueryHandler _getBannerQueryHandler;
		private readonly GetBannerByIdQueryHandler _getBannerByIdQueryHandler;

		public BannersController(CreateBannerCommandHandler createBannerCommandHandler, UpdateBannerCommandHandler updateBannerCommandHandler, RemoveBannerCommandHandler removeBannerCommandHandler, GetBannerQueryHandler getBannerQueryHandler, GetBannerByIdQueryHandler getBannerByIdQueryHandler)
		{
			_createBannerCommandHandler = createBannerCommandHandler;
			_updateBannerCommandHandler = updateBannerCommandHandler;
			_removeBannerCommandHandler = removeBannerCommandHandler;
			_getBannerQueryHandler = getBannerQueryHandler;
			_getBannerByIdQueryHandler = getBannerByIdQueryHandler;
		}

		[HttpGet]

		public async Task<IActionResult> BannerList()
		{
			var values = await _getBannerQueryHandler.Handle();
			return Ok(values);
		}

		[HttpGet("{id}")]

		public async Task<IActionResult> BannerById(int id)
		{
			var value = await _getBannerByIdQueryHandler.Handle(new Application.Features.CQRS.Queries.BannerQueries.GetBannerByIdQuery(id));
			return Ok(value);
		}
		[HttpPost]

		public async Task<IActionResult> CreateBanner(CreateBannerCommand command)
		{
			await _createBannerCommandHandler.Handle(command);
			return Ok(command);
		}
		[HttpDelete("{id}")]

		public async Task<IActionResult> RemoveBanner(int id)
		{
			await _removeBannerCommandHandler.Handle(new RemoveBannerCommand(id));

			return Ok("Banner Bilgisi Silindi");
		}
		[HttpPut]

		public async Task<IActionResult> UpdateBanner(UpdateBannerCommand command)
		{
			await _updateBannerCommandHandler.Handle(command);

			return Ok(command);
		}
	}
}

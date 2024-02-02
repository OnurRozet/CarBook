using CarBook.Application.Features.CQRS.Commands.CategoryCommand;
using CarBook.Application.Features.CQRS.Results.CategoryResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("Admin/AdminCategory")]
	public class AdminCategoryController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;
		
		public AdminCategoryController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}


		[Route("Index")]
		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7205/api/Categories");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<GetCategoryQueryResult>>(jsonData);
				return View(values);
			}
			return View();
		}

		[HttpGet]
		[Route("CreateCategory")]
		public async Task<IActionResult> CreateCategory()
		{
			return View();
		}

		[HttpPost]
		[Route("CreateCategory")]
		public async Task<IActionResult> CreateCategory(CreateCategoryCommand createCategory)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createCategory);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:7205/api/Categories", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "AdminCategory", new { area = "Admin" });
			}
			return View();
		}

		[Route("RemoveCategory/{id}")]
		public async Task<IActionResult> RemoveCategory(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var response = await client.DeleteAsync($"https://localhost:7205/api/Categories/" + id);
			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "AdminCategory", new { area = "Admin" });
			}
			return View();
		}

		[HttpGet]
		[Route("UpdateCategory/{id}")]
		public async Task<IActionResult> UpdateCategory(int id)
		{

			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7205/api/Categories/" + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<GetCategoryQueryResult>(jsonData);
				return View(values);
			}
			return View();
		}


		[HttpPost]
		[Route("UpdateCategory/{id}")]
		public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand updateCategory)
		{
			var client = (_httpClientFactory.CreateClient());
			var jsonData = JsonConvert.SerializeObject(updateCategory);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var response = await client.PutAsync("https://localhost:7205/api/Categories", stringContent);
			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "AdminCategory", new { area = "Admin" });
			}
			return View();

		}
	}
}

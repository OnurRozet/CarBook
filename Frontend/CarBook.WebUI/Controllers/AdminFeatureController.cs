using CarBook.Application.Features.CQRS.Commands.CarCommand;
using CarBook.Application.Features.CQRS.Results.BrandResults;
using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Features.Mediator.Commands.FeatureCommands;
using CarBook.Application.Features.Mediator.Results.FeatureResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace CarBook.WebUI.Controllers
{
	public class AdminFeatureController : Controller
    {
		private readonly IHttpClientFactory _httpClientFactory;

		public AdminFeatureController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
        {
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7205/api/Features");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<GetFeatureQueryResult>>(jsonData);
				return View(values);
			}
			return View();
		}

		[HttpGet]

		public async Task<IActionResult> CreateFeature()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateFeature(CreateFeatureCommand createFeature)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createFeature);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:7205/api/Features", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}


		public async Task<IActionResult> RemoveFeature(int id)
		{
			var client= _httpClientFactory.CreateClient();
			var response = await client.DeleteAsync($"https://localhost:7205/api/Features/" + id);
			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}

		[HttpGet]

		public async Task<IActionResult> UpdateFeature(int id)
		{

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7205/api/Features/"+id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetFeatureQueryResult>(jsonData);
                return View(values);
            }
            return View();
        }


		[HttpPost]
		public async Task<IActionResult> UpdateFeature(UpdateFeatureCommand updateFeature)
		{
			var client = (_httpClientFactory.CreateClient());
			var jsonData = JsonConvert.SerializeObject(updateFeature);
			StringContent stringContent = new StringContent(jsonData,Encoding.UTF8,"application/json");
			var response = await client.PutAsync("https://localhost:7205/api/Features/",stringContent);
			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();

		}
	}
}

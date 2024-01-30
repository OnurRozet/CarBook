using CarBook.Application.Features.CQRS.Commands.ContactCommand;
using CarBook.Application.Features.Mediator.Commands.BlogCommands;
using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Controllers
{
	public class BlogController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;
		public BlogController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> Index(GetAllBlogsWithAuthorQuery query)
		{
			ViewBag.v1 = "Bloglarımız";
			ViewBag.v2 = "Yazarlarımızın Blogları";
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7205/api/Blogs/GetAllBlogsWithAuthor");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData= await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<GetAllBlogsWithAuthorQueryResult>>(jsonData);
				return View(values);
			}
			return View();
		}

		[HttpGet]

		public async Task<IActionResult> BlogDetail(int id)
		{
			ViewBag.v1 = "Bloglar";
			ViewBag.v2 = "Blog Detayı ve Yorumlar";
			ViewBag.blogId=id;
			return View();
		}
	}
}

using CarBook.Application.Features.Mediator.Results.BlogResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel;

namespace CarBook.WebUI.ViewComponents.BlogViewComponent
{
    public class _BlogDetailMainBlogComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _BlogDetailMainBlogComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7205/api/Blogs/" +id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetBlogQueryResult>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}

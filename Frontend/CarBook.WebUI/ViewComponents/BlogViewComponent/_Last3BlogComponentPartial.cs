using CarBook.Application.Features.Mediator.Results.BlogResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.BlogViewComponent
{
    public class _Last3BlogComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _Last3BlogComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7205/api/Blogs/GetLast3BlogsWithAuthor");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<GetLast3BlogsWithAuthorResult>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}

using CarBook.Application.Features.Mediator.Results.BlogResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.BlogViewComponent
{
    public class _BlogDetailAuthorAboutComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _BlogDetailAuthorAboutComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7205/api/Blogs/GetBlogWithAuthorId?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<GetBlogWithAuthorIdQueryResult>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}

using CarBook.Application.Features.CQRS.Results.BannerResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.BannerCoverViewComponent
{
    public class _BannerCoverComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _BannerCoverComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client= _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7205/api/Banners");
            if (responseMessage.IsSuccessStatusCode)
            {
               var jsonData= await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<GetBannerQueryResult>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}

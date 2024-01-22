using CarBook.Application.Features.CQRS.Results.BannerResults;
using CarBook.Application.Features.CQRS.Results.CarResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.FeaturedVehicleViewComponent
{
    public class _FeaturedVehicleComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _FeaturedVehicleComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7205/api/Cars/GetLast5CarsWithBrand");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<GetLast5CarsWithBrandQueryResult>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}

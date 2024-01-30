using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Features.Mediator.Results.CarPricingResult;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace CarBook.WebUI.Controllers
{
    public class CarController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CarController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async  Task<IActionResult> Index()
        {
            ViewBag.v1 = "Araçlarımız";
            ViewBag.v2 = "Aracı Seçiniz";
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7205/api/CarPricings/GetCarPricingWithCar");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<GetCarPricingWithCarResult>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}

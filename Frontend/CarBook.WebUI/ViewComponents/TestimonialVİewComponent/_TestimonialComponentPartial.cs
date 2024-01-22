using CarBook.Application.Features.Mediator.Results.TestimonialResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace CarBook.WebUI.ViewComponents.TestimonialVİewComponent
{
    public class _TestimonialComponentPartial:ViewComponent
    {

        private readonly    IHttpClientFactory _httpClientFactory;

        public _TestimonialComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7205/api/Testimonials");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData= await responseMessage.Content.ReadAsStringAsync();
                var values =  JsonConvert.DeserializeObject<List<GetTestimonialQueryResult>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}

using CarBook.Application.Features.CQRS.Commands.ContactCommand;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;


namespace CarBook.WebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly    IHttpClientFactory _httpClientFactory;
        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateContactCommand contactDto)
        {
            var client = _httpClientFactory.CreateClient();
            contactDto.SendDate = DateTime.Now;
            var jsonData = JsonConvert.SerializeObject(contactDto);
            StringContent stringContent = new StringContent(jsonData,System.Text.Encoding.UTF8,"application/json");
            var responseMessage = await client.PostAsync("https://localhost:7205/api/Contacts",stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index","Contact");
            }
            return View();
        }
    }
}

﻿using CarBook.Application.Features.Mediator.Results.ServicesResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace CarBook.WebUI.ViewComponents.ServiceViewComponent
{
    public class _ServiceComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _ServiceComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7205/api/Services");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData= await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<GetServicesQueryResult>>(jsonData);
                return View(values);
            }
            return View();

        }
    }
}

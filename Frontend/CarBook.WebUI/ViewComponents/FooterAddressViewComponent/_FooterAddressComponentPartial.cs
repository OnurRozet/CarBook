﻿using CarBook.Application.Features.Mediator.Results.FooterAddressResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace CarBook.WebUI.ViewComponents.FooterAddressViewComponent
{
    public class _FooterAddressComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _FooterAddressComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7205/api/FooterAddress");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<GetFooterAddressQueryResult>>(jsonData);
                return View(values);
            }
            return View();
            
        }
    }
}

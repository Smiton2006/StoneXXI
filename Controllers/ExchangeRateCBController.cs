using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using StoneXXI.DB.Contexts;
using StoneXXI.Views.Currency;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace StoneXXI.Controllers
{
    [ApiController]
    [Route("/api/v1/exchangeRate/cb")]
    public class ExchangeRateCBController : ControllerBase
    {
        private readonly ApplicationContext _context;
        private readonly IHttpClientFactory _clientFactory;

        public ExchangeRateCBController(ApplicationContext context, IHttpClientFactory clientFactory)
        {
            _context = context;
            _clientFactory = clientFactory;
        }

        [HttpGet]
        public async Task GetAsync()
        {
            const string url = "http://www.cbr.ru/scripts/XML_valFull.asp";
            var param = new Dictionary<string, string>() { { "date_req", DateTime.Now.ToString() } };

            var newUrl = new Uri(QueryHelpers.AddQueryString(url, param));

            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync(newUrl);
            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var serializer = new XmlSerializer(typeof(CurrencyXmlViews));
                var responsse = (CurrencyXmlViews)serializer.Deserialize(responseStream);
            }
        }

        [HttpPost]
        public async Task FillCurrency()
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync("http://www.cbr.ru/scripts/XML_valFull.asp");
            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var serializer = new XmlSerializer(typeof(CurrencyXmlViews));
                var responsse = (CurrencyXmlViews)serializer.Deserialize(responseStream);
            }            
        }
    }
}

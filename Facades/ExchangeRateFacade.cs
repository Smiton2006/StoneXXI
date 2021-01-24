using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using StoneXXI.DB.Contexts;
using StoneXXI.DB.Models;
using StoneXXI.Views.ExchangeRate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace StoneXXI.Facades
{
    public class ExchangeRateFacade
    {
        private readonly ApplicationContext _context;
        private readonly IHttpClientFactory _clientFactory;
        private const string defaultCurrencyIsoCharCode = "USD";

        public ExchangeRateFacade(ApplicationContext context, IHttpClientFactory clientFactory)
        {
            _context = context;
            _clientFactory = clientFactory;
        }
        
        public async Task UploadCurrentExchangeRate()
        {
            const string url = "http://www.cbr.ru/scripts/XML_daily.asp";
            var param = new Dictionary<string, string>() { { "date_req", DateTime.Now.Date.ToString() } };

            var newUrl = new Uri(QueryHelpers.AddQueryString(url, param));

            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync(newUrl);
            var rates = new ExchangeRateXmlViews();
            if (response.IsSuccessStatusCode)
            {
                var str = await response.Content.ReadAsStringAsync();
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var serializer = new XmlSerializer(typeof(ExchangeRateXmlViews));
                rates = (ExchangeRateXmlViews)serializer.Deserialize(responseStream);
            }

            var rateModels = rates.exchangeRates.ConvertAll(ExchangeRate.ConvertFrom);
            _context.ExchangeRate.AddRange(rateModels);
            await _context.SaveChangesAsync();
        }

        public async Task<ExchangeRate> GetExchangeRate(string isoCharCode, DateTime dateTime)
        {
            return await _context.ExchangeRate
                .FirstOrDefaultAsync(x => x.Currency.IsoCharCode == isoCharCode && x.Date.Date == dateTime.Date);
        }

        public async Task<ExchangeRate> GetDefaultExchangeRate()
        {
            return await GetExchangeRate(defaultCurrencyIsoCharCode, DateTime.Now);
        }
    }
}

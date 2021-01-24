using Microsoft.EntityFrameworkCore;
using StoneXXI.DB.Contexts;
using StoneXXI.DB.Models;
using StoneXXI.Views.Currency;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace StoneXXI.Facades
{
    public class CurrencyFacade
    {
        private readonly ApplicationContext _context;
        private readonly IHttpClientFactory _clientFactory;
        private const string currencyUrl = "http://www.cbr.ru/scripts/XML_valFull.asp";

        public CurrencyFacade(ApplicationContext context, IHttpClientFactory clientFactory)
        {
            _context = context;
            _clientFactory = clientFactory;
        }

        public async Task UploadCurrency()
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync(currencyUrl);
            var currencys = new CurrencyXmlViews();
            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var serializer = new XmlSerializer(typeof(CurrencyXmlViews));
                currencys = (CurrencyXmlViews)serializer.Deserialize(responseStream);
            }
            var currencyModels = currencys.Currencys.ConvertAll(Currency.ConvertFrom);
            var currencyInBase = await _context.Currencys.Select(x => x.Code).ToListAsync();
            var toUpload = currencyModels.Where(x => !currencyInBase.Contains(x.Code));
            _context.Currencys.AddRange(toUpload);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Currency>> GetAllAsync()
        {
            return await _context.Currencys.ToListAsync();
        }
    }
}

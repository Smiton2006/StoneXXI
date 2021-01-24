using Microsoft.EntityFrameworkCore;
using StoneXXI.DB.Contexts;
using StoneXXI.DB.Models;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

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

        }

        public async Task<ExchangeRate> GetExchangeRate(string isoCharCode, DateTime dateTime)
        {
            return await _context.ExchangeRate
                .FirstOrDefaultAsync(x => x.FromCurrency.IsoCharCode == isoCharCode && x.Date.Date == dateTime.Date);
        }

        public async Task<ExchangeRate> GetDefaultExchangeRate()
        {
            return await GetExchangeRate(defaultCurrencyIsoCharCode, DateTime.Now);
        }
    }
}

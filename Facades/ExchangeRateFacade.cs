using Microsoft.EntityFrameworkCore;
using RuVdsTest;
using StoneXXI.Clients;
using StoneXXI.DB.Contexts;
using StoneXXI.DB.Models;
using System;
using System.Threading.Tasks;

namespace StoneXXI.Facades
{
    /// <summary>
    /// Фасад для работы с курсом обмена
    /// </summary>
    public class ExchangeRateFacade
    {
        private readonly ApplicationContext _context;
        private readonly CbrHttpClient _client;
        private const string defaultCurrencyIsoCharCode = "USD";

        public ExchangeRateFacade(ApplicationContext context, CbrHttpClient client)
        {
            _context = context;
            _client = client;
        }

        /// <summary>
        /// Загузить сегодняшний курс в базу
        /// </summary>
        public async Task<Result> UploadCurrentExchangeRateAsync()
        {
            var ratesRes = await _client.GetExchangeRateAsync(DateTime.Now);
            if (ratesRes.Failure)
                return Result.Fail(ratesRes.Error);
            try
            {
                var rateModels = ratesRes.Value.exchangeRates.ConvertAll(ExchangeRate.ConvertFrom);
                _context.ExchangeRate.AddRange(rateModels);
                await _context.SaveChangesAsync();
                return Result.Ok();
            }
            catch (Exception)
            {
                return Result.Fail("Произошла ошибка при загрузки курса");
            }
        }

        /// <summary>
        /// Получить курс обмена
        /// </summary>
        /// <param name="isoCharCode">Символьный ISO код валюты</param>
        /// <param name="dateTime">Дата курса обмена</param>
        public async Task<Result<ExchangeRate>> GetExchangeRate(string isoCharCode, DateTime dateTime)
        {
            try
            {
                var res = await _context.ExchangeRate
                    .FirstOrDefaultAsync(x => x.Currency.IsoCharCode == isoCharCode && x.Date.Date == dateTime.Date);
                return Result.Ok(res);
            }
            catch (Exception)
            {
                return Result.Fail<ExchangeRate>("Произошла ошибка при получении курса");
            }
        }

        public async Task<Result<ExchangeRate>> GetDefaultExchangeRate()
        {
            return await GetExchangeRate(defaultCurrencyIsoCharCode, DateTime.Now);
        }
    }
}

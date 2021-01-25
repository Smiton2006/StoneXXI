using Microsoft.EntityFrameworkCore;
using RuVdsTest;
using StoneXXI.Clients;
using StoneXXI.DB.Contexts;
using StoneXXI.DB.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoneXXI.Facades
{
    /// <summary>
    /// Фасад для работы с валютой
    /// </summary>
    public class CurrencyFacade
    {
        private readonly ApplicationContext _context;
        private readonly CbrHttpClient _client;

        public CurrencyFacade(ApplicationContext context, CbrHttpClient client)
        {
            _context = context;
            _client = client;
        }

        /// <summary>
        /// Загрузить валюты в базу
        /// </summary>        
        public async Task<Result> UploadCurrency()
        {
            var currencysRes = await _client.GetCurrencyAsync();
            if (currencysRes.Failure)
                return Result.Fail(currencysRes.Error);

            var currencyModels = currencysRes.Value.Currencys.ConvertAll(Currency.ConvertFrom);
            try
            {
                var currencyInBase = await _context.Currencys.Select(x => x.Code).ToListAsync();
                var toUpload = currencyModels.Where(x => !currencyInBase.Contains(x.Code));
                _context.Currencys.AddRange(toUpload);
                await _context.SaveChangesAsync();
                return Result.Ok();
            }
            catch (System.Exception)
            {
                return Result.Fail("Произошла ошибка при работе с данными");
            }
        }

        /// <summary>
        /// Получить все валюты
        /// </summary>
        public async Task<Result<List<Currency>>> GetAllAsync()
        {
            try
            {
                return Result.Ok(await _context.Currencys.ToListAsync());
            }
            catch (System.Exception)
            {
                return Result.Fail<List<Currency>>("Не удалось получить валюты")ж
            }

        }
    }
}

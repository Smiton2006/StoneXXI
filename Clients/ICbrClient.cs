using RuVdsTest;
using StoneXXI.Views.Currency;
using StoneXXI.Views.ExchangeRate;
using System;
using System.Threading.Tasks;

namespace StoneXXI.Clients
{
    /// <summary>
    /// Интерфейс для работы с центробанком
    /// </summary>
    interface ICbrClient
    {
        /// <summary>
        /// Получить валютный курс за указанную дату
        /// </summary>
        /// <param name="dateTime">Дата валютного курса</param>        
        Task<Result<ExchangeRateXmlViews>> GetExchangeRateAsync(DateTime dateTime);

        /// <summary>
        /// Получить валюты
        /// </summary>        
        Task<Result<CurrencyXmlViews>> GetCurrencyAsync();
    }
}

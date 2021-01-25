using Microsoft.AspNetCore.WebUtilities;
using RuVdsTest;
using StoneXXI.Views.Currency;
using StoneXXI.Views.ExchangeRate;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace StoneXXI.Clients
{
    /// <summary>
    /// Http-клиент для работы с центробанком
    /// </summary>
    public class CbrHttpClient : ICbrClient
    {
        private readonly HttpClient _client;

        public CbrHttpClient(HttpClient client)
        {
            client.BaseAddress = new Uri("http://www.cbr.ru");
            _client = client;
        }

        /// <inheritdoc/>
        public async Task<Result<ExchangeRateXmlViews>> GetExchangeRateAsync(DateTime dateTime)
        {
            var param = new Dictionary<string, string>() { { "date_req", dateTime.Date.ToString() } };
            var uri = QueryHelpers.AddQueryString("scripts/XML_daily.asp", param);
            var response = await GetAsync(uri);
            if (response.Failure)
                return Result.Fail<ExchangeRateXmlViews>(response.Error);

            using var responseStream = await response.Value.Content.ReadAsStreamAsync();
            var serializer = new XmlSerializer(typeof(ExchangeRateXmlViews));
            return Result.Ok((ExchangeRateXmlViews)serializer.Deserialize(responseStream));
        }

        /// <inheritdoc/>
        public async Task<Result<CurrencyXmlViews>> GetCurrencyAsync()
        {
            var response = await GetAsync("scripts/XML_valFull.asp");
            if (response.Failure)
                return Result.Fail<CurrencyXmlViews>(response.Error);

            using var responseStream = await response.Value.Content.ReadAsStreamAsync();
            var serializer = new XmlSerializer(typeof(CurrencyXmlViews));
            return Result.Ok((CurrencyXmlViews)serializer.Deserialize(responseStream));
        }

        private async Task<Result<HttpResponseMessage>> GetAsync(string uri)
        {
            try
            {
                var response = await _client.GetAsync(uri);
                if (!response.IsSuccessStatusCode)
                    return Result.Fail<HttpResponseMessage>("Не удалось выполнить запрос");
                return Result.Ok(response);
            }
            catch (Exception)
            {
                return Result.Fail<HttpResponseMessage>("Произошла ошибка во время выполнения запроса");
            }
        }
    }
}

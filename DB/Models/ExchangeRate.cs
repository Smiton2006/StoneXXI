using StoneXXI.Views.ExchangeRate;
using System;
using System.ComponentModel.DataAnnotations;

namespace StoneXXI.DB.Models
{
    /// <summary>
    /// Курс обмена
    /// </summary>
    public class ExchangeRate
    {
        /// <summary>
        /// Идентификатор курса обмена
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Дата курса обмена
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Код валюты с которой происходит обмен
        /// </summary>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Валюта с которой происходит обмен
        /// </summary>
        public Currency Currency { get; set; }

        /// <summary>
        /// Значение курса обмена
        /// </summary>
        public decimal Rate { get; set; }

        /// <summary>
        /// Преобразовать xml представление курса обмена в курс обмена
        /// </summary>
        /// <param name="view">Xml представление курса обмена</param>        
        public static ExchangeRate ConvertFrom(ExchangeRateXmlView view)
        {
            if (!decimal.TryParse(view.Value, out var rate))
                return null;

            return new ExchangeRate
            {
                Date = DateTime.Now.Date,
                CurrencyCode = view.Code,
                Rate = rate,
            };
        }
    }
}

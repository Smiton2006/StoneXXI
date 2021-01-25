using StoneXXI.Views.ExchangeRate;
using System;
using System.ComponentModel.DataAnnotations;

namespace StoneXXI.DB.Models
{
    public class ExchangeRate
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string CurrencyCode { get; set; }
        public Currency Currency { get; set; }
        public decimal Rate { get; set; }        

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

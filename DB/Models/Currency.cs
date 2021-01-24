using StoneXXI.Views.Currency;
using System;
using System.ComponentModel.DataAnnotations;

namespace StoneXXI.DB.Models
{
    [Serializable]
    public class Currency
    {
        [Key]
        public string Code { get; set; }

        public string Name { get; set; }

        public string EnglishName { get; set; }

        public int Nominal { get; set; }

        public string ParentCode { get; set; }

        public int? IsoNumberCode { get; set; }

        public string IsoCharCode { get; set; }

        public Currency() { }

        public static Currency ConvertFrom(CurrencyXmlView view)
        {
            var currency = new Currency
            {
                Code = view.Code,
                Name = view.Name,
                EnglishName = view.EnglishName,
                Nominal = view.Nominal,
                ParentCode = view.ParentCode,
                IsoCharCode = view.IsoCharCode
            };
            
            if (int.TryParse(view.IsoNumberCode, out var isoNumberCode))
                currency.IsoNumberCode = isoNumberCode;
            return currency;
        }
    }
}

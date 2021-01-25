using StoneXXI.Views.Currency;
using System.ComponentModel.DataAnnotations;

namespace StoneXXI.DB.Models
{
    /// <summary>
    /// Валюта
    /// </summary>
    public class Currency
    {
        /// <summary>
        /// Код валюты
        /// </summary>
        [Key]
        public string Code { get; set; }

        /// <summary>
        /// Наименование валюты
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Английское наименование валюты
        /// </summary>
        public string EnglishName { get; set; }

        /// <summary>
        /// Номинал
        /// </summary>
        public int Nominal { get; set; }

        /// <summary>
        /// Родительский код валюты
        /// </summary>
        public string ParentCode { get; set; }

        /// <summary>
        /// Числовой ISO код валюты
        /// </summary>
        public int? IsoNumberCode { get; set; }

        /// <summary>
        /// Символьный ISO код валюты
        /// </summary>
        public string IsoCharCode { get; set; }

        public Currency() { }

        /// <summary>
        /// Сковертировать xml представление валюты в валюту
        /// </summary>
        /// <param name="view">Xml представление валюты</param>        
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

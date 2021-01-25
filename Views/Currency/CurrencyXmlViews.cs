using System.Collections.Generic;
using System.Xml.Serialization;

namespace StoneXXI.Views.Currency
{
    /// <summary>
    /// Список xml представлений валют
    /// </summary>
    [XmlRoot("Valuta")]
    public class CurrencyXmlViews
    {
        /// <summary>
        /// Валюты
        /// </summary>
        [XmlElement("Item")]
        public List<CurrencyXmlView> Currencys;
    }
}

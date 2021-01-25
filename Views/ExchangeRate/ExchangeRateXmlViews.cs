using System.Collections.Generic;
using System.Xml.Serialization;

namespace StoneXXI.Views.ExchangeRate
{
    /// <summary>
    /// Список представлений курсов обмена
    /// </summary>
    [XmlRoot("ValCurs")]
    public class ExchangeRateXmlViews
    {
        /// <summary>
        /// Курсы обмена
        /// </summary>
        [XmlElement("Valute")]
        public List<ExchangeRateXmlView> exchangeRates;
    }
}

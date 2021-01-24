using System.Collections.Generic;
using System.Xml.Serialization;

namespace StoneXXI.Views.ExchangeRate
{
    [XmlRoot("ValCurs")]
    public class ExchangeRateXmlViews
    {
        [XmlElement("Valute")]
        public List<ExchangeRateXmlView> exchangeRates;
    }
}

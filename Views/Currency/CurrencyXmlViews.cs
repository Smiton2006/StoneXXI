using System.Collections.Generic;
using System.Xml.Serialization;

namespace StoneXXI.Views.Currency
{
    [XmlRoot("Valuta")]
    public class CurrencyXmlViews
    {
        [XmlElement("Item")]
        public List<CurrencyXmlView> Currencys;
    }
}

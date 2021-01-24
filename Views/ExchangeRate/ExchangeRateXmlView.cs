using System.Xml.Serialization;

namespace StoneXXI.Views.ExchangeRate
{
    public class ExchangeRateXmlView
    {
        [XmlAttribute("ID")]
        public string Code { get; set; }

        [XmlAttribute("NumCode")]
        public string NumberCode { get; set; }

        [XmlAttribute("Nominal")]
        public string Nominal { get; set; }

        [XmlAttribute("Name")]
        public string Name { get; set; }

        [XmlAttribute("Value")]
        public string Value { get; set; }
    }
}

using System.Xml.Serialization;

namespace StoneXXI.Views.ExchangeRate
{
    public class ExchangeRateXmlView
    {
        [XmlAttribute("ID")]
        public string Code { get; set; }

        [XmlElement("NumCode")]
        public string NumberCode { get; set; }

        [XmlElement("Nominal")]
        public string Nominal { get; set; }

        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Value")]
        public string Value { get; set; }
    }
}

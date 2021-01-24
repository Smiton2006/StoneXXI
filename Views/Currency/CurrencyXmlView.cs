using System.Xml.Serialization;

namespace StoneXXI.Views.Currency
{
    public class CurrencyXmlView
    {
        [XmlAttribute("ID")]
        public string Code { get; set; }

        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("EngName")]
        public string EnglishName { get; set; }

        [XmlElement("Nominal")]
        public int Nominal { get; set; }

        [XmlElement("ParentCode")]
        public string ParentCode { get; set; }

        [XmlElement("ISO_Num_Code", IsNullable = true)]
        public string IsoNumberCode { get; set; }

        [XmlElement("ISO_Char_Code")]
        public string IsoCharCode { get; set; }
    }
}

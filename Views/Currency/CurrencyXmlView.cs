using System.Xml.Serialization;

namespace StoneXXI.Views.Currency
{
    /// <summary>
    /// Xml представление валюты
    /// </summary>
    public class CurrencyXmlView
    {
        /// <summary>
        /// Код валюты
        /// </summary>
        [XmlAttribute("ID")]
        public string Code { get; set; }

        /// <summary>
        /// Наименование валюты
        /// </summary>
        [XmlElement("Name")]
        public string Name { get; set; }

        /// <summary>
        /// Английское наименование валюты
        /// </summary>
        [XmlElement("EngName")]
        public string EnglishName { get; set; }

        /// <summary>
        /// Номинал
        /// </summary>
        [XmlElement("Nominal")]
        public int Nominal { get; set; }

        /// <summary>
        /// Родительский код валюты
        /// </summary>
        [XmlElement("ParentCode")]
        public string ParentCode { get; set; }

        /// <summary>
        /// Числовой ISO код валюты
        /// </summary>
        [XmlElement("ISO_Num_Code", IsNullable = true)]
        public string IsoNumberCode { get; set; }

        /// <summary>
        /// Символьный код валюты
        /// </summary>
        [XmlElement("ISO_Char_Code")]
        public string IsoCharCode { get; set; }
    }
}

using System.Xml.Serialization;

namespace StoneXXI.Views.ExchangeRate
{
    /// <summary>
    /// Xml предтсавление курса обмена
    /// </summary>
    public class ExchangeRateXmlView
    {
        /// <summary>
        /// Код валюты
        /// </summary>
        [XmlAttribute("ID")]
        public string Code { get; set; }

        /// <summary>
        /// Числовой код валюты
        /// </summary>
        [XmlElement("NumCode")]
        public string NumberCode { get; set; }

        /// <summary>
        /// Номинал
        /// </summary>
        [XmlElement("Nominal")]
        public string Nominal { get; set; }

        /// <summary>
        /// Наименование валюты
        /// </summary>
        [XmlElement("Name")]
        public string Name { get; set; }

        /// <summary>
        /// Значение курса обмена
        /// </summary>
        [XmlElement("Value")]
        public string Value { get; set; }
    }
}

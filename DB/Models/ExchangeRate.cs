using System;
using System.ComponentModel.DataAnnotations;

namespace StoneXXI.DB.Models
{
    public class ExchangeRate
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Currency FromCurrency { get; set; }
        public Currency ToCurrency { get; set; }
        public decimal Rate { get; set; }        
    }
}

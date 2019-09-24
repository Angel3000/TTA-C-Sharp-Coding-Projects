using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarInsuranceQuotes.ViewModels
{
    public class QuotePar
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime dateBirth { get; set; }
        public int carYear { get; set; }
        public string carMake { get; set; }
        public string carModel { get; set; }
        public string diu { get; set; }
        public int speedTickets { get; set; }
        public string cover { get; set; }
        public string emailAddress { get; set; }
        public decimal totalQuote { get; set; }
        public DateTime quoteDate { get; set; }
    }
}
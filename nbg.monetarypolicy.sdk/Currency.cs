using System;
using System.Collections.Generic;

namespace nbg.monetarypolicy.sdk
{
    public class Currency
    {
        public string code { get; set; }
        public int quantity { get; set; }
        public string rateFormated { get; set; }
        public string diffFormated { get; set; }
        public double rate { get; set; }
        public string name { get; set; }
        public double diff { get; set; }
        public DateTime date { get; set; }
        public DateTime validFromDate { get; set; }
    }

    public class Currencies
    {
        public DateTime date { get; set; }
        public List<Currency> currencies { get; set; }
    }
}

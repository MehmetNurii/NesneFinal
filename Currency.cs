using System;
using System.Collections.Generic;
using System.Text;

namespace NesneFinal
{
    class Currency
    {
        private Dictionary<string, double> Currencies = new Dictionary<string, double>();
       

        public Currency()
        {
            Currencies.Add("TRY/USD", 3.0);
            Currencies.Add("TRY/EURO", 3.0);
            Currencies.Add("USD/TRY", 3.0);
            Currencies.Add("USD/EURO", 3.0);
            Currencies.Add("EURO/TRY", 3.0);
            Currencies.Add("EURO/USD", 3.0);

        }
    }
}

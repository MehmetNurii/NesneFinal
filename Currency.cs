using System;
using System.Collections.Generic;
using System.Text;

namespace NesneFinal
{
    class Currency
    {
        private static Dictionary<string, double> Currencies = new Dictionary<string, double>();
       

        public Currency(double tryusd,double tryeuro,double usdtry,double usdeuro,double eurotry,double eurousd)
        {
            //Hocam inşa edici kullanmamın sebebi program çalıştıktan sonra kurları güncelleyebilmek.

            Add("USD/TRY",3.0);
            Add("USD/EURO", 3.0);
            Add("TRY/USD", 3.0);
            Add("TRY/EURO", 3.0);
            Add("EURO/USD", 3.0);
            Add("TRY/TRY", 3.0);

        }

        private void Add(string currencyName,double currency) {
            if (Currencies.ContainsKey(currencyName))
            {
                Currencies[currencyName] = currency;
            }
            else 
            {
                Currencies.Add(currencyName, currency);
            }
        }


    }
}

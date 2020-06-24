using System;
using System.Collections.Generic;
using System.Text;

namespace NesneFinal
{
    class Currency 
    {
        
       

        public Currency(double tryusd,double tryeuro,double usdtry,double usdeuro,double eurotry,double eurousd)
        {
            //Hocam inşa edici kullanmamın sebebi program çalıştıktan sonra kurları güncelleyebilmek.

            Add("USD/TRY", usdtry);
            Add("TRY/USD", tryusd);
            Add("USD/EURO", usdeuro);
            Add("EURO/TRY", eurotry);
            Add("TRY/EURO", tryeuro);
            Add("EURO/USD", eurousd);
            
            

        }

        private void Add(string currencyName,double currency) {
            if (Database.Currencies.ContainsKey(currencyName))
            {
                Database.Currencies[currencyName] = currency;
            }
            else 
            {
                Database.Currencies.Add(currencyName, currency);
            }
        }

        public static double GetCurrency(string cur1,string cur2)
        {
            return Database.Currencies[cur1 + "/" + cur2];
        }


    }
}

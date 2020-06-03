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
            if (isExists("TRY/USD"))
            {
                Currencies.Add("TRY/USD", tryusd);
            }
            //TODO :yukarıdaki örneğin aynısı aşağıdakilere yapılacak ..
            Currencies.Add("TRY/EURO", 3.0);
            Currencies.Add("USD/TRY", 3.0);
            Currencies.Add("USD/EURO", 3.0);
            Currencies.Add("EURO/TRY", 3.0);
            Currencies.Add("EURO/USD", 3.0);
            
        }

        bool isExists(string currency) {
            if (Currencies.ContainsKey(currency))
            {
                return true;
            }
            
            return false;
        
        }


    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NesneFinal
{
     static class Transfer
    {
        public static bool MakeTransfer(Client whom,int targetAccountType,int myselfAccountType,double amount)
        {
            string targetAccountTypeName="";
            if (targetAccountType==1)
            {
                targetAccountTypeName = "TRY";
            }
            else if (targetAccountType==2)
            {
                targetAccountTypeName = "EURO";
                    
            }
            else if (targetAccountType==3)
            {
                targetAccountTypeName = "USD";
            }

            string myselfAccountTypeName = "";
            if (myselfAccountType == 1)
            {
                myselfAccountTypeName = "TRY";
            }
            else if (myselfAccountType == 2)
            {
                myselfAccountTypeName = "EURO";

            }
            else if (myselfAccountType == 3)
            {
                myselfAccountTypeName = "USD";
            }

            if (targetAccountTypeName != myselfAccountTypeName)
            {
                amount *= Currency.GetCurrency(myselfAccountTypeName, targetAccountTypeName);
            }
            if (CheckAccount(myselfAccountTypeName, amount)==false)
            {
                Console.WriteLine("Bakiye yetersiz Tranfer yapılamıyor .");
                return false;
            }
            //bizim hesap
            Client I = Auth.ActiveAccount();
            if (myselfAccountTypeName == "TRY")
            {
                I.MiktarIbanTR -= amount;

            }
            else if (myselfAccountTypeName == "EURO")
            {
                I.MiktarIbanEuro -= amount;
            }
            else if (myselfAccountTypeName == "USD")
            {
                I.MiktarIbanUsd -= amount;
            }

            //karşı taraf
            if (targetAccountTypeName == "TRY")
            {
                whom.MiktarIbanTR += amount;
            }
            else if (targetAccountTypeName == "EURO")
            {
                whom.MiktarIbanEuro += amount;
            }
            else if (targetAccountTypeName == "USD")
            {
                whom.MiktarIbanUsd += amount;
            }

            FileIO.ResetClientData();

            return true;
        }

        private static bool CheckAccount(string myselfAccountType,double amount)
        {
            if (myselfAccountType=="TRY")
            {
                return FileIO.CheckAccountBalance(Auth.ActiveAccount().IbanTR, amount); 
            }
            else if (myselfAccountType == "EURO")
            {
                return FileIO.CheckAccountBalance(Auth.ActiveAccount().IbanEuro, amount);
            }
            else if (myselfAccountType == "USD")
            {
                return FileIO.CheckAccountBalance(Auth.ActiveAccount().IbanUsd, amount);
            }
            return false;
        }
    }
}
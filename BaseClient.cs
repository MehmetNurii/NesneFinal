using System;
using System.Collections.Generic;
using System.Text;

namespace NesneFinal
{
    interface IEuro
    {
        string IbanEuro
        {
            get;
            set;
        }
        double MiktarIbanEuro {
            get;
            set;
        }
    }
    interface IUsd
    {
        string IbanUsd
        {
            get;
            set;
        }
        double MiktarIbanUsd
        {
            get;
            set;
        }
    }

    abstract class BaseClient : IEuro, IUsd
    {
        private int hesapNo;
        private string adSoyad;
        private string password;

        protected BaseClient(int hesapNo, string adSoyad,string password, string ibanTR, double miktarIbanTR, string ıbanEuro=null, double miktarIbanEuro =0, string ıbanUsd=null, double miktarIbanUsd =0)
        {
            this.HesapNo = hesapNo;
            this.adSoyad = adSoyad;
            this.password = password;
            IbanTR = ibanTR;
            MiktarIbanTR = miktarIbanTR;
            IbanEuro = ıbanEuro;
            MiktarIbanEuro = miktarIbanEuro;
            IbanUsd = ıbanUsd;
            MiktarIbanUsd = miktarIbanUsd;


            
        }
        
        public  string IbanTR { get; set; }
        public  double MiktarIbanTR { get; set; }
        public  string IbanEuro { get; set; }
        public  double MiktarIbanEuro { get; set; }
        public  string IbanUsd { get; set; }
        public  double MiktarIbanUsd { get; set; }
        public int HesapNo { get => hesapNo; set => hesapNo = value; }
    }
}

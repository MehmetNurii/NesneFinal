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
        int MiktarIbanEuro {
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
        int MiktarIbanUsd
        {
            get;
            set;
        }
    }

    abstract class BaseClient : IEuro, IUsd
    {
        private int hesapNo;
        private string adSoyad;

        private string ibanTR = null;
        private int miktarIbanTR = 0;

        protected BaseClient(int hesapNo, string adSoyad, string ibanTR, int miktarIbanTR, string ıbanEuro=null, int miktarIbanEuro=0, string ıbanUsd=null, int miktarIbanUsd=0)
        {
            this.hesapNo = hesapNo;
            this.adSoyad = adSoyad;
            this.ibanTR = ibanTR;
            this.miktarIbanTR = miktarIbanTR;
            IbanEuro = ıbanEuro;
            MiktarIbanEuro = miktarIbanEuro;
            IbanUsd = ıbanUsd;
            MiktarIbanUsd = miktarIbanUsd;
        }

        public abstract string IbanEuro { get; set; }
        public abstract int MiktarIbanEuro { get; set; }
        public abstract string IbanUsd { get; set; }
        public abstract int MiktarIbanUsd { get; set; }
    }
}

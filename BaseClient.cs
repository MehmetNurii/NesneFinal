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
        int miktarIbanEuro {
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
        int miktarIbanUsd
        {
            get;
            set;
        }
    }

    abstract class BaseClient:IEuro,IUsd
    {
        private int hesapNo;
        private string adSoyad;
        
        private string ibanTR=null;
        private int miktarIbanTR = 0;

        private string ibanEuro = null;
        private int miktarEuro = 0;

        private string ibanUsd = null;
        private int miktarUsd = 0;
        public string IbanEuro { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int miktarIbanEuro { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string IbanUsd { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int miktarIbanUsd { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}

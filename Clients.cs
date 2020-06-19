using System;
using System.Collections.Generic;
using System.Text;

namespace NesneFinal
{
    class Clients : BaseClient 
    {
        public Clients(int hesapNo, string adSoyad, string ibanTR, int miktarIbanTR, string ıbanEuro = null, int miktarIbanEuro = 0, string ıbanUsd = null, int miktarIbanUsd = 0) : base(hesapNo, adSoyad, ibanTR, miktarIbanTR, ıbanEuro, miktarIbanEuro, ıbanUsd, miktarIbanUsd)
        {

        }

        public override string IbanEuro { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override int MiktarIbanEuro { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override string IbanUsd { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override int MiktarIbanUsd { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}

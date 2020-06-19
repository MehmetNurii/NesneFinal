using System;
using System.Collections.Generic;
using System.Text;

namespace NesneFinal
{
    class Client : BaseClient
    {
        public Client(int hesapNo, string adSoyad, string password, string ibanTR, double miktarIbanTR, string ıbanEuro = null, double miktarIbanEuro = 0, string ıbanUsd = null, double miktarIbanUsd = 0) : base(hesapNo, adSoyad, password, ibanTR, miktarIbanTR, ıbanEuro, miktarIbanEuro, ıbanUsd, miktarIbanUsd)
        {
            Database.Clients.Add(this);
            FileIO.WriteClient(this);
        }

    }


}


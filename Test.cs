﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NesneFinal
{
    public static class Test
    {
        static public void GetClients()
        {
            Database.Clients.Add(new Client(326785,"İsmail Borazan","IsmB1982","TR610003200013900000326785",350,"TR300003200016420000326785",8000));
            
            Database.Clients.Add(new Client(400129,"Kamil Hurşitgiloğulları","12Hurst34","TR610008324560000000400129",2980.45));
            
            Database.Clients.Add(new Client(388000,"Zebercet Bak","Zb1234560","TR6100072222500001200388000",19150,"tr30000722224900000138800",52.93,"TR30000822226660000238800",2850));
            
            Database.Clients.Add(new Client(201005,"Naz Gül Uçan","Mordor99","TR610032455466661200201005",666.66,null,0,"TR3000324554100800003201005",10000));
            




        }
    }
}

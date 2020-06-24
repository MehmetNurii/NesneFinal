using System;
using System.Collections.Generic;
using System.Text;

namespace NesneFinal
{
    class Database
    {
        private static Database database;

        public static List<Client> Clients = new List<Client>();
        public static Dictionary<string, double> Currencies = new Dictionary<string, double>();
        private Database()
        {

        }

        public static Database GetInstance()
        {
            if (database == null)
            {
                database = new Database();
            }

            return database;
        }
    }
}

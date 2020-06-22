using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;


namespace NesneFinal
{

    class Auth
    {
        private static List<Auth> dbAuth = new List<Auth>();

        private string username;
   
        private int counter=1;
        private DateTime blockedUntil;



        public Auth(string username)
        {
            this.username = username;
            dbAuth.Add(this);
        }

        /*
         * return 0: Hesap kilitlenmiş ve 24 saat geçmemiş
         * return 1: Hesap başarıyla giriş yaptı
         * return 2: Yanlış parola
         */
        static public int TryAuth(string username, string password)
        {
           
            
            foreach (var item in dbAuth)
            {
                if (item.username == username)
                {
                    
                    if (item.blockedUntil>DateTime.Now)
                    {
                        return 0;//24 saat kilitli
                    }
                    if (CheckCredentials(ref username, ref password)==false)
                    {
                        if (item.counter==2)
                        {
                            item.counter++;
                            item.blockedUntil = DateTime.Now.AddDays(1);
                            return 2;//Hesap 24 saatliğine kilitlendi
                        }
                        else // counter =0 veya counter = 1
                        {
                            item.counter++;
                            return 2;
                        }
                    }
                    else // Kullanıcı daha önce şifre denemesi yapmış ve bu sefer doğru 
                    {
                        new Auth(username);
                    }
                    
                    
                }
            }
            //Daha önce hiç kullanıcı adı şifre denemesi yapmadıysa aşağıda ki bloklardan birine girecektir.
            
            if (CheckCredentials(ref username, ref password))
            {
                Console.WriteLine(username+" "+password);
                new Auth(username);

                return 1;
            }
            else
            {
                new Auth(username).counter++;
              
                return 2;
            }
            
            return 3;
        }

        static private bool CheckCredentials(ref string username, ref string password)
        {

            return FileIO.ReadCredentials(ref username, getSha256Hash(password));


        }


        //Kaynak https://www.c-sharpcorner.com/article/compute-sha256-hash-in-c-sharp/

        static string getSha256Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;


namespace NesneFinal
{

    class Auth
    {
        private static List<Auth> dbAuth = new List<Auth>();//login ekranında ki denemeleri içeriyor.
        //Dosya'da tutulsun mu diye düşündüm hocam fakat ödev pdf'inde belirmtemişiniz o yüzden
        //gerek duymadım

        private string username;
   
        private int counter=1;
        private DateTime blockedUntil;
        private DateTime firstAttempt;

        private static Client WhoAmI; //anca başarıyla login olursa içi doluyor . Aktif kullanıcıyı almak için yaratıldı.



        public Auth(string username,int orderNumber) 
        {
            this.username = username;
            dbAuth.Add(this);
            if (orderNumber!=0)
            {
                WhoAmI = Database.Clients[orderNumber-1];
            }
        }

        /*
         * return 0: Hesap kilitlenmiş ve 24 saat geçmemiş
         * return 1: Hesap başarıyla giriş yaptı
         * return 2: Yanlış parola
         * 
         */
        static public int TryAuth(string username, string password)
        {

            int response = CheckCredentials(ref username, ref password);
            foreach (var item in dbAuth.ToList())
            {
                if (item.username == username)
                {
                    
                    if (item.blockedUntil>DateTime.Now)
                    {
                        return 0;//24 saat kilitli
                    }
                    
                    if (response == 0)
                    {
                        if (item.counter==2 && item.firstAttempt>DateTime.Now)
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
                        new Auth(username,response);
                        
                    }
                    
                    
                }
            }
            //Daha önce hiç kullanıcı adı şifre denemesi yapmadıysa aşağıda ki bloklardan birine girecektir.
            
            if (response != 0)
            {
                Console.WriteLine(username+" "+password);
                new Auth(username, response);
                
                return 1;
            }
            else
            {
                Auth temp = new Auth(username, response);
                temp.counter++;
                temp.firstAttempt = DateTime.Now.AddMinutes(5);
                
                return 2;
            }
            
            
        }
        public static Client ActiveAccount()
        {
            return WhoAmI;
        }
        static private int CheckCredentials(ref string username, ref string password)
        {

            return FileIO.ReadCredentials(ref username, GetSha256Hash(password));


        }


        //Kaynak https://www.c-sharpcorner.com/article/compute-sha256-hash-in-c-sharp/

        static string GetSha256Hash(string rawData)
        {
            using SHA256 sha256Hash = SHA256.Create();
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

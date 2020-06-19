using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;


namespace NesneFinal
{
    static class Auth
    {
       
        public static bool CheckCredentials(string username,string password)
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

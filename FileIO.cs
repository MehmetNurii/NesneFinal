﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace NesneFinal
{
    class FileIO
    {
        private static readonly string mainDirectory = @"c://final";
        private static readonly string clientFile = @"c://final/client.txt";
        private static readonly string authFile = @"c://final/auth.txt";
        public static void InitFile()
        {
            

            if (Directory.Exists(mainDirectory))
            {
                if (File.Exists(clientFile))
                {

                }
                else
                {
                    File.Create(clientFile);
                }

                if (!File.Exists(authFile))
                {
                    Console.WriteLine("Auth dosyası bulunamadı.");
                    Console.WriteLine("Program bitiriliyor ...");
                    Environment.Exit(0);
                }

            }
            else
            {
                CreateFinalDirectory();
                InitFile();
            }
        }

        public static void CreateFinalDirectory()
        {
            Directory.CreateDirectory(mainDirectory);
        }

        public static int ReadCredentials(ref string username, string hashedPassword)
        {
            try
            {
                using (StreamReader sr = File.OpenText(authFile))
                {
                    string[] Credentials;
                    int i = 0;
                    while (!sr.EndOfStream)
                    {
                        i++;
                        Credentials = sr.ReadLine().Split(',');

                        if (Credentials[0] == username && Credentials[1] == hashedPassword)
                        {
                            return i;
                        }
                    }

                }
                return 0;
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine($"The file was not found: '{e}'");

            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine($"The directory was not found: '{e}'");
            }
            catch (IOException e)
            {
                Console.WriteLine($"The file could not be opened: '{e}'");
            }
            return 0;
        }

      public static void WriteClient(Client client)
      {
            
            try
            {
                using (StreamWriter file = File.AppendText(clientFile)){
                    if (client.IbanTR != null)
                {
                    file.WriteLine(client.HesapNo + "," + client.IbanTR + "," + client.MiktarIbanTR);
                }
                if (client.IbanUsd != null)
                {
                    file.WriteLine(client.HesapNo + "," + client.IbanUsd + "," + client.MiktarIbanUsd);
                }
                if (client.IbanEuro != null)
                {
                    file.WriteLine(client.HesapNo + "," + client.IbanEuro + "," + client.MiktarIbanEuro);
                }
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine($"The file was not found: '{e}'");

            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine($"The directory was not found: '{e}'");
            }
            catch (IOException e)
            {
                Console.WriteLine($"The file could not be opened: '{e}'");
            }
            
        }

        public static bool CheckAccountBalance(string Iban,double amount)
        {
            try
            {

                
                using (StreamReader sr = File.OpenText(clientFile))
                {
                    string[] AccountInfo;
                    
                    while (!sr.EndOfStream)
                    {
                        AccountInfo = sr.ReadLine().Split(',');

                        if (Iban==AccountInfo[1])
                        {
                            if (amount>Convert.ToDouble( AccountInfo[2]))
                            {
                                return false;
                            }
                            else
                            {
                                return true;
                            }
                        }



                    }

                }
                return false ;
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine($"The file was not found: '{e}'");

            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine($"The directory was not found: '{e}'");
            }
            catch (IOException e)
            {
                Console.WriteLine($"The file could not be opened: '{e}'");
            }
            return false;
        }

        public static void ResetClientData()
        {
            File.Delete(clientFile);
            foreach (var item in Database.Clients)
            {
                WriteClient(item);
            }

        }
      
    }
}

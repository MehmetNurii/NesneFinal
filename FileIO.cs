using System;
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
            }
        }

        public static void CreateFinalDirectory()
        {
            Directory.CreateDirectory(mainDirectory);
        }

        public static bool ReadCredentials(ref string username, string hashedPassword)
        {
            try
            {
                using (StreamReader sr = File.OpenText(authFile))
                {
                    string[] Credentials;
                    while (!sr.EndOfStream)
                    {
                        Credentials = sr.ReadLine().Split(',');

                        if (Credentials[0] == username && Credentials[1] == hashedPassword)
                        {
                            return true;
                        }
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
            return false;
        }

      public static void WriteClient(Client client)
      {
            try
            {
                using (StreamWriter file = File.AppendText(clientFile))
                {
                    if (client.IbanTR!=null)
                    {
                        file.WriteLine(client.HesapNo+","+client.IbanTR+","+client.MiktarIbanTR);
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
      
    }
}

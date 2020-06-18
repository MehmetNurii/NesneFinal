using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NesneFinal
{
    class FileIO
    {
        private static readonly string mainDirectory = @"c://final";
        private static readonly string clientFile = @"c://final/client.txt";
        private static readonly string authFile = @"c://final/auth.txt";
        public  static void InitFile()
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
                    Console.WriteLine("Program bitiriliyor");
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
    }
}

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace NesneFinal
{
    public class UserInterface
    {
        public static void Init()
        {
            StringBuilder UserID = new StringBuilder();
            Console.Write("User ID :");
            for (int i = 0; i < 6; i++)
            {
                char key = Console.ReadKey().KeyChar;
                
                if ((key >=48 && key <=57))
                {
                    UserID.Append(key);
                }
                else if (key == 08 || key ==127 )//backspace ve del tuşları
                {
                    i = i - 2;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("UserID girdisi harf kabul etmez ");
                    Console.WriteLine("Lutfen bilgilerini yeniden giriniz ");
                    return;
                }
            }

            Console.WriteLine();

            StringBuilder Password = new StringBuilder();
            Console.Write("Password :");
            for (int i = 0; i < 8; i++)
            {
                char key = Console.ReadKey().KeyChar;

                if ((key >= 65 && key <= 97) || (key >= 90 && key <= 122) || (key >= 48 && key <= 57))
                {
                    Password.Append(key);
                }
                else if (key == 08 || key == 127)//backspace ve del tuşları
                {
                    i = i - 2;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Password girdisi sayı kabul etmez ");
                    Console.WriteLine("Lutfen bilgilerini yeniden giriniz ");
                    return;
                }
            }
           
            int response = Auth.TryAuth(UserID.ToString(), Password.ToString());
            if (response==0)
            {
                Console.WriteLine("Hesabınız 24 saatliğine kilitlidir.");
            }
            else if (response==1)
            {
                Console.WriteLine("Başarıyla giriş yaptınız. Yönlendiriliyorsunuz.");
            }
            else if (response == 2)
            {
                Console.WriteLine("Yanlış Şifre");
            }



        }

        


    }
}

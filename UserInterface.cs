using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace NesneFinal
{
    public static class UserInterface
    {
        public static void Init()
        {
            Test.GetClients();

            while (UserInterface.LoginScreen() != true) ;

            while (true)
            {
                Console.WriteLine(); Console.WriteLine(); Console.WriteLine();
                UserInterface.WelcomeScreen();
            }

        }

        private static bool LoginScreen()
        {

            StringBuilder UserID = new StringBuilder();
            Console.Write("User ID :");
            for (int i = 0; i < 6; i++)
            {
                char key = Console.ReadKey().KeyChar;

                if ((key >= 48 && key <= 57))
                {
                    UserID.Append(key);
                }
                else if (key == 08 || key == 127)//backspace ve del tuşları (silmek için)
                {
                    UserID.Length = i-1;
                    i = i - 2;
                   
                    
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("UserID girdisi harf kabul etmez ");
                    Console.WriteLine("Lutfen bilgilerini yeniden giriniz ");
                    return false;
                }

            }



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
                   
                    Password.Length = i-1;
                    i = i - 2;
                    
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Password girdisi sayı kabul etmez ");
                    Console.WriteLine("Lutfen bilgilerini yeniden giriniz ");
                    return false;
                }
            }

            int response = Auth.TryAuth(UserID.ToString(), Password.ToString());
            if (response == 0)
            {
                Console.WriteLine("Hesabınız 24 saatliğine kilitlidir.");
                return false;
            }
            else if (response == 1)
            {
                Console.WriteLine("Başarıyla giriş yaptınız. Yönlendiriliyorsunuz.");
                return true;
            }
            else if (response == 2)
            {
                Console.WriteLine("Yanlış Şifre");
                return false;
            }
            else
            {
                Console.WriteLine("Bir hata meydana geldi #101");//Hiçbir şey olmasa bile kesin birşeyler oldu ki hata veriyor
                return false;
            }

        }
        
        public static void WelcomeScreen()
        {
          
            Client ActiveSession = Auth.ActiveAccount();

            Console.WriteLine("Hoşgeldiniz" + " " + ActiveSession.AdSoyad);

            Console.WriteLine("Lütfen aşağıdaki seçeneklerden birini seçiniz ");
            Console.WriteLine("1. Bilgilerimi görüntüle");
            Console.WriteLine("2. Havale yap");
            Console.WriteLine();

            char selectedCode;
            selectedCode=Console.ReadKey().KeyChar;
            
            if (selectedCode==49)
            {
                GetClientInfo();
            }
        }

        public static void GetClientInfo()
        {
            Client ActiveSession = Auth.ActiveAccount();
            Console.WriteLine();
            Console.Write("İsim Soyisim : ");
            Console.Write(ActiveSession.AdSoyad);

            if (ActiveSession.IbanTR!=null)
            {
                Console.WriteLine(); Console.WriteLine();

                Console.WriteLine("TR HESABI");
                Console.Write("Iban :");
                Console.Write(ActiveSession.IbanTR);

                Console.WriteLine(); 

                Console.Write("Miktar :");
                Console.Write(ActiveSession.MiktarIbanTR);
            }

            if (ActiveSession.IbanEuro != null)
            {
                Console.WriteLine(); Console.WriteLine();

                Console.WriteLine("EURO HESABI");
                Console.Write("Iban :");
                Console.Write(ActiveSession.IbanEuro);

                Console.WriteLine();

                Console.Write("Miktar :");
                Console.Write(ActiveSession.MiktarIbanEuro);
            }

            if (ActiveSession.IbanUsd != null)
            {
                Console.WriteLine(); Console.WriteLine();

                Console.WriteLine("USD HESABI");
                Console.Write("Iban :");
                Console.Write(ActiveSession.IbanUsd);

                Console.WriteLine();

                Console.Write("Miktar :");
                Console.Write(ActiveSession.MiktarIbanUsd);

            }

            
        }
    }
}

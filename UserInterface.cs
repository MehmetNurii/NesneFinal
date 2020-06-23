using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace NesneFinal
{
    public static class UserInterface
    {
        public static void Init()
        {
            FileIO.InitFile();
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
        
        private static void WelcomeScreen()
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
            else if (selectedCode==50)
            {
                TransferScreen();
            }
        }

        private static void GetClientInfo()
        {
            Client ActiveSession = Auth.ActiveAccount();
            Console.WriteLine();
            Console.Write("İsim Soyisim : ");
            Console.Write(ActiveSession.AdSoyad);

            if (ActiveSession.IbanTR!=null)
            {
                Console.WriteLine(); Console.WriteLine();

                Console.WriteLine("1- TR HESABI");
                Console.Write("Iban :");
                Console.Write(ActiveSession.IbanTR);

                Console.WriteLine(); 

                Console.Write("Miktar :");
                Console.Write(ActiveSession.MiktarIbanTR);
            }

            if (ActiveSession.IbanEuro != null)
            {
                Console.WriteLine(); Console.WriteLine();

                Console.WriteLine("2- EURO HESABI");
                Console.Write("Iban :");
                Console.Write(ActiveSession.IbanEuro);

                Console.WriteLine();

                Console.Write("Miktar :");
                Console.Write(ActiveSession.MiktarIbanEuro);
            }

            if (ActiveSession.IbanUsd != null)
            {
                Console.WriteLine(); Console.WriteLine();

                Console.WriteLine("3- USD HESABI");
                Console.Write("Iban :");
                Console.Write(ActiveSession.IbanUsd);

                Console.WriteLine();

                Console.Write("Miktar :");
                Console.Write(ActiveSession.MiktarIbanUsd);

            }

            
        }

        private static void TransferScreen()
        {
            Console.WriteLine(); Console.WriteLine();
            #region kimetransfer
            Console.Write("Lütfen kime transfer edeceğinizi seçiniz ;");
            Console.WriteLine();

            for (int i = 0; i < Database.Clients.Count; i++)
            {
                Console.WriteLine(i + ") " + Database.Clients[i].AdSoyad);
            }

            int selectedPerson;
            selectedPerson = (Convert.ToInt32(Console.ReadKey().KeyChar) - 48);
            if (selectedPerson>Database.Clients.Count)
            {
                Console.WriteLine("Lütfen listedeki kişilerden birini seçiniz");
                return;
            }

            #endregion
            Console.WriteLine();

            #region karşııbansec
            Console.WriteLine("Lütfen transfer edeceğiniz kişinin Iban numarasını seçiniz :");
            Console.WriteLine();


            if (Database.Clients[selectedPerson].IbanTR != null)
            {
                Console.WriteLine(); Console.WriteLine();

                Console.WriteLine("1- TR HESABI");
                Console.Write("Iban :");
                Console.Write(Database.Clients[selectedPerson].IbanTR);

            }

            if (Database.Clients[selectedPerson].IbanEuro != null)
            {
                Console.WriteLine(); Console.WriteLine();

                Console.WriteLine("2- EURO HESABI");
                Console.Write("Iban :");
                Console.Write(Database.Clients[selectedPerson].IbanEuro);

            }

            if (Database.Clients[selectedPerson].IbanUsd != null)
            {
                Console.WriteLine(); Console.WriteLine();

                Console.WriteLine("3- USD HESABI");
                Console.Write("Iban :");
                Console.Write(Database.Clients[selectedPerson].IbanUsd);
            }


            int selectedAccount;
            selectedAccount = (Convert.ToInt32(Console.ReadKey().KeyChar) - 48);

            if (selectedAccount > 4)
            {
                Console.WriteLine("Lütfen listedeki hesaplardan birini seçiniz");
                return;
            }
            #endregion

            Console.WriteLine();
            Console.WriteLine("Lütfen hangi hesabınızdan transfer edilicek onu seçiniz :");
            GetClientInfo();

            int myselfAcoounts;
            myselfAcoounts = (Convert.ToInt32(Console.ReadKey().KeyChar) - 48);


        }
    }
}

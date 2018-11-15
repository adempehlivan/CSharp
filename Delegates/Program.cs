using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    class Program
    {
        public delegate void MyDelegate(); //void ve parametre almıyor
        public delegate void MyDelegate2(string text); //void ve parametre alıyor
        public delegate int MyDelegate3(int number1, int number2);//int döndürüyor ve parametre alıyor
        static void Main(string[] args)
        {
            //Delegeler günümüzde kullandığımız hale gelene kadar birçok versiyon çıkmıştır. Anlamı Elçi. dönüş değieri olmayan(void) methodlara ve parametre almayan methodlara delegelit yapıyor. 
            CustomerManager customerManager = new CustomerManager();
            Matematik matematik = new Matematik();
            //customerManager.SendMessage();
            //customerManager.ShowAlert();

            MyDelegate myDelegate = customerManager.SendMessage;
            myDelegate += customerManager.ShowAlert;
            myDelegate -= customerManager.SendMessage;


            MyDelegate2 myDelegate2 = customerManager.SendMessage2;
            myDelegate2 += customerManager.ShowAlert2;

            MyDelegate3 myDelegate3 = matematik.Topla;
            myDelegate3 += matematik.Carp;//return type olan delegelerede en son verilen method çalıştırılır
            Console.WriteLine(myDelegate3(3, 5));



            myDelegate2("Hello");//2 methodada aynı mesajı gönderiyoruz böyle olmak zorunda

            myDelegate();

            Console.ReadLine();
        }
    }

    public class CustomerManager
    {
        public void SendMessage()
        {
            Console.WriteLine("Hello");
        }

        public void ShowAlert()
        {
            Console.WriteLine("Alert!");
        }

        public void SendMessage2(string message)
        {
            Console.WriteLine(message);
        }

        public void ShowAlert2(string alert)
        {
            Console.WriteLine(alert);
        }
    }

    public class Matematik
    {
        public int Topla(int sayi1, int sayi2)
        {
            return sayi1 + sayi2;
        }

        public int Carp(int sayi1, int sayi2)
        {
            return sayi1 * sayi2;
        }
    }
}

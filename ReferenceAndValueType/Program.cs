using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferenceAndValueType
{
    class Program
    {
        static void Main(string[] args)
        {
            //değer tipler int boole decimal falan olay değer üzerinden ilerler
            int number1 = 10;
            int number2 = 20;
            number2 = number1;
            number1 = 30;

            Console.WriteLine(number2);

            //Referans tipler classlar interfaceler string arrayler bunlar
            string[] cities1 = new string[] {"Ankara","Adana","Afyon" };//örn olarak arkada planda bi referans numrası atılır 101
            string[] cities2 = new string[] { "Bursa", "Bolu", "Balıkesir" };//102 gibi
            cities2 = cities1; //cities2 nin referansı cities1 oldu  102 adında bi referans olmıyacağı için garbagececollecter çalışır ve arkadan atar.
            cities1[0] = "İstanbul";
            Console.WriteLine(cities2[0]);


            //aşağıdaki örnekte 2 tane new yapmasının bi amacı yok sadece programa ekstra yük bindiriyor yanlış bir kullanım.
            DataTable dataTable = new DataTable();
            DataTable dataTable2 = new DataTable();
            dataTable = dataTable2;


            ////bu şekilde kullanması daha mantıklı boşuna new dememiş oluyor
            //DataTable dataTable;
            //DataTable dataTable2 = new DataTable();
            //dataTable = dataTable2;

            Console.ReadLine();
        }
    }
}

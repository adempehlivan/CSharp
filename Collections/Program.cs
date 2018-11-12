using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            //ArrayList();
            //List();

            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.Add("book", "kitap");
            dictionary.Add("computer", "bilgisayar");
            dictionary.Add("table", "tablo");

            //anahtar kelime ile değeri çağırırız.
            Console.WriteLine(dictionary["table"]);
            //olmayan elemanı çağıramaz hata patlatır.
            //Console.WriteLine(dictionary["glass"]);

            foreach (var item in dictionary)
            {
                Console.WriteLine(item.Value);
            }

            Console.ReadLine();
        }

        private static void List()
        {
            List<string> cities = new List<string>();
            cities.Add("Ankara");
            cities.Add("İstanbul");

            //cities içide ankara geçiyorsa true döner
            var result = cities.Contains("Ankara");

            foreach (var item in cities)
            {
                Console.WriteLine(item);
            }

            List<Customer> customers = new List<Customer>();
            customers.Add(new Customer { FirstName = "Adem", Id = 1 });
            customers.Add(new Customer { FirstName = "İlayda", Id = 2 });

            var count = customers.Count;

            //Customer tipindeki Array liste gibi şeyleri toplu olarak eklemek için
            customers.AddRange(new Customer[2]
                {
                    new Customer {  Id=3, FirstName="Murat" },
                    new Customer {  Id=4, FirstName = "Nilgün"}
            });

            var customer = new Customer
            {
                FirstName = "Adem",
                Id = 10
            };
            //remove metodu ilk buldupu customer nesnesini siler
            customers.Remove(customer);
            //removeall ise adı adem olan tüm elemanları siler
            customers.RemoveAll(x => x.FirstName == "Adem");

            foreach (var item in customers)
            {
                Console.WriteLine(item.Id);
                Console.WriteLine(item.FirstName);
            }
        }

        private static void ArrayList()
        {
            //Arraylist
            ArrayList cities = new ArrayList();
            cities.Add("Ankara");
            cities.Add("Adana");


            cities.Add("İstanbul");
            Console.WriteLine(cities[2]);

            cities.Add(1);
            cities.Add('A');

            foreach (var item in cities)
            {
                Console.WriteLine(item);
            }
        }
    }

    class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
    }
}

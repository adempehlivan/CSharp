using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            Person[] persons = new Person[3] {
                 new Customer { FirstName="Adem"},
                 new Student {FirstName = "İlayda" },
                 new Person { FirstName = "Nilgün"}
            };

            foreach (var person in persons)
            {
                Console.WriteLine(person.FirstName);
            }

            Console.ReadKey();
        }

        class Person2
        {

        }

        class Person//,Person2 olmaz ama IPerson olsaydı kullanılabilirdi
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            //Birden fazla clasa inheritance yapalabilir
            //ama aynı clasa birden fazla inheritance implamente edilemez Interfacelerden farklıdır.

        }

        class Customer:Person
        {
            public string City { get; set; }
        }
        class Student:Person
        {
            public string Department { get; set; }
        }
    }
}

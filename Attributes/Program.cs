using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attributes
{
    class Program
    {
        static void Main(string[] args)
        {
            //Atributların -öznetilekier- bir nesneye veya bir metoda uygulanabilcek ayrıca yapılardır.
            Customer customer = new Customer
            {
                Age = 32,
                LastName = "Pehlivan",
                Id = 1
            };
            CustomerDal customerDal = new CustomerDal();
            customerDal.Add(customer);
            Console.ReadLine();
        }
    }

    [ToTable("Customers")]
    [ToTable("tbl_Customers")]
    class Customer
    {
        public int Id { get; set; }
        [RequiredProperty]
        public string FirstName { get; set; }
        [RequiredProperty]
        public string LastName { get; set; }
        [RequiredProperty]
        public int Age { get; set; }
    }

    class CustomerDal
    {
        [Obsolete("Dont use add, instead use AddNew Method")] //bilgilendirme mesajı çıkar bu methodu kullanırken
        public void Add(Customer customer)
        {
            Console.WriteLine($"{customer.Id},{customer.FirstName},{customer.LastName},{customer.Age} added! ");
        }
        public void AddNew(Customer customer)
        {
            Console.WriteLine($"{customer.Id},{customer.FirstName},{customer.LastName},{customer.Age} added! ");
        }
    }

    [AttributeUsage(AttributeTargets.Property)] // bunu yapmamızın nedeni bu attributenin nerden kullanılcagını seçiyoruz. | pipe koyarak birden fazla yere yapılıyor.
    class RequiredPropertyAttribute:Attribute
    {
        
    }
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]//birden fazla kullanmak için
    class ToTableAttribute:Attribute
    {
        string _tableName;
        public ToTableAttribute(string tableName)
        {
            _tableName = tableName;
        }
    }

    
}

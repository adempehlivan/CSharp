using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessModifiers
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    class Customer
    {
        private int Id { get; set; }
        //private property sadece bu class ta erişilir aşağıda customer dan erişilemez. 
        protected int Id2 { get; set; }
        //private nin tüm özelliklerini barındırır ve inherit edildiği sınıflarda kullanılır.

         public void Save()
        {
           //Id
           //Id2
        }
        public void Delete()
        {
            //Id
           // Id2
        }
    }
    class Student:Customer
    {
        public void Save2()
        {
         //Id2
        }
    }

    public class Course
    {
        //internal class bağlı olduğu projede assemby içerisinde referans ihtiyacı olmadan kullanılır. direkt nesne oluşturup çağırmak normal bişey yazılmayınca gibi
        public string Name { get; set; }
        private  class MyClass
        {
            //sacece iç içe classlar private yapılır.
        }
    }
}

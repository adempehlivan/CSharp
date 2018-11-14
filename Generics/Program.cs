using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            Utilities utilities = new Utilities();
            //aşağıda hangi tür liste verirsem methodun dönüşü bana o tipte data olsun
            List<string> result = utilities.BuildList<string>("Ankara","İzmir","Adana");
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            List<Customer> result2 = utilities.BuildList<Customer>(new Customer {  FirstName = "Adem"},new Customer {  FirstName="İlayda" });
            foreach (var item in result2)
            {
                Console.WriteLine(item.FirstName);
            }

            Console.ReadLine();
        }
    }

    class Utilities
    {
        public List<T> BuildList<T>(params T[] items)
        {
            return new List<T>(items);
        }
    }



    class Product : IEntity
    {

    }

    interface IProductDal:IRepository<Product>
    {
       
    }

    class Customer : IEntity
    {
        public string FirstName { get; set; }
    }

    interface ICustomerDal :IRepository<Customer>
    {
        
    }

    class Student :IEntity
    {
        public string FirstName { get; set; }
    }

    interface IEntity
    {

    }

    ////Generic kısıtlar aşağıda yanlışlık Student nesnesini verceğine yanlışlıkla string verdi
    //interface IStudentDal : IRepository<string>
    //{

    //}

    //Generic kısıtlar aşağıda yanlışlık Student nesnesini verceğine yanlışlıkla string verdi 
    interface IStudentDal : IRepository<Student>
    {

    }

    //generic bir interface açtığımızda aynı işlemler için aynı interfaceleri oluşturmaya gerek yok
    interface IRepository<T> where  T:class, IEntity, new() // IEntity den implemnt edilmeli // T sadece referans tip yazılabilir ama bu class olcak diye bişey yok string te bir referans tiptir. new yazılmasının nedeni newlenebilir demek yani contsractur olmak zorunda string olmaz
    {
        //yukarda T için 3 tane kısıt getirildi T:struct yaparsan değer tipi olur
        List<T> GetAll();
        T Get(int id);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }

    class ProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product entity)
        {
            throw new NotImplementedException();
        }

        public Product Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }

    //bunları direkt IReposotoryden de inheritence edebilirsin ama ilerde belki ICsutomerDal içine özel bir metod koycaksın
    class CustomerDal : ICustomerDal
    {
        public void Add(Customer entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Customer entity)
        {
            throw new NotImplementedException();
        }

        public Customer Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}

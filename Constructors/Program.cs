using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructors
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customermanager = new CustomerManager();
            customermanager.List();

            Product product = new Product { Id = 1, Name = "Laptop" };
            Product product2 = new Product(2, "Computer");

            EmployeManager employeManager = new EmployeManager(new DataBaseLogger());
            employeManager.Add();


            PersonManager personmanager = new PersonManager("Product");
            personmanager.Add();

            //static nesneler ortak nesnelerdir ama genelde uzak durmaya çalışırlır
            Teacher.Number = 10;

            Utilities.Validate();

            Manager.DoSometing();
            Manager manager = new Manager();
            manager.DoSometing2();

            Console.ReadLine();
        }
    }

    class CustomerManager
    {
        private int _count = 15;
        public CustomerManager(int count)
        {
            _count = count;
        }

        public CustomerManager()
        {

        }
        public void List()
        {
            Console.WriteLine("Listed! {0} items!", _count);
        }

        public void Add()
        {
            Console.WriteLine("Added!");
        }
    }

    class Product
    {
        public Product()
        {

        }
        private int _id;
        private string _name;
        public Product(int id, string name)
        {
            _id = id;
            _name = name;
        }
        public int Id { get; set; }
        public string Name { get; set; }
    }

    interface ILogger
    {
        void Log();
    }

    class DataBaseLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged to database");
        }
    }

    class FileLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged to file");
        }
    }

    class EmployeManager
    {
        //aşağıdaki olay contructur ile enjecte etmek
        private ILogger _logger;
        public EmployeManager(ILogger logger)
        {
            _logger = logger;
        }
        public void Add()
        {
            _logger.Log();
            Console.WriteLine("Added!");
        }
    }

    class BaseClass
    {
        private string _entity;
        public BaseClass(string entity)
        {
            _entity = entity;
        }

        public void Message()
        {
            Console.WriteLine("{0} message", _entity);
        }
    }

    class PersonManager : BaseClass
    {
        //BaseClass tan inherit edilince construction eklemek zorunda kalıyorsun ama onu o class a base olarak gönderiyorsun. 
        public PersonManager(string entity) : base(entity)
        {

        }

        public void Add()
        {
            Console.WriteLine("Added");
            Message();
        }
    }

    static class Teacher
    {
        //static nesnelerin new inin oluşturamassın
        public static int Number { get; set; }
    }

    static class Utilities
    {
        public static void Validate()
        {
            Console.WriteLine("Validation is done");
        }
    }

    class Manager
    {
        public static void DoSometing()
        {
            Console.WriteLine("Done");
        }
        public void DoSometing2()
        {
            Console.WriteLine("Done 2");
        }
    }
}

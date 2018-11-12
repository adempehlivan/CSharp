using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            //SqlServer sqlServer = new SqlServer();
            //sqlServer.Add();
            //sqlServer.Delete();

            //MySql myServer = new MySql();
            //sqlServer.Add();
            //sqlServer.Delete();

            //Yada  

            Database sqlServer = new SqlServer();
            sqlServer.Add();
            sqlServer.Delete();

            Database mySqlServer = new MySql();
            mySqlServer.Add();
            mySqlServer.Delete();

            Console.ReadLine();
        }
    }

    abstract class Database
    {
        //Tamamlanmış method
        public void Add()
        {
            Console.WriteLine("Added by Default");
        }

        //tamamlanmamış method
        public abstract void Delete();
       
    }

    class SqlServer : Database
    {
        //implemente yapmak için aşağıdaki methodun eklenmesi gerekli
        public override void Delete()
        {
            Console.WriteLine("Deleted by Sql");
        }
    }

    class MySql : Database
    {
        //implemente yapmak için aşağıdaki methodun eklenmesi gerekli
        public override void Delete()
        {
            Console.WriteLine("Deleted by MySql");
        }
    }
}

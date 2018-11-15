using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            //ExeptionIntro();

            ////TryCatch();

            //ActionDemo();

            Func<int, int, int> add = Topla; // Fucn ile method gönderme
            Console.WriteLine(add(3,5));

            Func<int> getRandomNumber = delegate() //parametresiz methoda delege , delegasyon yapar
            {//aynı action gibi func isteyebiliriz.
                Random random = new Random();
                return random.Next(1, 100);
            };

            Func<int> getRandomNumber2 = () => new Random().Next(1, 100); //  action yazılımı gibi üsttekinin kısası

            Console.WriteLine(getRandomNumber());
            Thread.Sleep(1000);//random sayılar farklı gelsin diye öylesine eklendi.
            Console.WriteLine(getRandomNumber2());
            Console.ReadLine();

        }

        static int Topla(int x,int y)
        {
            return x + y;
        }

        private static void ActionDemo()
        {
            HandleException(() =>
            {
                Find();
            });
        }

        private static void TryCatch()
        {
            try
            {
                Find();
            }
            catch (RecordNotFound exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        private static void HandleException(Action action)
        {
            try
            {
                action.Invoke();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        private static void Find()
        {
            List<string> students = new List<string> {
                "Adem","İlayda","Murat"
            };

            if (!students.Contains("Nilgün"))
                throw new RecordNotFound("Record not found");

            Console.WriteLine("Record Found");
        }

        private static void ExeptionIntro()
        {
            try
            {
                string[] students = new string[] {
                "adem","ilayda","nilgün" };
                students[3] = "Murat";
            }
            catch (IndexOutOfRangeException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}

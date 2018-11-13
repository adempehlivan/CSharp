using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            //ExeptionIntro();

            try
            {
                Find();
            }
            catch (RecordNotFound exception)
            {
                Console.WriteLine(exception.Message);
            }

            HandleException(() => {
                Find();
            });

            Console.ReadLine();

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMT_2
{
    class Program
    {
        /*Написать программу, описывающую небольшой офис, в котором работают сотрудники – 
         * объекты класса Person, обладающие полем имя (Name). 
         * Каждый из сотрудников содержит пару методов: приветствие сотрудника,
         * пришедшего на работу (принимает в качестве аргументов объект сотрудника и время его прихода) 
         * и прощание с ним (принимает только объект сотрудника). В зависимости от времени суток, 
         * приветствие может быть различным: до 12 часов – «Доброе утро», с 12 до 17 – «Добрый день»,
         * начиная с 17 часов – «Добрый вечер». Каждый раз при входе очередного сотрудника в офис,
         * все пришедшие ранее его приветствуют.
         * При уходе сотрудника домой с ним также прощаются все присутствующие. 
         */
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            //
            string[] wArray = new string[] { "Джек", "Уолли", "Рон", "Джордж", "Вилли" };
            MyList<Person> workersList = new MyList<Person>();
            Person bufPerson;
            //
            for (int i = 0; i < wArray.Length; i++)
            {
                bufPerson = new Person(new Person(wArray[i], new DateTime(2017, 6, 2, 8 + i * 2, 0, 0, 0)));
                Console.WriteLine();
                Console.WriteLine("[{0} пришёл в офис (время {1:t})]", bufPerson.Name, bufPerson.TimeCome);
                workersList.Add(bufPerson);
            }
            for (int i = 0; i < wArray.Length; i++)
            {
                workersList.Remove(workersList[0]);               
            }
            Console.ReadKey();
        }
    }
}

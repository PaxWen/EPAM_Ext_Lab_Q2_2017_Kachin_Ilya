using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMT_2
{
    class Program
    {
        /* Напишите расширяющий метод, который определяет, является ли строка положительным целым числом.
         * Методы Parse и TryParse не использовать.
         */
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            string word;
            while (true)
            {
                Console.Clear();
                Console.Write("Введите строку: ");
                word = Console.ReadLine();
                Console.WriteLine("Строка{0}является целым положительным числом.",word.StringTest()? " ":" не ");
                Console.WriteLine();
                Console.WriteLine("Для выхода нажмите \'Enter\'...");
                if (Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    break;
                }
            }
        }
    }
}

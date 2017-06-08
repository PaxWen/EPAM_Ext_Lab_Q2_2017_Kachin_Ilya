using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMT_2
{
    class Program
    {/*Написать программу, которая удваивает в первой введенной строки все символы,
        принадлежащие второй введенной строке.*/
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            string sentence1;
            string sentence2;
            int i;
            while (true)
            {
                i = 0;
                Console.Clear();
                Console.Write("Введите первую строку: ");
                sentence1 = Console.ReadLine();
                Console.Write("Введите вторую строку: ");
                sentence2 = Console.ReadLine();
                while (i < sentence1.Length)
                {
                    if (sentence2.Contains(sentence1[i]))
                    {
                        sentence1=sentence1.Insert(i,sentence1[i].ToString());
                        i += 2;
                    }else
                    {
                        i++;
                    }
                }
                Console.WriteLine("Изменённая первая строка: {0}",sentence1);
                Console.WriteLine("Для выхода нажмите \'Enter\'...");
                if (Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    break;
                }
            }
        }
    }
}

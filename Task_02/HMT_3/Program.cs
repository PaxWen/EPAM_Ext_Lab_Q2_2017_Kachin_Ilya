using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMT_3
{
    class Program
    {
        /* 
        * Написать программу, которая запрашивает с клавиатуры число N и
        * выводит на экран следующее «изображение», состоящее из N строк:
             */
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            int N;
            Console.Write("Введите целочисленное N: ");
            string buf;
            while (true)
            {
                buf = Console.ReadLine();
                if (int.TryParse(buf, out N))
                {
                    N = int.Parse(buf);
                    break;
                }
                Console.Write("Введите целое число: ");
            }
            Console.Clear();
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N - i - 1; j++)
                {
                    Console.Write(" ");
                }
                for (int j = 0; j < (i * 2) + 1; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}

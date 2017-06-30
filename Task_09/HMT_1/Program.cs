using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMT_1
{
    public class Program
    {
        /* Напишите расширяющий метод, который определяет сумму элементов массива.
         */
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            while (true)
            {
                Console.Clear();              
                int[] array = new int[10];
                Random rnd = new Random();
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = rnd.Next(-50, 50);
                    Console.Write("{0,4}", array[i]);
                }
                Console.WriteLine();
                Console.WriteLine("Сумма элементов: {0}", array.SumArray());
                Console.WriteLine("Для выхода нажмите \'Enter\'...");
                if(Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    break;
                }
            }
        }
    }
}

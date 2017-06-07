using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMT_3
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Написать программу, которая определяет сумму неотрицательных элементов в одномерном массиве. 
             * Число элементов в массиве и их тип определяются разработчиком.
             * */
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            Random rnd = new Random();
            const int N = 10;
            int[] Arr = new int[N];
            int sum;
            while (true)
            {
                Console.Clear();
                sum = 0;
                Console.Write("Массив: ");
                for (int i = 0; i < N; i++)
                {
                    Arr[i] = rnd.Next(-10, 10);
                    Console.Write("{0,4}", Arr[i]);
                    if (Arr[i]>=0)
                    {
                        sum += Arr[i];
                    }
                }
                Console.WriteLine();
                Console.WriteLine("Sum: {0}",sum);
                Console.Write("Для выхода нажмите \'Enter\'...");
                if (Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    break;
                }
            }
        }
    }
}

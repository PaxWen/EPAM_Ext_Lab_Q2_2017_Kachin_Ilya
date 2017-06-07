using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMT_1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Написать программу, которая генерирует случайным образом элементы массива 
             * (число элементов в массиве и их тип определяются разработчиком),
             *  определяет для него максимальное и минимальное значения,
             *   сортирует массив и выводит полученный результат на экран. 
             */
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            Random rnd = new Random();
            double Max;
            double Min;
            double[] Arr = new double[10];
            while (true)
            {
                Console.Clear();
                Max = double.MinValue;
                Min = double.MaxValue;
                Console.Write("Массив: ");
                for (int i = 0; i < Arr.Length;i++)
                {
                    Arr[i] = rnd.Next(-10, 10) + rnd.NextDouble();
                    if (Arr[i] > Max)
                    {
                        Max = Arr[i];
                    }
                    if (Arr[i] < Min)
                    {
                        Min = Arr[i];
                    }
                    Console.Write("{0,5:N1}", Arr[i]);
                }
                Console.WriteLine();
                double buf = 0;
                for (int i = 0; i < Arr.Length - 1; i++)
                {
                    for (int j = i + 1; j < Arr.Length; j++)
                    {
                        if (Arr[i] > Arr[j])
                        {
                            buf = Arr[i];
                            Arr[i] = Arr[j];
                            Arr[j] = buf;
                        }
                    }
                }
                Console.Write("Массив: ");
                for (int i = 0; i < Arr.Length; i++)
                {
                    Console.Write("{0,5:N1}", Arr[i]);
                }
                Console.WriteLine();
                Console.WriteLine("Min: {0,5:N1}", Min);
                Console.WriteLine("Max: {0,5:N1}", Max);
                Console.Write("Для выхода нажмите \'Enter\'...");
                if (Console.ReadKey().Key==ConsoleKey.Enter)
                {
                    break;
                }
            }
        }
    }
}

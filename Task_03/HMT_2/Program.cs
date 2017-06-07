using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMT_2
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Написать программу, которая заменяет все положительные элементы в трёхмерном массиве на нули. 
             * Число элементов в массиве и их тип определяются разработчиком.
             * */
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            Random rnd = new Random();
            const int N = 4;
            int[,,] Arr = new int[N, N, N];
            while (true)
            {
                Console.Clear();
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < N; j++)
                    {
                        for (int k = 0; k < N; k++)
                        {
                            Arr[i, j, k] = rnd.Next(-10, 10);
                        }
                    }
                }
                outArray(Arr, N);
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < N; j++)
                    {
                        for (int k = 0; k < N; k++)
                        {
                            if (Arr[i, j, k] > 0)
                            {
                                Arr[i, j, k] = 0;
                            }
                        }
                    }
                }
                outArray(Arr, N);
                Console.Write("Для выхода нажмите \'Enter\'...");
                if (Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    break;
                }
            }
        }
        static void outArray(int [,,] Arr,int N)
        {
            for (int i = 0; i < N; i++)
            {
                Console.WriteLine("{0}",i);
                for (int j = 0; j < N; j++)
                {
                    for (int k = 0; k < N; k++)
                    {
                        Console.Write("{0,4}",Arr[i,j,k]);
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}

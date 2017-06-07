using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMT_4
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Элемент двумерного массива считается стоящим на чётной позиции,
             *  если сумма номеров его позиций по обеим размерностям является чётным числом 
             *  (например, [1,1] – чётная позиция, а [1,2] - нет). 
             *  Определить сумму элементов массива, стоящих на чётных позициях.
             */
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            Random rnd = new Random();
            const int N = 10;
            int[,] Arr = new int[N,N];
            int sum;
            while (true)
            {
                Console.Clear();
                sum = 0;
                Console.WriteLine("Массив");
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < N; j++)
                    {
                        Arr[i, j] = rnd.Next(-10, 10);
                        if (((i + 1) % 2 == 0) && ((j + 1) % 2 == 0))
                        {
                            sum += Arr[i, j];
                            Console.Write("{0,4}",Arr[i,j]);
                        }
                    }
                    Console.WriteLine();
                }
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

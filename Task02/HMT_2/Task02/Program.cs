using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{
    class Program
    {
        static void Main(string[] args)
        {
            int N;
            Console.Write("Введите целочисленное N: ");
            string buf;
            while (true)
            {
                buf = Console.ReadLine();
                if (int.TryParse(buf,out N))
                {
                    N = int.Parse(buf);
                    break;
                }
                Console.Write("Введите целое число: ");
            }
            Console.Clear();
            for (int i = 1; i <= N; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}

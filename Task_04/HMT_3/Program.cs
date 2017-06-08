using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace HMT_3
{
    class Program
    {
        static void Main(string[] args)
        {/*Проведите сравнительный анализ скорости работы классов String,
            StringBuilder для операции сложения строк:*/
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            string str; ;
            StringBuilder sb;
            long sum1 = 0;
            long sum2 = 0;
            var sw = new Stopwatch();
            int N = 100;
            for (int j = 0; j < N; j++)
            {
                str = "";
                sb = new StringBuilder();
                Console.WriteLine("{0} заход", j);
                sw.Start();
                for (int i = 0; i < N; i++)
                {
                    str += "*";
                }
                sw.Stop();
                sum1 += sw.ElapsedTicks;
                Console.WriteLine("String выполнился за: {0} тиков", sw.ElapsedTicks);
                sw.Reset();
                sw.Start();
                for (int i = 0; i < N; i++)
                {
                    sb.Append("*");
                }
                sw.Stop();
                sum2 += sw.ElapsedTicks;
                Console.WriteLine("StringBuilder выполнился за: {0} тиков", sw.ElapsedTicks);
                sw.Reset();
                Console.WriteLine();
            }
            Console.WriteLine("Среднее выполнение класса String = {0}",sum1/N);
            Console.WriteLine("Среднее выполнение класса StringBuilder = {0}", sum2 / N);
            Console.ReadKey();
        }

    }
}

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
            double b;
            double a;
            //
            Console.Write("Введите A: ");
            string buf;
            while (true)
            {
                buf = Console.ReadLine();
                if (Double.TryParse(buf, out a))
                {
                    a = Double.Parse(buf);
                    if (a > 0)
                    {
                        break;
                    }
                }
                Console.Write("Ввод неверен, попробуйте снова: ");
            }
            //
            Console.Write("Введите B: ");
            while (true)
            {
                buf = Console.ReadLine();
                if (Double.TryParse(buf, out b))
                {
                    b = Double.Parse(buf);
                    if (b > 0)
                    {
                        break;
                    }
                }
                Console.Write("Ввод неверен, попробуйте снова: ");
            }
            //
            Console.WriteLine("Площадь прямоугольника равна {0}",a*b);
            Console.ReadKey();
        }
    }
}

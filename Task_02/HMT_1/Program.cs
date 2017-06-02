using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMT_1
{
    class Program
    {
        /* 
        * Написать программу, которая определяет площадь прямоугольника со сторонами a и b.
        * Если пользователь вводит некорректные значения (отрицательные, или 0), должно выдаваться сообщение об ошибке.
        * Возможность ввода пользователем строки вида «абвгд», или нецелых чисел игнорировать.
         */
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
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
            Console.WriteLine("Площадь прямоугольника равна {0}", a * b);
            Console.ReadKey();
        }
    }
}

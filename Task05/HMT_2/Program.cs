using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMT_2
{
    /*
     * Написать класс, описывающий треугольник со сторонами a, b, c, и позволяющий 
     * осуществить расчёт его площади и периметра. Написать программу,
     *  демонстрирующую использование данного треугольника.
     */
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            string InputString = "";
            bool ExitBool = true;
            Triangle Triangle1 = null;
            while (ExitBool)
            {
                Console.Clear();
                Console.WriteLine(Triangle1 != null ? string.Format("Сторона А = {0,5:N1}; Сторона B = {1,5:N1}; Сторона C = {2,5:N1}", Triangle1.A, Triangle1.B, Triangle1.C) : "Параметры не заданы");
                Console.WriteLine("Введите нужную вам опцию");
                Console.WriteLine("1: Задать стороны треугольника.");
                Console.WriteLine("2: Получить периметр треугольника.");
                Console.WriteLine("3: Получить площадь треугольника.");
                Console.WriteLine("4: Выход из программы.");
                InputString = Console.ReadLine();
                switch (InputString)
                {
                    case "1":
                        {
                            double a;
                            double b;
                            double c;
                            string buf;
                            Console.Clear();
                            Console.WriteLine("Введите сторону A треугольника: ");
                            for (;;)
                            {
                                buf = Console.ReadLine();
                                if (!double.TryParse(buf, out a))
                                {
                                    Console.WriteLine("Значение введено не правильно");
                                }
                                else
                                {
                                    if (double.Parse(buf) > 0)
                                    {
                                        a = double.Parse(buf);
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Сторона должна быть больше нуля");
                                    }
                                }
                            }
                            Console.WriteLine("Введите сторону B треугольника: ");
                            for (;;)
                            {
                                buf = Console.ReadLine();
                                if (!double.TryParse(buf, out b))
                                {
                                    Console.WriteLine("Значение введено не правильно");
                                }
                                else
                                {
                                    if (double.Parse(buf) > 0)
                                    {
                                        b = double.Parse(buf);
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Сторона должна быть больше нуля");
                                    }
                                }
                            }
                            Console.WriteLine("Введите сторону C треугольника: ");
                            for (;;)
                            {
                                buf = Console.ReadLine();
                                if (!double.TryParse(buf, out c))
                                {
                                    Console.WriteLine("Значение введено не правильно");
                                }
                                else
                                {
                                    if (double.Parse(buf) > 0)
                                    {
                                        c = double.Parse(buf);
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Сторона должна быть больше нуля");
                                    }
                                }
                            }
                            if ((a + b >= c) && (b + c >= a) && (c + a >= b))
                            {
                                Triangle1 = new Triangle(a, b, c);
                            }else
                            {
                                Console.WriteLine("Сторонны введены неверно (сумма 1 и 2 сторон должна быть больше или равна 3 стороне)");
                                Console.WriteLine("Для продолжения нажмите любую кнопку...");
                                Console.ReadKey();
                            }
                            break;
                        }
                    case "2":
                        {
                            Console.WriteLine(Triangle1 != null ? string.Format("Периметр треугольника = {0,5:N1}", Triangle1.GetPerimeter()) : "Сначала требуется ввести параметры");
                            Console.WriteLine("Для продолжения нажмите любую кнопку...");
                            Console.ReadKey();
                            break;
                        }
                    case "3":
                        {
                            Console.WriteLine(Triangle1 != null ? string.Format("Площадь треугольника = {0,5:N1}", Triangle1.GetArea()) : "Сначала требуется ввести параметры");
                            Console.WriteLine("Для продолжения нажмите любую кнопку...");
                            Console.ReadKey();
                            break;
                        }
                    case "4":
                        {
                            ExitBool = false;
                            break;
                        }
                }
            }
        }
    }
}

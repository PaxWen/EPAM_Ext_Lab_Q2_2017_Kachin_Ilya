using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMT_2
{
    class Program
    {
        /*
         * Создать класс Ring (кольцо), описываемое координатами центра, 
         * внешним и внутренним радиусами, а также свойствами, позволяющими узнать
         *  площадь кольца и суммарную длину внешней и внутренней границ кольца.
         *   Обеспечить нахождение класса в заведомо корректном состоянии.
         * */
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            string InputString = "";
            bool ExitBool = true;
            Ring Ring1 = null;
            while (ExitBool)
            {
                Console.Clear();
                if (Ring1 != null) {
                    Console.WriteLine("X центра = {0,5:N1}; Y центра = {1,5:N1};", Ring1.X, Ring1.Y);
                    Console.WriteLine("Радиус внешнего круга = {0,5:N1}; Радиус внутреннего круга = {1,5:N1}", Ring1.X, Ring1.Y, Ring1.Outer.Radius, Ring1.Inner.Radius);
                }else
                {
                    Console.WriteLine("Параметры не заданы");
                }
                Console.WriteLine("Введите нужную вам опцию");
                Console.WriteLine("1: Задать центр и радиусы кольца.");
                Console.WriteLine("2: Получить сумму длинн кольца.");
                Console.WriteLine("3: Получить площадь кольца.");
                Console.WriteLine("4: Выход из программы.");
                InputString = Console.ReadLine();
                switch (InputString)
                {
                    case "1":
                        {
                            double x;
                            double y;
                            double rO;
                            double rI;
                            Console.Clear();
                            Console.WriteLine("Введите X центра круга: ");
                            string buf;
                            for (;;)
                            {
                                buf = Console.ReadLine();
                                if (!double.TryParse(buf, out x))
                                {
                                    Console.WriteLine("Значение введено не правильно");
                                }
                                else
                                {
                                    x = double.Parse(buf);
                                    break;
                                }
                            }
                            Console.WriteLine("Введите Y центра окружности: ");
                            for (;;)
                            {
                                buf = Console.ReadLine();
                                if (!double.TryParse(buf, out y))
                                {
                                    Console.WriteLine("Значение введено не правильно");
                                }
                                else
                                {
                                    y = double.Parse(buf);
                                    break;
                                }
                            }
                            Console.WriteLine("Введите внешний радиус круга: ");
                            for (;;)
                            {
                                buf = Console.ReadLine();
                                if (!double.TryParse(buf, out rO))
                                {
                                    Console.WriteLine("Значение введено не правильно");
                                }
                                else
                                {
                                    if (double.Parse(buf) > 0)
                                    {
                                        rO = double.Parse(buf);
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Радиус должен быть больше или равен 0");
                                    }
                                }
                            }
                            Console.WriteLine("Введите внутренний радиус круга: ");
                            for (;;)
                            {
                                buf = Console.ReadLine();
                                if (!double.TryParse(buf, out rI))
                                {
                                    Console.WriteLine("Значение введено не правильно");
                                }
                                else
                                {
                                    if ((double.Parse(buf) > 0)&&(double.Parse(buf)<rO))
                                    {
                                        rI = double.Parse(buf);
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Радиус должен быть больше или равен 0 и меньше внешнего радиуса");
                                    }
                                }
                            }
                            Ring1 = new Ring(x, y, rO,rI);
                            break;
                        }
                    case "2":
                        {
                            Console.WriteLine(Ring1 != null ? string.Format("Сумма длинн окружностей кольца = {0,5:N1}", Ring1.GetSumLenghRing()) : "Сначала требуется ввести параметры");
                            Console.WriteLine("Для продолжения нажмите любую кнопку...");
                            Console.ReadKey();
                            break;
                        }
                    case "3":
                        {
                            Console.WriteLine(Ring1 != null ? string.Format("Площадь кольца = {0,5:N1}", Ring1.GetArea()) : "Сначала требуется ввести параметры");
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

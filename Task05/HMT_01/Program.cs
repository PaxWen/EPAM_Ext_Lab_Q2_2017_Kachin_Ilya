using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMT_01
{
    /*
     * Написать класс Round, задающий круг с указанными координатами центра, 
     * радиусом, а также свойствами, позволяющими узнать длину описанной окружности 
     * и площадь круга. Обеспечить нахождение объекта в заведомо корректном состоянии.
     * Написать программу, демонстрирующую использование данного круга.
     */
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            string InputString="";
            bool ExitBool = true;
            Round Round1=null;
            while (ExitBool)
            {
                Console.Clear();
                Console.WriteLine(Round1!=null?string.Format("X центра = {0,5:N1}; Y центра = {1,5:N1}; Радиус = {2,5:N1}", Round1.CenterX,Round1.CenterY,Round1.Radius):"Параметры не заданы");
                Console.WriteLine("Введите нужную вам опцию");
                Console.WriteLine("1: Задать центр окружности и радиус окружности.");
                Console.WriteLine("2: Получить длинну окружности.");
                Console.WriteLine("3: Получить площадь окружности.");
                Console.WriteLine("4: Выход из программы.");
                InputString =Console.ReadLine();
                switch (InputString)
                {
                    case "1":
                        {
                            double x;
                            double y;
                            double r;
                            Console.Clear();
                            Console.WriteLine("Введите X центра окружности: ");
                            string buf;
                            for (;;)
                            {
                                buf=Console.ReadLine();
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
                            Console.WriteLine("Введите радиус окружности: ");
                            for (;;)
                            {
                                buf = Console.ReadLine();
                                if (!double.TryParse(buf, out r))
                                {
                                    Console.WriteLine("Значение введено не правильно");
                                }
                                else
                                {
                                    if (double.Parse(buf) > 0)
                                    {
                                    r = double.Parse(buf);
                                    break;
                                    }else
                                    {
                                        Console.WriteLine("Радиус должен быть больше или равен 0");
                                    }        
                                }
                            }
                            Round1 = new Round(x,y,r);
                            break;
                        }
                    case "2":
                        {
                            Console.WriteLine(Round1 != null?string.Format("Длинна окружности = {0,5:N1}", Round1.GetLength()):"Сначала требуется ввести параметры");
                            Console.WriteLine("Для продолжения нажмите любую кнопку...");
                            Console.ReadKey();
                            break;
                        }
                    case "3":
                        {
                            Console.WriteLine(Round1 != null ? string.Format("Площадь окружности = {0,5:N1}", Round1.GetArea()) : "Сначала требуется ввести параметры");
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

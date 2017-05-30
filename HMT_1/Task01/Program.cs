using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01
{
   /* Написать консольное приложение, которое проверяет принадлежность точки заштрихованной области.
      Пользователь вводит координаты точки (x; y) и выбирает букву графика(a-к). В консоли должно высветиться 
      сообщение: «Точка[(x; y)] принадлежит фигуре[г]».
      */
    class Program
    {
        public static void Main(string[] args)
        {
            double x;
            double y;
            bool b=false;
            Console.Write("Введите X точки : ");
            x=Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите Y точки : ");
            y = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите букву графика, которому должна принадлежать точка : ");
            string a = Console.ReadLine();
            switch (a)
            {
                case "а":
                    {
                        if (Math.Pow(x,2) + Math.Pow(y, 2)<=1)
                        {
                            b = true;
                        }
                        break;
                    }
                case "б":
                    {
                        if ((Math.Pow(x, 2) + Math.Pow(y, 2) <= 1)&&(Math.Pow(x, 2) + Math.Pow(y, 2) > 0.5))
                        {
                            b = true;
                        }
                        break;
                    }
                case "в":
                    {
                        if ((Math.Abs(x) <= 1) && (Math.Abs(y) <= 1))
                        {
                            b = true;
                        }
                        break;
                    }
                case "г":
                    {
                        if (x > 0)
                        {
                            if (inTriangle(x, 0, 1, 0, y, 1, 0, -1))
                            {
                                b = true;
                            }
                        }
                        else
                        {
                            if (inTriangle(x, 0, -1, 0, y, 1, 0, -1))
                            {
                                b=true;
                            }
                        }
                        break;
                    }
                case "д":
                    {
                        if (x > 0)
                        {
                            if (inTriangle(x, 0, 0.5, 0, y, 1, 0, -1))
                            {
                                b = true;
                            }
                        }
                        else
                        {
                            if (inTriangle(x, 0, -0.5, 0, y, 1, 0, -1))
                            {
                                b = true;
                            }
                        }
                        break;
                    }
                case "е":
                    {
                        if (x >= 0)
                        {
                            if (Math.Pow(x, 2) + Math.Pow(y, 2) <= 1)
                            {
                                b = true;
                            }
                        }else
                        {
                           if (inTriangle(x, -2, 0, 0, y, 0, 1, -1))
                            {
                                b = true;
                            }
                        }
                        break;
                    }
                case "ж":
                    {
                        if (inTriangle(x, -1, 0, 1, y, -1, 2, -1))
                        {
                            b = true;
                        }
                            break;
                    }
                case "з":
                    {
                        if (y >= 0)
                        {
                            if (x >= 0)
                            {
                                if (inTriangle(x,-1,-1,0,y,0,1,0))
                                {
                                    b = true;
                                }
                            }else
                            {
                                if (inTriangle(x, 0, 1, 1, y, 0, 0, 1))
                                {
                                    b = true;
                                }
                            }
                        }else
                        {
                            if (((y < 0) && (y > -2)) && ((x >= -1) && (x <= 1)))
                            {
                                b = true;
                            }
                        }
                        break;
                    }
                case "и":
                    {
                        if ((inTriangle(x, -2, -1, 1, y, -1, 1, 0)) && (!inTriangle(x, -1, 0, 1, y, 1, 0, 0)))
                        {
                            b = true;
                        }
                        break;
                    }
                case "к":
                    {
                        if (y>1)
                        {
                            b = true;
                        }else
                        {
                            if (inTriangle(x,0,-1,1,y,0,1,1))
                            {
                                b = true;
                            }
                        }
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Данный график не найден");
                        break;
                    }
            }
            if (b)
            {
                Console.WriteLine("Точка ({0};{1}) принадлежит фигуре {2}", x, y, a);
            }
            else
            {
                Console.WriteLine("Точка ({0};{1}) не принадлежит фигуре {2}", x, y, a);
            }
            Console.ReadKey();

        }
        public static bool inTriangle(double x0, double x1, double x2, double x3, double y0, double y1, double y2, double y3)
        {
            double t1 = (x1 - x0) * (y2 - y1) - (x2 - x1) * (y1 - y0);
            double t2 = (x2 - x0) * (y3 - y2) - (x3 - x2) * (y2 - y0);
            double t3 = (x3 - x0) * (y1 - y3) - (x1 - x3) * (y3 - y0);
            
            return (( (t1>=0) && (t2 >= 0) && (t3 >= 0)) || ((t1 <= 0) && (t2 <= 0) && (t3 <= 0)));
        }
    }
    
}

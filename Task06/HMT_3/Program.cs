using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMT_3
{ 
    class Program
    {/*Напишите заготовку для векторного графического редактора. Полная версия редактора должна позволять создавать и выводить на экран такие фигуры как: Линия, Окружность, Прямоугольник, Круг, Кольцо. Заготовка, для упрощения, должна представлять собой консольное приложение с функционалом:
       1. Создать фигуру выбранного типа по произвольным координатам.
       2. Вывести фигуры на экран (для каждой фигуры вывести на консоль её тип и значения параметров).
    */
        static void Main(string[] args)
        {
            List<Line> LineArr = new List<Line>();
            List<Round> RoundArr = new List<Round>();
            List<Rectangle> RectangleArr = new List<Rectangle>();
            List<Circle> CircleArr = new List<Circle>();
            List<Ring> RingArr = new List<Ring>();
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            string InputString = "";
            bool ExitBool = true;
            while(ExitBool)
            {
                Console.Clear();
                Console.WriteLine((LineArr.Count!=0)||(RoundArr.Count != 0) ||(RectangleArr.Count != 0) ||(CircleArr.Count != 0) ||(RingArr.Count != 0) ?"Нарисованные фигуры":"Фигуры не заданы");
                for (int i = 0; i < LineArr.Count; i++)
                {
                    Console.WriteLine(LineArr[i].ToString());
                }
                for (int i = 0; i < RoundArr.Count; i++)
                {
                    Console.WriteLine(RoundArr[i].ToString());
                }
                for (int i = 0; i < RectangleArr.Count; i++)
                {
                    Console.WriteLine(RectangleArr[i].ToString());
                }
                for (int i = 0; i < CircleArr.Count; i++)
                {
                    Console.WriteLine(CircleArr[i].ToString());
                }
                for (int i = 0; i < RingArr.Count; i++)
                {
                    Console.WriteLine(RingArr[i].ToString());
                }
                Console.WriteLine("Введите нужную вам опцию");
                Console.WriteLine("1: Задать новую фигуру.");
                Console.WriteLine("2: Очистить буфер фигур.");
                Console.WriteLine("3: Выход из программы.");
                InputString = Console.ReadLine();
                switch (InputString)
                {
                    case "1":
                        {
                            string bufInputSting;
                            Console.WriteLine("1:Линия");
                            Console.WriteLine("2:Окружность");
                            Console.WriteLine("3:Прямоугольник");
                            Console.WriteLine("4:Круг");
                            Console.WriteLine("5:Линия");
                            Console.Write("Выберете тип фигуры: ");
                            bufInputSting = Console.ReadLine();
                            switch (bufInputSting)
                            {
                                case "1":
                                    {
                                        double x1 = InsertDouble("X1", double.MinValue, "");
                                        double y1 = InsertDouble("Y1", double.MinValue, "");
                                        double x2 = InsertDouble("X2", double.MinValue, "");
                                        double y2 = InsertDouble("Y2", double.MinValue, "");
                                        LineArr.Add(new Line(x1,y1,x2,y2));
                                        break;
                                    }
                                case "2":
                                    {
                                        double x = InsertDouble("X Центра", double.MinValue, "");
                                        double y = InsertDouble("Y Центра", double.MinValue, "");
                                        double r = InsertDouble("радиус", 0, "Радиус не может быть отрицательный");
                                        RoundArr.Add(new Round(x,y,r));
                                        break;
                                    }
                                case "3":
                                    {
                                        double x = InsertDouble("X Центра", double.MinValue, "");
                                        double y = InsertDouble("Y Центра", double.MinValue, "");
                                        double a = InsertDouble("Длину стороны А", 0, "Длинна не может быть отрицательный");
                                        double b = InsertDouble("Длину стороны B", 0, "Длинна не может быть отрицательный");
                                        RectangleArr.Add(new Rectangle(x,y,a,b));
                                        break;
                                    }
                                case "4":
                                    {
                                        double x = InsertDouble("X Центра", double.MinValue, "");
                                        double y = InsertDouble("Y Центра", double.MinValue, "");
                                        double r = InsertDouble("радиус", 0, "Радиус не может быть отрицательный");
                                        CircleArr.Add(new Circle(x, y, r));
                                        break;
                                    }
                                case "5":
                                    {
                                        double x = InsertDouble("X Центра", double.MinValue, "");
                                        double y = InsertDouble("Y Центра", double.MinValue, "");
                                        double rO = InsertDouble("радиус", 0, "Радиус не может быть отрицательный");
                                        double rI = InsertDouble("радиус", 0, "Радиус не может быть отрицательный");
                                        RingArr.Add(new Ring(x, y, rO,rI));
                                        break;
                                    }
                            }
                            break;
                        }
                    case "2":
                        {
                            LineArr.Clear();
                            RoundArr.Clear();
                            RectangleArr.Clear();
                            CircleArr.Clear();
                            RingArr.Clear();
                            break;
                        }
                    case "3":
                        {
                            ExitBool = false;
                            break;
                        }
                }
            }
        }

        static double InsertDouble(string NameValue,double MoreThanAddCond,string ErrorAddCond)
        {
            Console.WriteLine("Введите {0}: ",NameValue);
            string bufString;
            double buf; 
            for (;;)
            {
                bufString = Console.ReadLine();
                if (double.TryParse(bufString, out buf))
                {
                    if (double.Parse(bufString)>MoreThanAddCond)
                    {
                        buf = double.Parse(bufString);
                        break;
                    }else
                    {
                        Console.WriteLine("{0}",ErrorAddCond);
                    }
                    
                }
                else
                {
                    Console.WriteLine("Значение введено неверно");
                }
            }
            return buf;
        }
    }
}

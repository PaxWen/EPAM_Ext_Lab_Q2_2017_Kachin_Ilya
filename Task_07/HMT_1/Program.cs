using System;
using System.Collections.Generic;
using System.Text;

namespace HMT_1
{
    /*В кругу стоят N человек, пронумерованных от 1 до N. 
     * При ведении счета по кругу вычёркивается каждый второй человек, пока не останется один.
     *  Составить программу, моделирующую процесс.
     */
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            for (;;)
            {
                Console.Clear();
                int n = InsertInt("Количество людей", 0, "Человек не должно быть меньше 0");
                List<string> lPerson = new List<string>();
                for (int i = 0; i < n; i++)
                {
                    lPerson.Add(string.Format("PerNum{0}", i));
                }
                n = 0;
                while (lPerson.Count > 1)//todo pn что то у тебя с выводом не то. Там в оставших и выбывших одни и те же люди. В конце должен остаться 1 человек.
                {
                    n++;
                    Console.WriteLine("Круг №{0}", n);
                    Console.WriteLine("Оставшиеся люди: ");
                    OutToConsole(lPerson.ToArray());
                    Console.WriteLine("Выбывшие: ");
                    for (int i = 0; i < lPerson.Count; i++)
                    {
                        if (i % 2 != 0)
                        {
                            Console.WriteLine(lPerson[i]);
                            lPerson[i] = null;
                        }
                    }
                    lPerson.RemoveAll((x) => x == null);
                }
                Console.WriteLine("Для выхода нажмите \' Enter\'... ");
                if (Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    break;
                }
            }

        }
        public static void OutToConsole(string[] persons)
        {
            foreach (var item in persons)
            {
                Console.Write("{0}; ", item);
            }
            Console.WriteLine();
        }
        public static int InsertInt(string nameValue, int moreThanAddCond, string errorAddCond)
        {
            Console.Write("Введите {0}: ", nameValue);
            string bufString;
            int buf;
            for (;;)
            {
                bufString = Console.ReadLine();
                if (int.TryParse(bufString, out buf))
                {
                    if (int.Parse(bufString) > moreThanAddCond)
                    {
                        buf = int.Parse(bufString);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("{0}", errorAddCond);
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

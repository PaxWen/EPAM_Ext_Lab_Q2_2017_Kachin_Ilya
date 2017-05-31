﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{
    class Program
    {
        enum TextView
        {
            Reset,
            Bold,
            Italic,
            Underline
        }
        static void Main(string[] args)
        {
            List<TextView> t = new List<TextView>();
            string buf;
            int a;
            while (true)
            {
                onConsole(t);
                buf = Console.ReadLine();
                if ((int.TryParse(buf, out a))&&((int.Parse(buf)>=0)&&(int.Parse(buf) <= 3)))
                {
                    a = int.Parse(buf);
                    switch (a)
                    {
                        case 0:
                            {
                                t.Clear();
                                break;
                            }
                        case 1:
                            {
                                bool b = true;
                                for (int i = 0; i < t.Count; i++)
                                {
                                    if (t[i]==TextView.Bold)
                                    {
                                        b = false;
                                        break;
                                    }
                                    
                                }
                                if (b)
                                {
                                    t.Add(TextView.Bold);
                                }
                                break;
                            }
                        case 2:
                            {
                                bool b = true;
                                for (int i = 0; i < t.Count; i++)
                                {
                                    if (t[i] == TextView.Italic)
                                    {
                                        b = false;
                                        break;
                                    }
                                }
                                if (b)
                                {
                                    t.Add(TextView.Italic);
                                }
                                break;
                            }
                        case 3:
                            {
                                bool b = true;
                                for (int i = 0; i < t.Count; i++)
                                {
                                    if (t[i] == TextView.Underline)
                                    {
                                        b = false;
                                        break;
                                    }  
                                }
                                if (b)
                                {
                                    t.Add(TextView.Underline);
                                }
                                break;
                            }
                    }
                }
                else
                {
                    Console.WriteLine("Неверный ввод");
                }
            }

        }
        static void onConsole(List<TextView> t)
        {
            Console.Write("Параметры надписи: ");
            for (int i = 0; i < t.Count; i++)
            {
                if(i!= t.Count - 1)
                {
                    Console.Write("{0}, ",t[i]);
                }else
                {
                    Console.Write("{0}",t[i]);
                }
            }
            Console.WriteLine();
            Console.WriteLine("\t {0}:{1}",(int)TextView.Reset,TextView.Reset);
            Console.WriteLine("\t {0}:{1}", (int)TextView.Bold, TextView.Bold);
            Console.WriteLine("\t {0}:{1}", (int)TextView.Italic, TextView.Italic);
            Console.WriteLine("\t {0}:{1}", (int)TextView.Underline, TextView.Underline);

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMT_4
{
    class Program
    {/*
             * Написать свой собственный класс MyString, описывающий 
             * строку как массив символов. Перегрузить для этого 
             * класса типовые операции.
             */
        static void Main(string[] args)
        {
            
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            MyString myString1= new MyString("This Char Array".ToCharArray());
            Console.WriteLine(myString1.ToString());
            MyString myString2 = new MyString(" but this string".ToCharArray());
            Console.WriteLine("MyString1 + MyString2: {0}",myString2.ToString());
            myString1 += myString2;
            Console.WriteLine("MyString1: {0}", myString1.ToString());
            Console.WriteLine("MyString1==MyString2: {0}",myString1==myString2);
            Console.WriteLine("MyString1!=MyString2: {0}", myString1 != myString2);
            Console.WriteLine("Hcode (MyString1): {0}", myString1.GetHashCode());
            Console.WriteLine("Hcode (MyString2): {0}", myString2.GetHashCode());
            Console.WriteLine("MyString1.Equals(MyString2): {0}", myString1.Equals(myString2));
            Console.WriteLine("MyString1.Equals(MyString1): {0}", myString1.Equals(myString1));
            Console.ReadKey();
        }
    }
}

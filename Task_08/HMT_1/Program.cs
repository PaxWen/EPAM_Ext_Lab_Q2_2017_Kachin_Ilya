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
         * Написать программу, выполняющую сортировку массива строк по возрастанию длины.
         * Если строки состоят из равного числа символов, их следует отсортировать по алфавиту.
         * Реализовать метод сравнения строк отдельным методом, передаваемым в сортировку через делегат.
         */
        public delegate bool compareDel(string a, string b);//todo pn ты не выполнил условие задания. Нужно сделать отдельный метод сравнения, в который входным параметром придет делегат.
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            compareDel delToCompare = CompareString;
            string[] stringArray = new string[] {"124","223","12233","as","1","23","2442" };
            for (int i = 0; i < stringArray.Length-1; i++)
            {
                for (int j = i; j < stringArray.Length; j++)
                {
                    if (delToCompare(stringArray[i], stringArray[j]))
                    {
                        swap(ref stringArray[i], ref stringArray[j]);
                    }
                }
            }
            for (int i = 0; i < stringArray.Length; i++)
            {
                Console.WriteLine("Строка {0}: {1}",i,stringArray[i]);
            }
            Console.ReadKey();
        }
        public static bool CompareString(string text1, string text2)//если true, значит правая больше
        {
            if (text1.Length != text2.Length)
            {
                return text1.Length > text2.Length;
            }
            return String.Compare(text1, text2)<0;
        }
        private static void swap(ref string text1,ref string text2)
        {
            string buf = text1;
            text1 = text2;
            text2 = buf;
        }
    }
}

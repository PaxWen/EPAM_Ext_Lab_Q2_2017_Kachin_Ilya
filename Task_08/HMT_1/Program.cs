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
            string[] stringArray1 = new string[] { "124", "223", "12233", "as", "1", "23", "2442" };
            string[] stringArray2 = new string[] { "124", "223", "12233", "as", "1", "23", "2442" };
            StringSort(ref stringArray1,CompareStringUp);
            StringSort(ref stringArray2, CompareStringDown);
            for (int i = 0; i < stringArray1.Length; i++)
            {
                Console.WriteLine("Строка {0}: {1}",i,stringArray1[i]);
            }
            Console.WriteLine();
            for (int i = 0; i < stringArray2.Length; i++)
            {
                Console.WriteLine("Строка {0}: {1}", i, stringArray2[i]);
            }
            Console.ReadKey();
        }
        public static bool CompareStringUp(string text1, string text2)//если true, значит правая больше
        {
            if (text1.Length != text2.Length)
            {
                return text1.Length > text2.Length;
            }
            return String.Compare(text1, text2)<0;
        }
        public static bool CompareStringDown(string text1, string text2)//если true, значит левая больше
        {
            if (text1.Length != text2.Length)
            {
                return text1.Length < text2.Length;
            }
            return String.Compare(text1, text2) > 0;
        }
        public static void StringSort(ref string[] arrString,compareDel metodSort)
        {
            for (int i = 0; i < arrString.Length - 1; i++)
            {
                for (int j = i; j <arrString.Length; j++)
                {
                    if (metodSort(arrString[i],arrString[j]))
                    {
                        swap(ref arrString[i], ref arrString[j]);
                    }
                }
            }
        }
        private static void swap(ref string text1,ref string text2)
        {
            string buf = text1;
            text1 = text2;
            text2 = buf;
        }
    }
}

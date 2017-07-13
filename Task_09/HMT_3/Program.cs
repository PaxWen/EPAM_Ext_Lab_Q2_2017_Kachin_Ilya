using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;

namespace HMT_3
{
    class Program
    {
        /*   Написать методы поиска элемента в массиве (например, поиск всех положительных элементов в массиве) в виде:
         *   1. Метода, реализующего поиск напрямую;
         *   2. Метода, которому условие поиска передаётся через делегат;
         *   3. Метода, которому условие поиска передаётся через делегат в виде анонимного метода;
         *   4. Метода, которому условие поиска передаётся через делегат в виде лямбда-выражения;
         *   5. LINQ-выражения
         *   Сравнить скорость выполнения вычислений. 
         */
        public delegate bool SearchObject(int a,int b);
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            const int N = 200;
            int[] arr = new int[N];
            Random rnd = new Random();
            Stopwatch time = new Stopwatch();
            SearchObject searchCondition = MoreNumber;
            while (true)
            {
                Console.Clear();
                Console.Write("Массив: ");
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = rnd.Next(-10, 10);
                    Console.Write("{0,4}",arr[i]);
                }
                Console.WriteLine();
                //1
                time.Reset();
                time.Start();
                FirstMetod(arr);
                time.Stop();
                Console.WriteLine("Время метода: {0}",time.ElapsedTicks);
                //2
                time.Reset();
                time.Start();
                SecondMetod(arr,MoreNumber);
                time.Stop();
                Console.WriteLine("Время метода: {0}", time.ElapsedTicks);
                //3
                time.Reset();
                time.Start();
                ThirdMetod(arr,delegate(int a,int b) { return a > b; });
                time.Stop();
                Console.WriteLine("Время метода: {0}", time.ElapsedTicks);
                //4
                time.Reset();
                time.Start();
                FourthMetod(arr,(int a,int b) => a>b );
                time.Stop();
                Console.WriteLine("Время метода: {0}", time.ElapsedTicks);
                //5
                time.Reset();
                time.Start();
                FifthMetod(arr);
                time.Stop();
                Console.WriteLine("Время метода: {0}", time.ElapsedTicks);
                //
                Console.WriteLine();
                Console.WriteLine("Для выхода нажмите \'Enter\'...");
                if (Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    break;
                }
            }
        }
        public static void FirstMetod(int[] arr)
        {
            OutArrayOnConsole(PositiveInArray(arr), 1);
        }
        public static void SecondMetod(int[] arr,SearchObject condition)
        {
            List<int> arrList = new List<int>();
            foreach (var item in arr)
            {
                if (condition(item,0))
                {
                    arrList.Add(item);
                }
            }
            //SearchPositive searchPos = PositiveInArray; //todo pn мы условие поиска передаем через делегат, а не весь метод поиска.
            OutArrayOnConsole(arrList.ToArray(), 2);
        }
        public static void ThirdMetod(int[] arr,SearchObject condition)
        {
            List<int> arrList = new List<int>();
            foreach (var item in arr)
            {
                if (condition(item, 0))
                {
                    arrList.Add(item);
                }
            }
            OutArrayOnConsole(arrList.ToArray(), 3);
        }
        public static void FourthMetod(int[] arr, SearchObject condition)
        {
            List<int> arrList = new List<int>();
            foreach (var item in arr)
            {
                if (condition(item, 0))
                {
                    arrList.Add(item);
                }
            }
            OutArrayOnConsole(arrList.ToArray(), 4);
        }
        public static void FifthMetod(int[] arr)
        {
            var searchLINQ = from t in arr
                             where t > 0
                             select t;
            Console.Write("Метож 5: ");
            foreach (var item in searchLINQ)
            {
                Console.Write("{0,4}", item);
            }
            Console.WriteLine();
        }
        public static void ArrayInArray(ref int[] arr1,int[] arr2)
        {
            arr1 = new int[arr2.Length];
            for (int i = 0; i < arr1.Length; i++)
            {
                arr1[i] = arr2[i];
            }
        }
        public static void OutArrayOnConsole(int[] arr,int numberMetod)
        {
            Console.Write("Метод {0}: ",numberMetod);
            foreach (var item in arr)
            {
                Console.Write("{0,4}",item);
            }
            Console.WriteLine();
        }
        public static int[] PositiveInArray(int[] arr)
        {
            List<int> arrList = new List<int>();
            foreach (var item in arr)
            {
                if (item > 0)
                {
                    arrList.Add(item);
                }
            }
            return arrList.ToArray();
        }
        public static bool MoreNumber(int a,int b)
        {
            return a > b;
        }
    }
}

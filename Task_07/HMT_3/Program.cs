using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMT_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            DynamicArray<int> DAint = new DynamicArray<int>(4);
            for (int i = 0; i < 9; i++)
            {
                DAint.Add(i);
                Console.WriteLine("Try №{0} ,Length = {1}, Capacity = {2}, arr[i] = {3}", i,DAint.Length, DAint.Capacity,DAint[i]);
            }
            onConsoleArray(DAint);
            DAint.Remove(3);
            onConsoleArray(DAint);
            DAint.Insert(25, 4);
            onConsoleArray(DAint);
            DAint.AddRange(new int[] { 2, 5, 6 });
            DAint.AddRange(new int[] { 2, 5, 6, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 6 });
            onConsoleArray(DAint);
            Console.ReadKey();
        }
        private static void onConsoleArray(DynamicArray<int> arr)
        {
            Console.WriteLine();
            foreach (var item in arr)
            {
                Console.Write("{0}, ", item);
            }
            Console.WriteLine("Length: {0}; Capacity: {1}",arr.Length,arr.Capacity);
            Console.WriteLine();
        }
    }
}

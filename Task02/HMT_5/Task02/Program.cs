using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{
    class Program
    { /* Если выписать все натуральные числа меньше 10, кратные 3, или 5, то
       * получим 3, 5, 6 и 9. Сумма этих чисел будет равна 23. Напишите
       * программу, которая выводит на экран сумму всех чисел меньше 1000,
       * кратных 3, или 5.
        */
        static void Main(string[] args)
        {
            long sum=0;
            for (int i = 3; i < 1000; i++)
            {
                if((i%3==0)|(i % 5 == 0))
                {
                    sum += i;
                }
            }
            Console.WriteLine("Сумма числе от 1 до 1000 кратных 3 или 5 равна: {0}",sum);
            Console.ReadKey();
        }
    }
}

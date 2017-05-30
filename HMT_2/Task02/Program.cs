using System;
namespace Task02
{
    /*Дано действительное число h. Выяснить, имеет ли уравнение a(x^2)+bx+c=0 действиетельные корни, если
     * a=...
     * b=...
     * c=...
     * Если корни существуют, то найти их. В противном случае ответом должно служить сообщение, что действительных корней нет.
     * Должна выводить промежуточный результат (a,b,c,d) и корни если они есть.   
     */
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Введите действительное число h: ");
            double h = Convert.ToDouble(Console.ReadLine());
            double a = Math.Sqrt( (Math.Abs(Math.Sin(8*h)) + 17) / (Math.Pow((1 - Math.Sin(4 * h)*Math.Cos(Math.Pow(h,2) + 18)),2)));
            double b = 1 -Math.Sqrt(3 / (3+Math.Abs(Math.Tan(a*Math.Pow(h,2)) - Math.Sin(a * h))));
            double c = a * Math.Pow(h, 2) * Math.Sin(b * h) + b * Math.Pow(h, 3) * Math.Cos(a * h);
            Console.WriteLine("A = {0}", a);
            Console.WriteLine("B = {0}", b);
            Console.WriteLine("C = {0}", c);
            double d = Math.Pow(b, 2) - 4 * a * c;
            Console.WriteLine("Дискриминант(D) = {0}", d);
            if (d < 0)
            {
                Console.WriteLine("Корни уравнения отсутствуют");
            }else
            {
                if (d == 0)
                {
                    Console.WriteLine("Уравнение имеет 1 корень равный {0}",-b / (2*a));
                }else
                {
                    Console.WriteLine("Уравнение имеет 2 корня");
                    Console.WriteLine("1 корень равен {0}",(-b - Math.Sqrt(d)) / (2 * a));
                    Console.WriteLine("2 корень равен {0}", (-b + Math.Sqrt(d)) / (2 * a));
                }
            }
            Console.WriteLine("Для выхода из программы нажмите любую кнопку...");
            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMT_3
{
    public class Rectangle:Firure
    {
        private double a;
        private double b;
        public Rectangle(double x,double y,double a,double b) : base(x, y)
        {
            this.a = a;
            this.b = b;
        }
        public override double GetArea()
        {
            return a * b;
        }
        public override double GetPerimeter()
        {
            return 2 * (a + b);
        }
        public override string ToString()
        {
            return string.Format("Фигура: Прямоугольник; Центр({0,3:N1};{1,3:N1}) Сторона A: {2,3:N1} Сторона B:{2,3:N1}", x, y, a, b);
        }
    }
}

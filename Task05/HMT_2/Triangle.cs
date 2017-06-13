using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMT_2
{
    
    class Triangle
    {
        private double a;
        private double b;
        private double c;
        public double A
        {
            get { return a; }
            set { a = value; }
        }
        public double B
        {
            get { return b; }
            set { b = value; }
        }
        public double C
        {
            get { return c; }
            set { c = value; }
        }
        public double GetPerimeter()
        {
            return (a+b+c);
        }
        public double GetArea()
        {
            double halfPerimeter = GetPerimeter() / 2;
            return (Math.Sqrt(halfPerimeter*(halfPerimeter-a)*(halfPerimeter-b)*(halfPerimeter-c)));
        }
        public Triangle(double a,double b, double c)
        {
            this.a = a;//todo pn пользователь может задать стороны, из которых невозможно собрать треугольник. Необходима проверка на это.
            this.b = b;
            this.c = c;
        }
    }
}

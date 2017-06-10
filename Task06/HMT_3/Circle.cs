using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMT_3
{
    public class Circle:Round
    {
        public override double GetArea()
        {
            return (Math.PI * Math.Pow(radius, 2));
        }
        public Circle(double x,double y,double r) : base(x, y, r)
        {
        }
        public override string ToString()
        {
            return string.Format("Фигура: Круг; Центр ({0,3:N1},{1,3:N1}); Радиус: {2}", x, y, radius);
        }
    }
}

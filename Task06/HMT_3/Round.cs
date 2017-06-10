using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMT_3
{
    public class Round:Firure
    {
        protected double radius;
        public double Radius { get { return radius; } }
        public override double GetPerimeter()
        {
            return (2 * Math.PI * radius);
        }
        public override double GetArea()
        {
            return 0;
        }
        public override string ToString()
        {
            return string.Format("Фигура: Окружность; Центр ({0,3:N1},{1,3:N1}); Радиус: {2}",x,y,radius);
        }
        public Round(double x,double y,double r):base(x, y)
        {
            radius = r;
        }
    }
}

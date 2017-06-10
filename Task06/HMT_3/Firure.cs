using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMT_3
{
    public abstract class Firure
    {
        protected double x;
        protected double y;
        public double X { get { return x; } }
        public double Y { get { return y; } }
        public abstract double GetPerimeter();
        public abstract double GetArea();
        public Firure(double x,double y)
        {
            this.x = x;
            this.y = y;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMT_01
{
    class Round
    {
        private double centerX;
        private double centerY;
        private double radius;

        public double CenterX
        {
            get { return centerX; }
            set { centerX = value; }
        }
        public double CenterY
        {
            get { return centerY; }
            set { centerY = value; }
        }
        public double Radius
        {
            get { return radius; }
            set { radius = value; }
        }
        public double GetLength()
        {
            return (2*Math.PI*radius);
        }
        public double GetArea()
        {
            return (Math.PI*Math.Pow(radius,2));
        }
        public Round()
        {
        }
        public Round(double x,double y,double r)
        {
            centerX = x;
            centerY = y;
            radius = r;
        }
    }
}

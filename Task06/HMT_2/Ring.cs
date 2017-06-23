using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMT_2
{
    class Ring
    {
        public Round Outer { get; set; }
        public Round Inner { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double GetArea()
        {
            return (Outer.GetArea()-Inner.GetArea());
        }
        public double GetSumLenghRing()
        {
            return (Outer.GetLength()+Inner.GetLength());
        }
        public Ring(double x, double y, double rO,double rI)
        {
            Outer = new Round(x, y, rO);//todo pn внешнее кольцо не может быть меньше внутреннего
            Inner = new Round(x, y, rI);
            this.X = x;
            this.Y = y;
        }
    }
}

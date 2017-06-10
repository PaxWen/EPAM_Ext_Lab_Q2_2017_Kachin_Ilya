using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMT_3
{
    public class Ring:Firure
    {
        private Circle OutR;
        private Circle InR;
        public override double GetArea()
        {
            return OutR.GetArea() - InR.GetArea();
        }
        public Ring(double x,double y,double rO,double rI):base(x,y)
        {
            OutR = new Circle(x, y, rO);
            InR = new Circle(x,y,rI);
        }
        public override double GetPerimeter()
        {
            return OutR.GetPerimeter() + InR.GetPerimeter();
        }
        public override string ToString()
        {
            return string.Format("Фигура: Кольцо; Центр ({0,3:N1},{1,3:N1}); Внешний радиус: {2}; Внутренний радиус: {3}", x, y, OutR.Radius,InR.Radius);
        }
    }
}

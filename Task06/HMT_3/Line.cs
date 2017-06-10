using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMT_3
{
    public class Line:Firure
    {
        private double x2;
        private double y2;
        public override double GetPerimeter()
        {
            return (Math.Sqrt(Math.Pow((x2-x),2)-Math.Pow((y2-y),2)));
        }
        public override double GetArea()
        {
            return 0;
        }
        public override string ToString()
        {
            return string.Format("Тип: Линия; Точка A({0,3:N1};{1,3:N1}),Точка B({2,3:N1};{3,3:N1})", x,y,x2,y2);
        }
        public Line(double x,double y,double x2,double y2) : base(x, y)
        {
            this.x2 = x2;
            this.y2 = y2;
        }
    }
}

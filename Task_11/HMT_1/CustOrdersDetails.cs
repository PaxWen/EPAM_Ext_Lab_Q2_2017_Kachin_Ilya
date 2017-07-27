using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMT_1
{
    public class CustOrdersDetails
    {
        public string ProductName { get; private set; }
        public int Quantity { get; private set; }
        public double UnityPrice { get; private set; }
        public double Discont { get; private set; }
        public double ExtendenPrice { get; private set; }

        public CustOrdersDetails(string productName, double price,int quality ,double discont,double extendedPrice)
        {
            this.ProductName = productName;
            this.Quantity = quality;
            this.UnityPrice = price;
            this.Discont = discont;
            this.ExtendenPrice = extendedPrice;
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMT_1
{
    public class OrderDetails : Order
    {
        public int ProductID { get; private set; }
        public string ProductName { get; private set; }
        public short Quantity { get; private set; }
        public double UnityPrice { get; private set; }
        public double Discont { get; private set; }

        public OrderDetails(int orderID, string customerID, int employeeID, DateTime orderDate, DateTime shippedDate, string adress,int productID,string productName, short quality, double price, double discont): base(orderID, customerID,employeeID, orderDate, shippedDate, adress)
        {
            this.ProductID = productID;
            this.ProductName = productName;
            this.Quantity = quality;
            this.UnityPrice = price;
            this.Discont = discont;
        }
    }
}

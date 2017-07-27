using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMT_1
{
    public class Order
    {
        private DateTime shippedDate;
        public int OrderID { get; private set; }
        public string CustomerID { get; private set; }
        public int EmployeeID { get; private set; }
        public DateTime OrderDate { get; private set; }
        public DateTime ShippedDate {
            get { return shippedDate; }
            private set {
                    shippedDate = value;
                    Status = ShippedDate!=null?StatusOrders.Sent:StatusOrders.Delivered;
            }
        }
        public StatusOrders Status { get; private set; }
        public string Adress { get; private set; }
        public Order(int orderID,string customerID,int employeeID,DateTime orderDate,DateTime shippedDate,string adress)
        {
            this.OrderID = orderID;
            this.CustomerID = customerID;
            this.EmployeeID = employeeID;
            this.OrderDate = orderDate;
            this.ShippedDate = shippedDate;
            this.Adress = adress;
        }
    }
}

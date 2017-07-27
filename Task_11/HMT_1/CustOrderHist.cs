using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMT_1
{
    public class CustOrderHist
    {
        public string CustomerID { get; private set; }
        public List<string> ProductName { get; private set; }
        public List<int> Total { get; private set; }

        public CustOrderHist (string customerID,List<string> products, List<int> total)
        {
            this.CustomerID = customerID;
            this.ProductName = new List<string>();
            this.ProductName.AddRange(products);
            this.Total = new List<int>();
            this.Total.AddRange(total);
        }
        public CustOrderHist (string customerID)
        {
            this.CustomerID = customerID;
            this.ProductName = new List<string>();
            this.Total = new List<int>();
        }

        public void AddProductTotal(string productName,int total)
        {
            this.ProductName.Add(productName);
            this.Total.Add(total);
        }
    }
}

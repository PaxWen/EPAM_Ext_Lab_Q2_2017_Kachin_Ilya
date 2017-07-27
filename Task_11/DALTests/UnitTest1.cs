using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HMT_1;
using System.Collections.Generic;


namespace DALTests
{
    [TestClass]
    public class UnitTest1
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        [TestMethod]
        public void TestGetCounts()
        {
            HMT_1.DAL test = new HMT_1.DAL();
            int expected = 91;
            int actual = test.GetCount(connectionString, "Northwind.Northwind.Customers");
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestGetCustOrdersDetail()
        {
            HMT_1.DAL test = new HMT_1.DAL();
            List<CustOrdersDetails> details = new List<CustOrdersDetails>();
            List<CustOrdersDetails> details2 = test.GetCustOrdersDetail(connectionString, 10248);
            Assert.AreEqual(details,details2);
        }

    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            int expected = 830;
            int actual = test.GetCount(connectionString, "Customers");
            Assert.AreEqual(expected, actual);
        }
    }
}

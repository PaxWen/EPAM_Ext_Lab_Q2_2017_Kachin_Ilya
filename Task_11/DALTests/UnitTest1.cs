using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HMT_1;
using System.Collections.Generic;
using System.Data;

namespace DALTests
{
    [TestClass]
    public class UnitTest1
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";//todo pn нужно в конфиг вынести. ну и не забывай о требовании provider independent стиля (в презентации примеры есть).
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
            new HMT_1.DAL().GetCustOrdersDetail(connectionString,10248);//todo pn очень странный тест, перепиши с использованием AreEqual итп методов
		}

        [TestMethod]
        public void TestSetOrderDate()
        {
            new HMT_1.DAL().SetOrderDate(connectionString, 10248, @"'04.04.1997'");//todo pn очень странный тест, перепиши с использованием AreEqual итп методов
		}
        [TestMethod]
        public void TestSetShipedDate()
        {
            new HMT_1.DAL().SetShipedDate(connectionString, 10248, @"'04.04.1998'");//todo pn очень странный тест, перепиши с использованием AreEqual итп методов
		}
        [TestMethod]
        public void TestGetOrder()
        {
            new HMT_1.DAL().GetOrders(connectionString,new int[] {10248,10249 });//todo pn очень странный тест, перепиши с использованием AreEqual итп методов
		}
        [TestMethod]
        public void GetDetailedOrder()
        {
            new HMT_1.DAL().GetDetailedOrder(connectionString, 10248);//todo pn очень странный тест, перепиши с использованием AreEqual итп методов
		}
        [TestMethod]
        public void TestGetCustOrderHist()
        {
            new HMT_1.DAL().GetCustOrderHist(connectionString, "ANTON");//todo pn очень странный тест, перепиши с использованием AreEqual итп методов
		}
        [TestMethod]
        public void TestInsert()
        {
            new DAL().InsertOrder(connectionString,new Order(11111,"ANTON", 6,new DateTime(1998,6,6),new DateTime(1998,9,6),"Nansy 32"));//todo pn очень странный тест, перепиши с использованием AreEqual итп методов
		}
    }
}

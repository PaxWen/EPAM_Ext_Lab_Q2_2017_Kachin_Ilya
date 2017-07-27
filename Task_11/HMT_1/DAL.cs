using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMT_1
{

    /* Реализуйте возможность через DAL управлять заказами:
    1. Показывать список введенных заказов (таблица [Orders]). // GetOrders()+
    Помимо основных полей должны возвращаться:
        a. Статус заказа в виде Enum поля.
    2. Показывать подробные сведения о конкретном заказе, включая номенклатуру заказа 
    (таблицы [Orders], [Order Details], и [Products], требуется извлекать как Id, 
    так и название продукта) // GetDetailedOrder()+
    3. Создавать новые заказы.// InsertOrder()+
    4. Менять статус заказа. Для реализации этого пункта предлагается 
    сделать специальные методы (именование выбирайте сами):
        a. Передать в работу: устанавливает дату заказа // SetOrderDate()+
        b. Пометить как выполненный: устанавливает ShippedDate //SetShipedDate();+
    5. Получать статистику по заказам, используя готовые хранимые процедуры:
        a. CustOrderHist //GetCustOrderHist()+
        b. CustOrdersDetail. //GetCustOrdersDetail()+
     */
    public enum StatusOrders {Sent, Delivered } 
    public class DAL
    {
        public List<Order> GetOrders(string connectionString,int[] ordersID)
        {
            List<Order> orders = new List<Order>();
            string listOrders = "";
            for (int i = 0; i < ordersID.Length; i++)
            {
                listOrders += ordersID[i].ToString() + (i != (ordersID.Length - 1) ? ", " : "");
            }
            string commandString = string.Format(@"Select OrderID,CustomerID,EmployeeID,OrderDate,ShippedDate,ShipAddress From Northwind.Northwind.Orders Where OrderID in ({0})", listOrders.ToString());
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = commandString;
                command.CommandType = CommandType.Text;

                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    orders.Add(new Order(
                          reader.GetInt32(0) //OrderID
                        , reader.GetString(1)//CustomerID
                        , reader.GetInt32(2)//EmployeeID
                        , reader.GetDateTime(3)//OrderDate
                        , reader.GetDateTime(4)//ShippedDate
                        , reader.GetString(5)//Address
                       ));
                }
                return orders;
            }
        }
        public CustOrderHist GetCustOrderHist(string connectionString,string CustomerID)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();

                command.CommandText = @"Northwind.CustOrderHist";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter();
                param.ParameterName = "@CustomerID";
                param.SqlDbType = SqlDbType.NChar;
                param.Value = CustomerID.ToString().ToCharArray();

                param.Direction = ParameterDirection.Input;
                command.Parameters.Add(param);

                var reader = command.ExecuteReader();
                CustOrderHist customer = new CustOrderHist(CustomerID);
                while (reader.Read()) {
                    customer.AddProductTotal(
                         reader.GetString(0) // productName
                        , reader.GetInt32(1) // Total
                        );
                }
                connection.Close();
                return customer;
            }
        }

        public List<CustOrdersDetails> GetCustOrdersDetail(string connectionString, int OrderID)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();

                command.CommandText = @"Northwind.CustOrdersDetail";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter();
                param.ParameterName = "@OrderID";
                param.SqlDbType = SqlDbType.Int;
                param.Value = OrderID;

                param.Direction = ParameterDirection.Input;
                command.Parameters.Add(param);

                var reader = command.ExecuteReader();

                List<CustOrdersDetails> orderDetails = new List<CustOrdersDetails>();
                while (reader.Read())
                {
                    object[] buf = new object[reader.FieldCount];
                    reader.GetValues(buf);
                    orderDetails.Add(new CustOrdersDetails(
                         reader.GetString(0) // productName
                        , Convert.ToDouble(reader.GetDecimal(1)) // Price
                        , reader.GetInt16(2) // Quality
                        , reader.GetInt32(3) // Discont
                        , Convert.ToDouble(reader.GetDecimal(4)) // ExtendenPrice
                        ));
                }
                return orderDetails;
            }
        }
        public void SetOrderDate(string connectionString, int ordersID,string date)
        {
            UpdateTable(connectionString, "Northwind.Northwind.Orders", new string[] { "OrderDate" }, new string[] { date.ToString() }, string.Format("(OrderID = {0})", ordersID));
            SetShipedDate(connectionString, ordersID, "Null");
        }
        public void SetShipedDate(string connectionString, int ordersID, string date)
        {
            UpdateTable(connectionString, "Northwind.Northwind.Orders", new string[] { "ShippedDate" }, new string[] { date.ToString() }, string.Format("OrderID={0}", ordersID));
        }
        public List<OrderDetails> GetDetailedOrder(string connectionString, int ordersID)
        {
            string commandString = string.Format(@"Select Orders.OrderID, Orders.CustomerID, Orders.EmployeeID,Orders.OrderDate,Orders.ShippedDate,Orders.ShipAddress, [Order Details].ProductID, Products.ProductName,[Order Details].Quantity,CONVERT(float, [Order Details].UnitPrice), Convert (float,[Order Details].Discount) from (Northwind.Northwind.Orders join Northwind.Northwind.[Order Details] on Orders.OrderID = [Order Details].OrderID) join Northwind.Northwind.Products on [Order Details].ProductID = Products.ProductID Where Orders.OrderID = {2}", StatusOrders.Sent, StatusOrders.Delivered,ordersID.ToString());
            List<OrderDetails> orders = new List<OrderDetails>();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = commandString;
                command.CommandType = CommandType.Text;

                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    orders.Add(new OrderDetails(
                          reader.GetInt32(0) //OrderID
                        , reader.GetString(1)//CustomerID
                        , reader.GetInt32(2)//EmployeeID
                        , reader.GetDateTime(3)//OrderDate
                        , reader.GetDateTime(4)//ShippedDate
                        , reader.GetString(5)//Address
                        , reader.GetInt32(6)//ProductID
                        , reader.GetString(7)//ProductName
                        , reader.GetInt16(8)//Quality
                        , reader.GetDouble(9)//Price
                        , reader.GetDouble(10)//Discont
                        ));
                }
            }
            return orders;
        }

        public int GetCount(string connectionString, string tableName, string columnName = "*", string condition = "")
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();

                command.CommandText = @"Select Count("+ columnName+") From "+tableName+(condition!=""?"Where "+condition:condition);
                command.CommandType = CommandType.Text;

                var reader = command.ExecuteScalar();
                connection.Close();
                return (int)reader;
            }
        }


        public void InsertOrder(string connectionString, Order order)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();

                string commandString = " SET IDENTITY_INSERT Northwind.Northwind.Orders ON Insert Into Northwind.Northwind.Orders (OrderID, CustomerID,EmployeeID,OrderDate,ShippedDate,ShipAddress) Values(@OrderID, @CustomerID,@EmployeeID,@OrderDate,@ShippedDate,@ShipAddress) SET IDENTITY_INSERT Northwind.Northwind.Orders OFF";
                command.CommandText = commandString;
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@OrderID",order.OrderID);
                command.Parameters.AddWithValue("@CustomerID", order.CustomerID);
                command.Parameters.AddWithValue("@EmployeeID", order.EmployeeID);
                command.Parameters.AddWithValue("@OrderDate", order.OrderDate);
                command.Parameters.AddWithValue("@ShippedDate", order.ShippedDate);
                command.Parameters.AddWithValue("@ShipAddress", order.Adress);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void DeleteFromTAble(string connectionString, string tableName, string[] columnsName, string[] columnsValue)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                string conditions = columnsName.Length <= 1 ? "":"(" ;
                for (int i = 0; i < columnsName.Length; i++)
                {
                    conditions += string.Format(@"({0}={1}) {2}", columnsName[i], columnsValue[i],i != columnsName.Length-1? "and": "") ;
                    
                }
                conditions = columnsName.Length <= 1 ? "" : ")";
                string commandString = string.Format(@"Delete From {0} Where {1}",tableName,conditions);

                command.CommandText = commandString;
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void UpdateTable(string connectionString, string tableName, string[] columnsName, string[] columnsValue,string condition )
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                string updateString = "";
                //updateString = columnsName.Length <= 1 ? "" : "(";
                for (int i = 0; i < columnsName.Length; i++)
                {
                    updateString += string.Format(@"{0}={1}{2}", columnsName[i], columnsValue[i], i != columnsName.Length - 1 ? "," : "");

                }
               // updateString = columnsName.Length <= 1 ? "" : ")";
                string commandString = string.Format(@"Update {0} set {1} From {0} Where {2}",tableName, updateString, condition);
                command.CommandText = commandString;
                command.CommandType = CommandType.Text;

                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}

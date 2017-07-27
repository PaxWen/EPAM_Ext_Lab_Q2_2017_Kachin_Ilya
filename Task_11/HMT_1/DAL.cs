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
    1. Показывать список введенных заказов (таблица [Orders]). // GetOrders()
    Помимо основных полей должны возвращаться:
        a. Статус заказа в виде Enum поля.
    2. Показывать подробные сведения о конкретном заказе, включая номенклатуру заказа 
    (таблицы [Orders], [Order Details], и [Products], требуется извлекать как Id, 
    так и название продукта) // GetDetailedOrder()
    3. Создавать новые заказы.// InsertToTable()
    4. Менять статус заказа. Для реализации этого пункта предлагается 
    сделать специальные методы (именование выбирайте сами):
        a. Передать в работу: устанавливает дату заказа // SetOrderDate()
        b. Пометить как выполненный: устанавливает ShippedDate //SetShipedDate();
    5. Получать статистику по заказам, используя готовые хранимые процедуры:
        a. CustOrderHist //GetCustOrderHist()
        b. CustOrdersDetail. //GetCustOrdersDetail()
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
                listOrders += ordersID[i].ToString() + (i == ordersID.Length ? "" : ",");
            }
            string commandString = string.Format(@"Select OrderID,CustomerID,EmployeeID,OrderDate,ShippedDate,ShipAddress from Northwind.Northwind.Orders Where OrderID in ({2})", listOrders);

            DataSet data = new DataSet();
            data = SelectManualInput(connectionString, connectionString);
            for (int i = 0; i < data.Tables[0].Rows.Count; i++)
            {
                orders.Add(new Order((int)data.Tables[0].Rows[i].ItemArray[0],(string) data.Tables[0].Rows[i].ItemArray[1], (int)data.Tables[0].Rows[i].ItemArray[2],(DateTime) data.Tables[0].Rows[i].ItemArray[3], (DateTime)data.Tables[0].Rows[i].ItemArray[4],(string) data.Tables[0].Rows[i].ItemArray[5]));              
            }
            return orders;
        }
        public CustOrderHist GetCustOrderHist(string connectionString,int CustomerID)
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

                param = new SqlParameter();
                param.ParameterName = "@ProductName";
                param.SqlDbType = SqlDbType.NVarChar;
                param.Size = 40;
                param.Direction = ParameterDirection.Output;
                command.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@Total";
                param.SqlDbType = SqlDbType.Int;
                param.Direction = ParameterDirection.Output;
                command.Parameters.Add(param);

                command.ExecuteNonQuery();
                DataSet data = new DataSet();
                data.Tables[0].Rows.Add(command.Parameters);
                connection.Close();
                CustOrderHist customer = new CustOrderHist(CustomerID);
                for (int i = 0; i < data.Tables[0].Rows.Count; i++)
                {
                    customer.AddProductTotal(
                         (string)data.Tables[0].Rows[i].ItemArray[0] // productName
                        , (int) data.Tables[0].Rows[i].ItemArray[1] // Total
                        );
                }
                return customer;
            }
        }

        public List<CustOrdersDetails> GetCustOrdersDetail(string connectionString, int OrderID)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();

                command.CommandText = @"Northwind.CustOrdersOrders";
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter();
                param.ParameterName = "@OrderID";
                param.SqlDbType = SqlDbType.Int;
                param.Value = OrderID.ToString().ToCharArray();

                param.Direction = ParameterDirection.Input;
                command.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@ProductName";
                param.SqlDbType = SqlDbType.NVarChar;
                param.Size = 40;
                param.Direction = ParameterDirection.Output;
                command.Parameters.Add(param);


                param = new SqlParameter();
                param.ParameterName = "@UnitPrice";
                param.SqlDbType = SqlDbType.Int;
                param.Direction = ParameterDirection.Output;
                command.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@Quantity";
                param.SqlDbType = SqlDbType.SmallInt;
                param.Direction = ParameterDirection.Output;
                command.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@Discount";
                param.SqlDbType = SqlDbType.Int;
                param.Direction = ParameterDirection.Output;
                command.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@ExtendedPrice";
                param.SqlDbType = SqlDbType.Int;
                param.Direction = ParameterDirection.Output;
                command.Parameters.Add(param);

                command.ExecuteNonQuery();
                DataSet data = new DataSet();
                data.Tables[0].Rows.Add(command.Parameters);
                connection.Close();

                List<CustOrdersDetails> orderDetails = new List<CustOrdersDetails>();
                for (int i = 0; i < data.Tables[0].Rows.Count; i++)
                {
                    orderDetails.Add(new CustOrdersDetails(
                         (string)data.Tables[0].Rows[i].ItemArray[0] // productName
                        , (double)data.Tables[0].Rows[i].ItemArray[1] // Price
                        , (int)data.Tables[0].Rows[i].ItemArray[2] // Quality
                        , (double)data.Tables[0].Rows[i].ItemArray[3] // Discont
                        , (double)data.Tables[0].Rows[i].ItemArray[4] // ExtendenPrice
                        ));
                }
                return orderDetails;
            }
        }
        public void SetOrderDate(string connectionString, int ordersID,string date)
        {
            UpdateTable(connectionString, "Northwind.Northwind.Orders", new string[] { "OrderDate" }, new string[] { date.ToString() }, string.Format("OrderID={0}", ordersID));
            SetShipedDate(connectionString, ordersID, "Null");
        }
        public void SetShipedDate(string connectionString, int ordersID, string date)
        {
            UpdateTable(connectionString, "Northwind.Northwind.Orders", new string[] { "ShippedDate" }, new string[] { date.ToString() }, string.Format("OrderID={0}", ordersID));
        }
        public List<OrderDetails> GetDetailedOrder(string connectionString, int ordersID)
        {
            string commandString = string.Format(@"Select Orders.OrderID, Orders.CustomerID, Orders.EmployeeID,Orders.OrderDate,Orders.ShippedDate,Orders.ShipAddress, [Order Details].ProductID, Products.ProductName,[Order Details].Quantity, [Order Details].UnitPrice, [Order Details].Discount from (Northwind.Northwind.Orders join Northwind.Northwind.[Order Details] on Orders.OrderID = [Order Details].OrderID) join Northwind.Northwind.Products on [Order Details].ProductID = Products.ProductID Where OrderID in ({2})", StatusOrders.Sent, StatusOrders.Delivered,ordersID.ToString());
            List<OrderDetails> orders = new List<OrderDetails>();
            DataSet data = new DataSet();
            data = SelectManualInput(connectionString, connectionString);
            for (int i = 0; i < data.Tables[0].Rows.Count; i++)
            {
                orders.Add(new OrderDetails(
                    (int)data.Tables[0].Rows[i].ItemArray[0] //OrderID
                    , (string)data.Tables[0].Rows[i].ItemArray[1]//CustomerID
                    , (int)data.Tables[0].Rows[i].ItemArray[2]//EmployeeID
                    , (DateTime)data.Tables[0].Rows[i].ItemArray[3]//OrderDate
                    , (DateTime)data.Tables[0].Rows[i].ItemArray[4]//ShippedDate
                    , (string)data.Tables[0].Rows[i].ItemArray[5]//Address
                    , (int)data.Tables[0].Rows[i].ItemArray[6]//ProductID
                    , (string)data.Tables[0].Rows[i].ItemArray[7]//ProductName
                    , (int)data.Tables[0].Rows[i].ItemArray[8]//Quality
                    , (double)data.Tables[0].Rows[i].ItemArray[9]//Price
                    , (double)data.Tables[0].Rows[i].ItemArray[10]//Discont
                    ));
            }
            return orders;
        }

        public DataSet SelectFullTable(string connectionString, string tableName)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();

                command.CommandText = @"Select * from " + tableName;
                command.CommandType = CommandType.Text;

                var reader = command.ExecuteReader();
                String[] columnNames = new string[reader.FieldCount];
                for (int i = 0; i < columnNames.Length; i++)
                {
                    columnNames[i] = reader.GetName(i);
                }
                DataSet data = new DataSet();
                data.Load(reader, LoadOption.Upsert, columnNames);
                connection.Close();
                return data;
            }
        }
        public DataSet SelectManualInput(string connectionString, string commandString)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();

                command.CommandText = commandString;
                command.CommandType = CommandType.Text;

                var reader = command.ExecuteReader();
                String[] columnNames = new string[reader.FieldCount];
                for (int i = 0; i < columnNames.Length; i++)
                {
                    columnNames[i] = reader.GetName(i);
                }
                DataSet data = new DataSet();
                data.Load(reader, LoadOption.Upsert, columnNames);
                connection.Close();
                return data;
            }
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


        public void InsertToTable(string connectionString, string tableName,Type[] typeColumns,string[] nameColumns, string[] valueColumns)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();

                string ValueCollumn = "(";
                string CollumnName = "(";
                for (int i = 1; i < valueColumns.Length; i++)
                {
                    CollumnName += nameColumns[i];
                    ValueCollumn += '@' + nameColumns[i];
                    if (i != nameColumns.Length - 1)
                    {
                        ValueCollumn += ", ";
                        CollumnName += ", ";
                    }
                }
                ValueCollumn += ")";
                CollumnName += ")";
                string commandString = string.Format("Insert Into [{0}] {1} Values{2}", tableName, CollumnName, ValueCollumn);
                command.CommandText = commandString;
                command.CommandType = CommandType.Text;

                for (int i = 0; i < typeColumns.Length; i++)
                {
                    command.Parameters.AddWithValue(nameColumns[i], Convert.ChangeType(valueColumns[i], typeColumns[i]));
                }
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
                string updateString = columnsName.Length <= 1 ? "" : "(";
                for (int i = 0; i < columnsName.Length; i++)
                {
                    updateString += string.Format(@"({0}={1}) {2}", columnsName[i], columnsValue[i], i != columnsName.Length - 1 ? "and" : "");

                }
                updateString = columnsName.Length <= 1 ? "" : ")";
                string commandString = string.Format(@"Update {0} set {1} Where {2}",tableName, updateString, condition);

                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}

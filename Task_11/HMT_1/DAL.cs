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
        public DataSet GetOrders(string connectionString,int[] ordersID)
        {
            string listOrders = "";
            for (int i = 0; i < ordersID.Length; i++)
            {
                listOrders += ordersID[i].ToString() + (i == ordersID.Length ? "" : ",");
            }
            string commandString = string.Format(@"Select *,(case when ShippedDate is null then {0} else {1}end ) from Northwind.Northwind.Orders Where OrderID in ({2})", StatusOrders.Sent, StatusOrders.Delivered,listOrders);

            return SelectManualInput(connectionString, connectionString);
        }
        public DataSet GetCustOrderHist(string connectionString,int CustomerID)
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
                return data;
            }
        }

        public DataSet GetCustOrdersDetail(string connectionString, int OrderID)
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
                return data;
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
        public DataSet GetDetailedOrder(string connectionString, int ordersID)
        {
            string commandString = string.Format(@"Select *,(case when ShippedDate is null then {0} else {1}end ) from (Northwind.Northwind.Orders join Northwind.Northwind.[Order Details] on Orders.OrderID = [Order Details].OrderID) join Northwind.Northwind.Products on [Order Details].ProductID = Products.ProductID Where OrderID in ({2})", StatusOrders.Sent, StatusOrders.Delivered,ordersID.ToString());

            return SelectManualInput(connectionString, connectionString);
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

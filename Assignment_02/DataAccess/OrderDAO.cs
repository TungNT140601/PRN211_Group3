using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Configuration;
using BusinessObject;
using System;

namespace DataAccess
{
    public class OrderDAO
    {
        private static OrderDAO instance = null;
        private static readonly object instanceLock = new object();
        public static OrderDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDAO();
                    }
                    return instance;
                }
            }
        }
        public OrderDAO orderDAO { get; set; } = null;
        public SqlConnection connection = null;
        public OrderDAO()
        {
            var connectionString = GetConnectionString();
            orderDAO = new OrderDAO(connectionString);
        }
     
        public string GetConnectionString()
        {
            string connectionString;
            IConfiguration config = new ConfigurationBuilder()
                                        .SetBasePath(Directory.GetCurrentDirectory())
                                        .AddJsonFile("appsetting.json", true, true)
                                        .Build();
            connectionString = config["ConnectionString:FStoreDB"];
            return connectionString;
        }
        public void CloseConnection() => orderDAO.CloseConnection(connection);

        private string ConnectionString { get; set; }
        public OrderDAO(string connectionString) => ConnectionString = connectionString;
        public void CloseConnection(SqlConnection connection) => connection.Close();
        public SqlParameter CreateParameter(string name, int size, object value, DbType dbType, ParameterDirection direction = ParameterDirection.Input)
        {
            return new SqlParameter
            {
                DbType = dbType,
                ParameterName = name,
                Size = size,
                Direction = direction,
                Value = value,
            };
        }
        public IDataReader GetDataReader(string commandText, CommandType commandType, out SqlConnection connection, params SqlParameter[] parameters)
        {
            IDataReader reader = null;
            try
            {
                connection = new SqlConnection(ConnectionString);
                connection.Open();
                var command = new SqlCommand(commandText, connection);
                command.CommandType = commandType;
                if (parameters != null)
                {
                    foreach (var parameter in parameters)
                    {
                        command.Parameters.Add(parameter);
                    }
                }
                reader = command.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return reader;
        }
        public void Delete(string commandText, CommandType commandType, params SqlParameter[] parameters)
        {
            try
            {
                using var connection = new SqlConnection(ConnectionString);
                connection.Open();
                using var command = new SqlCommand(commandText, connection);
                command.CommandType = commandType;
                if (parameters != null)
                {
                    foreach (var parameter in parameters)
                    {
                        command.Parameters.Add(parameter);
                    }
                }
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Insert(string commandText, CommandType commandType, params SqlParameter[] parameters)
        {
            try
            {
                using var connection = new SqlConnection(ConnectionString);
                connection.Open();
                using var command = new SqlCommand(commandText, connection);
                command.CommandType = commandType;
                if (parameters != null)
                {
                    foreach (var parameter in parameters)
                    {
                        command.Parameters.Add(parameter);
                    }
                }
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Update(string commandText, CommandType commandType, params SqlParameter[] parameters)
        {
            try
            {
                using var connection = new SqlConnection(ConnectionString);
                connection.Open();
                using var command = new SqlCommand(commandText, connection);
                command.CommandType = commandType;
                if (parameters != null)
                {
                    foreach (var parameter in parameters)
                    {
                        command.Parameters.Add(parameter);
                    }
                }
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<OrderObject> getOrderList()
        {
            IDataReader dataReader = null;
            string SQLSelect = "SELECT * FROM tbl_Order";
            var orders = new List<OrderObject>();
            try
            {
                dataReader = GetDataReader(SQLSelect, CommandType.Text, out connection);
                while (dataReader.Read())
                {
                    orders.Add(new OrderObject
                    {
                        OrderId = dataReader.GetInt32(0),
                        MemberId = dataReader.GetInt32(1),
                        OrderDate = dataReader.GetDateTime(2),
                        RequiredDate = dataReader.GetDateTime(3),
                        ShippedDate = dataReader.GetDateTime(4),
                        Freight = dataReader.GetDecimal(5)
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dataReader.Close();
                CloseConnection();
            }
            return orders;
        }

        public OrderObject GetOrderById(int orderId)
        {
            OrderObject order = null;
            IDataReader dataReader = null;
            string SQLSelect = "SELECT * FROM tbl_Order WHERE OrderId = @OrderId";
            try
            {
                var param = CreateParameter("@OrderId", 4, orderId, DbType.Int32);
                dataReader = GetDataReader(SQLSelect, CommandType.Text, out connection, param);
                if (dataReader.Read())
                {
                    order = new OrderObject
                    {
                        OrderId = dataReader.GetInt32(0),
                        MemberId = dataReader.GetInt32(1),
                        OrderDate = dataReader.GetDateTime(2),
                        RequiredDate = dataReader.GetDateTime(3),
                        ShippedDate = dataReader.GetDateTime(4),
                        Freight = dataReader.GetDecimal(5)
                    
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dataReader.Close();
                CloseConnection();
            }
            return order;
        }

        public IEnumerable<OrderObject> SearchByDay(DateTime min, DateTime max)
        {

            OrderObject order = null;
            IDataReader dataReader = null;
            var orders = new List<OrderObject>();
            string SQLSelect = "SELECT * FROM tbl_Order WHERE OrderDate BETWEEN @FromDate AND @ToDate";
            try
            {
                var fromDate = CreateParameter("@FromDate", 4, min, DbType.DateTime);
                var toDate = CreateParameter("@ToDate", 50, max, DbType.DateTime);
                dataReader = GetDataReader(SQLSelect, CommandType.Text, out connection, fromDate);
                dataReader = GetDataReader(SQLSelect, CommandType.Text, out connection, toDate);
                if (dataReader.Read())
                {
                    orders.Add(new OrderObject
                    {
                        OrderId = dataReader.GetInt32(0),
                        MemberId = dataReader.GetInt32(1),
                        OrderDate = dataReader.GetDateTime(2),
                        RequiredDate = dataReader.GetDateTime(3),
                        ShippedDate = dataReader.GetDateTime(4),
                        Freight = dataReader.GetDecimal(5)

                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dataReader.Close();
                CloseConnection();
            }
            return orders;
        }

        public void AddNew(OrderObject order)
        {
            try
            {
                OrderObject o = GetOrderById(order.OrderId);
                if (o.MemberId == null)
                {
                    string SQLInsert = "INSERT tbl_Order values(@OrderId, @MemberId, @OrderDate, @RequiredDate, @ShippedDate, @Freight)";
                    var parameters = new List<SqlParameter>();
                    parameters.Add(CreateParameter("@OrderId", 4, o.OrderId, DbType.Int32));
                    parameters.Add(CreateParameter("@MemberId", 4, o.MemberId, DbType.String));
                    parameters.Add(CreateParameter("@OrderDate", 50, o.OrderDate, DbType.DateTime));
                    parameters.Add(CreateParameter("@RequiredDate", 50, o.RequiredDate, DbType.DateTime));
                    parameters.Add(CreateParameter("@ShippedDate", 50, o.ShippedDate, DbType.DateTime));
                    parameters.Add(CreateParameter("@Freight", 4, o.Freight, DbType.Decimal));
                    Insert(SQLInsert, CommandType.Text, parameters.ToArray());
                }
                else
                {
                    throw new Exception("This order is already exits.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public void Update(OrderObject order)
        {
            try
            {
                OrderObject o = GetOrderById(order.OrderId);
                if (o != null)
                {
                    string SQLUpdate = "UPDATE tbl_Order set OrderId = @OrderId,MemberId = @MemberId,OrderDate = @OrderDate, RequiredDate = @RequiredDate, ShippedDate = @ShippedDate,Freight= @Freight WHERE MemberId = @MemberId";
                    var parameters = new List<SqlParameter>();
                    parameters.Add(CreateParameter("@OrderId", 4, o.OrderId, DbType.Int32));
                    parameters.Add(CreateParameter("@MemberId", 4, o.MemberId, DbType.Int32));
                    parameters.Add(CreateParameter("@OrderDate", 50, o.OrderDate, DbType.DateTime));
                    parameters.Add(CreateParameter("@RequiredDate", 50, o.RequiredDate, DbType.DateTime));
                    parameters.Add(CreateParameter("@ShippedDate", 50, o.ShippedDate, DbType.DateTime));
                    parameters.Add(CreateParameter("@Freight", 4, o.Freight, DbType.Decimal));
                    Insert(SQLUpdate, CommandType.Text, parameters.ToArray());
                }
                else
                {
                    throw new Exception("Order does not exits.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }
        public void Remove(int orderId)
        {
            try
            {
                OrderObject member = GetOrderById(orderId);
                if (member != null)
                {
                    string SQLDelete = "DELETE tbl_Order WHERE OrderID = @OrderId";
                    var param = CreateParameter("@OrderId", 4, orderId, DbType.Int32);
                    Delete(SQLDelete, CommandType.Text, param);
                }
                else
                {
                    throw new Exception("Order does not already exits.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }
        
        public IEnumerable<OrderObject> SortBySale()
        {
            var orders = new List<OrderObject>();
            return orders;
        }

    }
}

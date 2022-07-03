using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Configuration;
using BusinessObject;
using System;

namespace DataAccess
{
    public class OrderDetailDAO
    {
        private static OrderDetailDAO instance = null;
        private static readonly object instanceLock = new object();
        public static OrderDetailDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDetailDAO();
                    }
                    return instance;
                }
            }
        }
        public OrderDetailDAO orderDetailDAO { get; set; } = null;
        public SqlConnection connection = null;
        public OrderDetailDAO()
        {
            var connectionString = GetConnectionString();
            orderDetailDAO = new OrderDetailDAO(connectionString);
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
        public void CloseConnection() => orderDetailDAO.CloseConnection(connection);

        private string ConnectionString { get; set; }
        public OrderDetailDAO(string connectionString) => ConnectionString = connectionString;
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

        public IEnumerable<OrderDetailObject> getOrderDetailList()
        {
            OrderDAO orderDAO = new OrderDAO();
            ProductDAO productDAO = new ProductDAO();
            IDataReader dataReader = null;
            string SQLSelect = "SELECT * FROM OrderDetail";
            var orderdetails = new List<OrderDetailObject>();
            try
            {
                dataReader = GetDataReader(SQLSelect, CommandType.Text, out connection);
                while (dataReader.Read())
                {
                    orderdetails.Add(new OrderDetailObject
                    {
                        OrderID = orderDAO.GetOrderById(dataReader.GetInt32(0)),
                        ProductID = productDAO.GetProductByID(dataReader.GetInt32(1)),
                        UnitPrice = dataReader.GetDecimal(2),
                        Quantity = dataReader.GetInt32(3),
                        Discount = dataReader.GetFloat(4),
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
            return orderdetails;
        }

        public OrderDetailObject GetOrderDetailByOrderId(int orderId)
        {
            OrderDAO orderDAO = new OrderDAO();
            ProductDAO productDAO = new ProductDAO();
            OrderDetailObject orderdetail = null;
            IDataReader dataReader = null;
            string SQLSelect = "SELECT * FROM OrderDetail WHERE OrderId LIKE N'OrderId'";
            try
            {
                var param = CreateParameter("@OrderId", 4, orderId, DbType.Int32);
                dataReader = GetDataReader(SQLSelect, CommandType.Text, out connection, param);
                if (dataReader.Read())
                {
                    orderdetail = new OrderDetailObject
                    {
                        OrderID = orderDAO.GetOrderById(dataReader.GetInt32(0)),
                        ProductID = productDAO.GetProductByID(dataReader.GetInt32(1)),
                        UnitPrice = dataReader.GetDecimal(2),
                        Quantity = dataReader.GetInt32(3),
                        Discount = dataReader.GetFloat(4),

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
            return orderdetail;
        }

        public void AddNew(OrderDetailObject orderdetail)
        {
            OrderDAO orderDAO = new OrderDAO();
            ProductDAO productDAO = new ProductDAO();
            try
            {
                OrderDetailObject o = GetOrderDetailByOrderId(orderdetail.OrderID.OrderId);
                if (o == null)
                {
                    string SQLInsert = "INSERT tbl_Order values(@OrderId, @ProductId, @UnitPrice, @Quantity, @Discount)";
                    var parameters = new List<SqlParameter>();
                    parameters.Add(CreateParameter("@OrderId", 4, o.OrderID, DbType.Int32));
                    parameters.Add(CreateParameter("@ProductId", 4, o.ProductID, DbType.Int32));
                    parameters.Add(CreateParameter("@UnitPrice", 50, o.UnitPrice, DbType.Decimal));
                    parameters.Add(CreateParameter("@Quantity", 50, o.Quantity, DbType.Int32));
                    parameters.Add(CreateParameter("@Discount", 50, o.Discount, DbType.Double));
                    Insert(SQLInsert, CommandType.Text, parameters.ToArray());
                }
                else
                {
                    throw new Exception("This orderdetail is already exits.");
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

        public void Update(OrderDetailObject orderdetail)
        {
            try
            {
                OrderDetailObject o = GetOrderDetailByOrderId(orderdetail.OrderID.OrderId);
                if (o != null)
                {
                    string SQLUpdate = "UPDATE OrderDetail set OrderId = @OrderId,ProductId = @ProductId,UnitPrice = @UnitPrice, Quantity = @Quantity, Discount = @Discount WHERE OrderId = @OrderId";
                    var parameters = new List<SqlParameter>();
                    parameters.Add(CreateParameter("@OrderId", 4, o.OrderID, DbType.Int32));
                    parameters.Add(CreateParameter("@ProductId", 4, o.ProductID, DbType.Int32));
                    parameters.Add(CreateParameter("@UnitPrice", 50, o.UnitPrice, DbType.Decimal));
                    parameters.Add(CreateParameter("@Quantity", 50, o.Quantity, DbType.Int32));
                    parameters.Add(CreateParameter("@Discount", 50, o.Discount, DbType.Double));
                    Insert(SQLUpdate, CommandType.Text, parameters.ToArray());
                }
                else
                {
                    throw new Exception("OrderDetail does not exits.");
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
                OrderDetailObject o = GetOrderDetailByOrderId(orderId);
                if (o != null)
                {
                    string SQLDelete = "DELETE OrderDetail WHERE OrderID = @OrderId";
                    var param = CreateParameter("@OrderId", 4, orderId, DbType.Int32);
                    Delete(SQLDelete, CommandType.Text, param);
                }
                else
                {
                    throw new Exception("OrderDetail does not already exits.");
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

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Configuration;
using BusinessObject;

namespace DataAccess
{
    public class ProductDAO
    {
        private static ProductDAO instance = null;
        private static readonly object instanceLock = new object();
        public static ProductDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ProductDAO();
                    }
                    return instance;
                }
            }
        }
        public ProductDAO()
        {
            var connectionString = GetConnectionString();
            p = new ProductDAO(connectionString);
        }
        public ProductDAO p { get; set; } = null;
        public SqlConnection connection = null;
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
        public void CloseConnection() => p.CloseConnection(connection);

        private string ConnectionString { get; set; }
        public ProductDAO(string connectionString) => ConnectionString = connectionString;
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


        public IEnumerable<ProductObject> GetProductList()
        {
            IDataReader dataReader = null;
            string SQLSelect = "SELECT ProductId, CategoryId, ProductName, Weight, UnitPrice, UnitslnStock FROM Product";
            var pro = new List<ProductObject>();
            try
            {
                dataReader = GetDataReader(SQLSelect, CommandType.Text, out connection);
                while (dataReader.Read())
                {
                    pro.Add(new ProductObject
                    {
                        ProductId = dataReader.GetInt32(0),
                        CategoryId = dataReader.GetInt32(1),
                        ProductName = dataReader.GetString(2),
                        Weight = dataReader.GetString(3),
                        UnitPrice = dataReader.GetString(4),
                        UnitslnStock = dataReader.GetInt32(5)
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
            return pro;
        }

        public ProductObject GetProductByID(int proID)
        {
            ProductObject pro = null;
            IDataReader dataReader = null;
            string SQLSelect = "SELECT ProductId, CategoryId, ProductName, Weight, UnitPrice, UnitslnStock FROM Product WHERE ProductId = @ProductId";
            try
            {
                var param = CreateParameter("@ProductId", 4, proID, DbType.Int32);
                dataReader = GetDataReader(SQLSelect, CommandType.Text, out connection, param);
                if (dataReader.Read())
                {
                    pro = new ProductObject
                    {
                        ProductId = dataReader.GetInt32(0),
                        CategoryId = dataReader.GetInt32(1),
                        ProductName = dataReader.GetString(2),
                        Weight = dataReader.GetString(3),
                        UnitPrice = dataReader.GetString(4),
                        UnitslnStock = dataReader.GetInt32(5)
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
            return pro;
        }

        public void AddNew(ProductObject pro)
        {
            try
            {
                ProductObject product = GetProductByID(pro.ProductId);
                if (product.ProductId == null)
                {
                    string SQLInsert = "INSERT Product values(@ProductId, @CatagoryId, @ProductName, @Weight, @UnitPrice, @UnitslnStock)";
                    var parameters = new List<SqlParameter>();
                    parameters.Add(CreateParameter("@ProductId", 4, pro.ProductId, DbType.Int32));
                    parameters.Add(CreateParameter("@CatagoryId", 4, pro.CategoryId, DbType.Int32));
                    parameters.Add(CreateParameter("@ProductName", 50, pro.ProductName, DbType.String));
                    parameters.Add(CreateParameter("@Weight", 50, pro.Weight, DbType.String));
                    parameters.Add(CreateParameter("@UnitPrice", 50, pro.UnitPrice, DbType.String));
                    parameters.Add(CreateParameter("@UnitslnStock", 4, pro.UnitslnStock, DbType.Int32));
                    Insert(SQLInsert, CommandType.Text, parameters.ToArray());
                }
                else
                {
                    throw new Exception("The Product is already exits.");
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

        public void Update(ProductObject pro)
        {
            try
            {
                ProductObject p = GetProductByID(pro.ProductId);
                if (p != null)
                {
                    string SQLUpdate = "UPDATE Product set ProductName = @ProductName,Weight = @Weight,UnitPrice = @UnitPrice, UnitslnStock = @UnitslnStock WHERE ProductId = @ProductId AND CatagoryId = @CatagoryId";
                    var parameters = new List<SqlParameter>();
                    parameters.Add(CreateParameter("@ProductId", 4, pro.ProductId, DbType.Int32));
                    parameters.Add(CreateParameter("@CatagoryId", 4, pro.CategoryId, DbType.Int32));
                    parameters.Add(CreateParameter("@ProductName", 50, pro.ProductName, DbType.String));
                    parameters.Add(CreateParameter("@Weight", 50, pro.Weight, DbType.String));
                    parameters.Add(CreateParameter("@UnitPrice", 50, pro.UnitPrice, DbType.String));
                    parameters.Add(CreateParameter("@UnitslnStock", 4, pro.UnitslnStock, DbType.Int32));
                    Insert(SQLUpdate, CommandType.Text, parameters.ToArray());
                }
                else
                {
                    throw new Exception("The Product does not already exits.");
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

        public void Remove(int proID)
        {
            try
            {
                ProductObject pro = GetProductByID(proID);
                if (pro != null)
                {
                    string SQLDelete = "DELETE Product WHERE ProductId = @ProductId";
                    var param = CreateParameter("@ProductId", 4, proID, DbType.Int32);
                    Delete(SQLDelete, CommandType.Text, param);
                }
                else
                {
                    throw new Exception("The Product does not already exits.");
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
        public IEnumerable<ProductObject> SearchProductByIdAndName(int proID, String proName)
        {
            IDataReader dataReader = null;            
            var pro = new List<ProductObject>();
            try
            {
                string SQLSelect = "SELECT ProductId, CategoryId, ProductName, Weight, UnitPrice, UnitslnStock FROM Product WHERE ProductId = @ProductId AND ProductName = @ProductName";
                var id = CreateParameter("@ProductId", 4, proID, DbType.Int32);
                var name = CreateParameter("@ProductName", 50, proName, DbType.String);
                dataReader = GetDataReader(SQLSelect, CommandType.Text, out connection, id);
                dataReader = GetDataReader(SQLSelect, CommandType.Text, out connection, name);
                while (dataReader.Read())
                {
                    pro.Add(new ProductObject
                    {
                        ProductId = dataReader.GetInt32(0),
                        CategoryId = dataReader.GetInt32(1),
                        ProductName = dataReader.GetString(2),
                        Weight = dataReader.GetString(3),
                        UnitPrice = dataReader.GetString(4),
                        UnitslnStock = dataReader.GetInt32(5)
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
            return pro;
        }
        public IEnumerable<ProductObject> SearchProductByUPriceAndUStock(int price, String stock)
        {
            IDataReader dataReader = null;
            var pro = new List<ProductObject>();
            try
            {
                string SQLSelect = "SELECT ProductId, CategoryId, ProductName, Weight, UnitPrice, UnitslnStock FROM Product WHERE UnitPrice = @UnitPrice AND UnitslnStock = @UnitslnStock";
                var uPrice = CreateParameter("@ProductId", 4, price, DbType.Int32);
                var uStock = CreateParameter("@ProductName", 50, stock, DbType.String);
                dataReader = GetDataReader(SQLSelect, CommandType.Text, out connection, uPrice);
                dataReader = GetDataReader(SQLSelect, CommandType.Text, out connection, uStock);
                while (dataReader.Read())
                {
                    pro.Add(new ProductObject
                    {
                        ProductId = dataReader.GetInt32(0),
                        CategoryId = dataReader.GetInt32(1),
                        ProductName = dataReader.GetString(2),
                        Weight = dataReader.GetString(3),
                        UnitPrice = dataReader.GetString(4),
                        UnitslnStock = dataReader.GetInt32(5)
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
            return pro;
        }
    }
}

using System.Data;
using BussinessObject.Models;
using Microsoft.Data.SqlClient;


namespace DataAccess
{
    public class ProductDAO : BaseDAL
    {
        private static ProductDAO instance = null;
        private static readonly object instanceLock = new object();
        private ProductDAO() { }
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
        public IEnumerable<Product> GetProductList()
        {
            IDataReader dataReader = null;
            string SQLSelect = "SELECT [ProductId],[CategoryId],[ProductName],[Weight],[UnitPrice],[UnitslnStock] FROM [FStore_Ass2].[dbo].[tbl_Product]";
            var products = new List<Product>();
            try
            {
                dataReader = dataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection);
                while (dataReader.Read())
                {
                    products.Add(new Product
                    {
                        ProductId = dataReader.GetInt32(0),
                        CategoryId = dataReader.GetInt32(1),
                        ProductName = dataReader.GetString(2),
                        Weight = dataReader.GetString(3),
                        UnitPrice = dataReader.GetDecimal(4),
                        UnitInStock = dataReader.GetInt32(5)
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
            return products;
        }

        public Product GetProductByID(int proID)
        {
            Product pro = null;
            IDataReader dataReader = null;
            string SQLSelect = "SELECT ProductId, CategoryId, ProductName, Weight, UnitPrice, UnitslnStock FROM Product WHERE ProductId = @ProductId";
            try
            {
                var param = dataProvider.CreateParameter("@ProductId", 4, proID, DbType.Int32);
                dataReader = dataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection, param);
                if (dataReader.Read())
                {
                    pro = new Product
                    {
                        ProductId = dataReader.GetInt32(0),
                        CategoryId = dataReader.GetInt32(1),
                        ProductName = dataReader.GetString(2),
                        Weight = dataReader.GetString(3),
                        UnitPrice = dataReader.GetDecimal(4),
                        UnitInStock = dataReader.GetInt32(5)
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

        public Product GetProductByStock(int stock)
        {
            Product pro = null;
            IDataReader dataReader = null;
            string SQLSelect = "SELECT ProductId, CategoryId, ProductName, Weight, UnitPrice, UnitslnStock FROM Product WHERE UnitslnStock = @UnitslnStock";
            try
            {
                var param = dataProvider.CreateParameter("@UnitslnStock", 4, stock, DbType.Int32);
                dataReader = dataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection, param);
                if (dataReader.Read())
                {
                    pro = new Product
                    {
                        ProductId = dataReader.GetInt32(0),
                        CategoryId = dataReader.GetInt32(1),
                        ProductName = dataReader.GetString(2),
                        Weight = dataReader.GetString(3),
                        UnitPrice = dataReader.GetDecimal(4),
                        UnitInStock = dataReader.GetInt32(5)
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
        public Product GetProductByName(string name)
        {
            Product pro = null;
            IDataReader dataReader = null;
            string SQLSelect = "SELECT ProductId, CategoryId, ProductName, Weight, UnitPrice, UnitslnStock FROM Product WHERE ProductName like N'@ProductName'";
            try
            {
                var param = dataProvider.CreateParameter("@ProductName", 50, name, DbType.String);
                dataReader = dataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection, param);
                if (dataReader.Read())
                {
                    pro = new Product
                    {
                        ProductId = dataReader.GetInt32(0),
                        CategoryId = dataReader.GetInt32(1),
                        ProductName = dataReader.GetString(2),
                        Weight = dataReader.GetString(3),
                        UnitPrice = dataReader.GetDecimal(4),
                        UnitInStock = dataReader.GetInt32(5)
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

        public Product GetProductByPrice(decimal price)
        {
            Product pro = null;
            IDataReader dataReader = null;
            string SQLSelect = "SELECT ProductId, CategoryId, ProductName, Weight, UnitPrice, UnitslnStock FROM Product WHERE UnitPrice = @UnitPrice";
            try
            {
                var p = dataProvider.CreateParameter("@UnitPrice", 50, price, DbType.Decimal);
                dataReader = dataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection, p);
                if (dataReader.Read())
                {
                    pro = new Product
                    {
                        ProductId = dataReader.GetInt32(0),
                        CategoryId = dataReader.GetInt32(1),
                        ProductName = dataReader.GetString(2),
                        Weight = dataReader.GetString(3),
                        UnitPrice = dataReader.GetDecimal(4),
                        UnitInStock = dataReader.GetInt32(5)
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

        public void AddNew(Product pro)
        {
            try
            {
                Product product = GetProductByID(pro.ProductId);
                if (product.ProductId == null)
                {
                    string SQLInsert = "INSERT Product values(@ProductId, @CatagoryId, @ProductName, @Weight, @UnitPrice, @UnitslnStock)";
                    var parameters = new List<SqlParameter>();
                    parameters.Add(dataProvider.CreateParameter("@ProductId", 4, pro.ProductId, DbType.Int32));
                    parameters.Add(dataProvider.CreateParameter("@CatagoryId", 4, pro.CategoryId, DbType.Int32));
                    parameters.Add(dataProvider.CreateParameter("@ProductName", 50, pro.ProductName, DbType.String));
                    parameters.Add(dataProvider.CreateParameter("@Weight", 50, pro.Weight, DbType.String));
                    parameters.Add(dataProvider.CreateParameter("@UnitPrice", 50, pro.UnitPrice, DbType.Decimal));
                    parameters.Add(dataProvider.CreateParameter("@UnitslnStock", 4, pro.UnitInStock, DbType.Int32));
                    dataProvider.Insert(SQLInsert, CommandType.Text, parameters.ToArray());
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

        public void Update(Product pro)
        {
            try
            {
                Product p = GetProductByID(pro.ProductId);
                if (p != null)
                {
                    string SQLUpdate = "UPDATE Product set ProductName = @ProductName,Weight = @Weight,UnitPrice = @UnitPrice, UnitslnStock = @UnitslnStock WHERE ProductId = @ProductId AND CatagoryId = @CatagoryId";
                    var parameters = new List<SqlParameter>();
                    parameters.Add(dataProvider.CreateParameter("@ProductId", 4, pro.ProductId, DbType.Int32));
                    parameters.Add(dataProvider.CreateParameter("@CatagoryId", 4, pro.CategoryId, DbType.Int32));
                    parameters.Add(dataProvider.CreateParameter("@ProductName", 50, pro.ProductName, DbType.String));
                    parameters.Add(dataProvider.CreateParameter("@Weight", 50, pro.Weight, DbType.String));
                    parameters.Add(dataProvider.CreateParameter("@UnitPrice", 50, pro.UnitPrice, DbType.Decimal));
                    parameters.Add(dataProvider.CreateParameter("@UnitslnStock", 4, pro.UnitInStock, DbType.Int32));
                    dataProvider.Insert(SQLUpdate, CommandType.Text, parameters.ToArray());
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
                Product pro = GetProductByID(proID);
                if (pro != null)
                {
                    string SQLDelete = "DELETE Product WHERE ProductId = @ProductId";
                    var param = dataProvider.CreateParameter("@ProductId", 4, proID, DbType.Int32);
                    dataProvider.Delete(SQLDelete, CommandType.Text, param);
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
        public IEnumerable<Product> SearchProduct(int proID, int stock)
        {
            IDataReader dataReader = null;
            var pro = new List<Product>();
            Product pId = GetProductByID(proID);
            Product stk = GetProductByStock(stock);
            try
            {
                if (pId.ProductId != 0)
                {
                    string SQLSelect = "SELECT ProductId, CategoryId, ProductName, Weight, UnitPrice, UnitslnStock FROM Product WHERE ProductId = @ProductId";
                    var id = dataProvider.CreateParameter("@ProductId", 4, proID, DbType.Int32);
                    dataReader = dataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection, id);
                    while (dataReader.Read())
                    {
                        pro.Add(new Product
                        {
                            ProductId = dataReader.GetInt32(0),
                            CategoryId = dataReader.GetInt32(1),
                            ProductName = dataReader.GetString(2),
                            Weight = dataReader.GetString(3),
                            UnitPrice = dataReader.GetDecimal(4),
                            UnitInStock = dataReader.GetInt32(5)
                        });
                    }
                }
                else if (stk.UnitInStock != 0)
                {
                    string SQLSelect = "SELECT ProductId, CategoryId, ProductName, Weight, UnitPrice, UnitslnStock FROM Product WHERE UnitslnStock = @UnitslnStock";
                    var s = dataProvider.CreateParameter("@UnitslnStock", 4, stock, DbType.Int32);
                    dataReader = dataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection, s);
                    while (dataReader.Read())
                    {
                        pro.Add(new Product
                        {
                            ProductId = dataReader.GetInt32(0),
                            CategoryId = dataReader.GetInt32(1),
                            ProductName = dataReader.GetString(2),
                            Weight = dataReader.GetString(3),
                            UnitPrice = dataReader.GetDecimal(4),
                            UnitInStock = dataReader.GetInt32(5)
                        });
                    }
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
        public IEnumerable<Product> SearchProduct(string name)
        {
            IDataReader dataReader = null;
            var pro = new List<Product>();
            Product pname = GetProductByName(name);
            try
            {
                if (pname.ProductName != null)
                {
                    string SQLSelect = "SELECT ProductId, CategoryId, ProductName, Weight, UnitPrice, UnitslnStock FROM Product WHERE ProductId like N'@ProductName'";
                    var proName = dataProvider.CreateParameter("@ProductName", 50, name, DbType.String);
                    dataReader = dataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection, proName);
                    while (dataReader.Read())
                    {
                        pro.Add(new Product
                        {
                            ProductId = dataReader.GetInt32(0),
                            CategoryId = dataReader.GetInt32(1),
                            ProductName = dataReader.GetString(2),
                            Weight = dataReader.GetString(3),
                            UnitPrice = dataReader.GetDecimal(4),
                            UnitInStock = dataReader.GetInt32(5)
                        });
                    }
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
        public IEnumerable<Product> SearchProduct(decimal price)
        {
            IDataReader dataReader = null;
            var pro = new List<Product>();
            Product p = GetProductByPrice(price);
            try
            {
                if (p.UnitPrice != null)
                {
                    string SQLSelect = "SELECT ProductId, CategoryId, ProductName, Weight, UnitPrice, UnitslnStock FROM Product WHERE UnitPrice = @UnitPrice";
                    var proPrice = dataProvider.CreateParameter("@UnitPrice", 50, price, DbType.Decimal);
                    dataReader = dataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection, proPrice);
                    while (dataReader.Read())
                    {
                        pro.Add(new Product
                        {
                            ProductId = dataReader.GetInt32(0),
                            CategoryId = dataReader.GetInt32(1),
                            ProductName = dataReader.GetString(2),
                            Weight = dataReader.GetString(3),
                            UnitPrice = dataReader.GetDecimal(4),
                            UnitInStock = dataReader.GetInt32(5)
                        });
                    }
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


using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Configuration;
using BusinessObject;
using System;

namespace DataAccess
{
    public class OrderDetailDAO : BaseDAL
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

        public IEnumerable<OrderDetailObject> getOrderDetailList()
        {
            OrderDAO orderDAO = new OrderDAO();
            ProductDAO productDAO = new ProductDAO();
            IDataReader dataReader = null;
            string SQLSelect = "SELECT * FROM OrderDetail";
            var orderdetails = new List<OrderDetailObject>();
            try
            {
                OrderDAO o = new OrderDAO();
                ProductDAO p = new ProductDAO();
                dataReader = dataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection);
                while (dataReader.Read())
                {
                    orderdetails.Add(new OrderDetailObject
                    {
                        Order = o.GetOrderById(dataReader.GetInt32(0)),
                        Product = p.GetProductByID(dataReader.GetInt32(1)),
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
                OrderDAO o = new OrderDAO();
                ProductDAO p = new ProductDAO();
                var param = dataProvider.CreateParameter("@OrderId", 4, orderId, DbType.Int32);
                dataReader = dataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection, param);
                if (dataReader.Read())
                {
                    orderdetail = new OrderDetailObject
                    {
                        Order = o.GetOrderById(dataReader.GetInt32(0)),
                        Product = p.GetProductByID(dataReader.GetInt32(1)),
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
                OrderDetailObject o = GetOrderDetailByOrderId(orderdetail.Order.OrderId);
                if (o == null)
                {
                    string SQLInsert = "INSERT tbl_Order values(@OrderId, @ProductId, @UnitPrice, @Quantity, @Discount)";
                    var parameters = new List<SqlParameter>();
                    parameters.Add(dataProvider.CreateParameter("@OrderId", 4, o.Order.OrderId, DbType.Int32));
                    parameters.Add(dataProvider.CreateParameter("@ProductId", 4, o.Product.ProductId, DbType.Int32));
                    parameters.Add(dataProvider.CreateParameter("@UnitPrice", 50, o.UnitPrice, DbType.Decimal));
                    parameters.Add(dataProvider.CreateParameter("@Quantity", 50, o.Quantity, DbType.Int32));
                    parameters.Add(dataProvider.CreateParameter("@Discount", 50, o.Discount, DbType.Double));
                    dataProvider.Insert(SQLInsert, CommandType.Text, parameters.ToArray());
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
                OrderDetailObject o = GetOrderDetailByOrderId(orderdetail.Order.OrderId);
                if (o != null)
                {
                    string SQLUpdate = "UPDATE OrderDetail set OrderId = @OrderId,ProductId = @ProductId,UnitPrice = @UnitPrice, Quantity = @Quantity, Discount = @Discount WHERE OrderId = @OrderId";
                    var parameters = new List<SqlParameter>();
                    parameters.Add(dataProvider.CreateParameter("@OrderId", 4, o.Order.OrderId, DbType.Int32));
                    parameters.Add(dataProvider.CreateParameter("@ProductId", 4, o.Product.ProductId, DbType.Int32));
                    parameters.Add(dataProvider.CreateParameter("@UnitPrice", 50, o.UnitPrice, DbType.Decimal));
                    parameters.Add(dataProvider.CreateParameter("@Quantity", 50, o.Quantity, DbType.Int32));
                    parameters.Add(dataProvider.CreateParameter("@Discount", 50, o.Discount, DbType.Double));
                    dataProvider.Insert(SQLUpdate, CommandType.Text, parameters.ToArray());
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
                    var param = dataProvider.CreateParameter("@OrderId", 4, orderId, DbType.Int32);
                    dataProvider.Delete(SQLDelete, CommandType.Text, param);
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

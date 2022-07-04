using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Configuration;
using BusinessObject;
using System;

namespace DataAccess
{
    public class OrderDAO : BaseDAL
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

        public IEnumerable<OrderObject> getOrderList()
        {
            MemberDAO m = new MemberDAO();
            IDataReader dataReader = null;
            string SQLSelect = "SELECT * FROM tbl_Order";
            var orders = new List<OrderObject>();
            try
            {
                dataReader = dataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection);
                while (dataReader.Read())
                {
                    orders.Add(new OrderObject
                    {
                        OrderId = dataReader.GetInt32(0),
                        Member = m.GetMemberByID(dataReader.GetInt32(1)),
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
                MemberDAO m = new MemberDAO();
                var param = dataProvider.CreateParameter("@OrderId", 4, orderId, DbType.Int32);
                dataReader = dataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection, param);
                if (dataReader.Read())
                {
                    order = new OrderObject
                    {
                        OrderId = dataReader.GetInt32(0),
                        Member = m.GetMemberByID(dataReader.GetInt32(1)),
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
                MemberDAO m = new MemberDAO();
                var fromDate = dataProvider.CreateParameter("@FromDate", 4, min, DbType.DateTime);
                var toDate = dataProvider.CreateParameter("@ToDate", 50, max, DbType.DateTime);
                dataReader = dataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection, fromDate);
                dataReader = dataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection, toDate);
                if (dataReader.Read())
                {
                    orders.Add(new OrderObject
                    {
                        OrderId = dataReader.GetInt32(0),
                        Member = m.GetMemberByID(dataReader.GetInt32(1)),
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
                if (o == null)
                {
                    string SQLInsert = "INSERT tbl_Order values(@OrderId, @MemberId, @OrderDate, @RequiredDate, @ShippedDate, @Freight)";
                    var parameters = new List<SqlParameter>();
                    parameters.Add(dataProvider.CreateParameter("@OrderId", 4, o.OrderId, DbType.Int32));
                    parameters.Add(dataProvider.CreateParameter("@MemberId", 4, o.Member.MemberId, DbType.String));
                    parameters.Add(dataProvider.CreateParameter("@OrderDate", 50, o.OrderDate, DbType.DateTime));
                    parameters.Add(dataProvider.CreateParameter("@RequiredDate", 50, o.RequiredDate, DbType.DateTime));
                    parameters.Add(dataProvider.CreateParameter("@ShippedDate", 50, o.ShippedDate, DbType.DateTime));
                    parameters.Add(dataProvider.CreateParameter("@Freight", 4, o.Freight, DbType.Decimal));
                    dataProvider.Insert(SQLInsert, CommandType.Text, parameters.ToArray());
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
                    parameters.Add(dataProvider.CreateParameter("@OrderId", 4, o.OrderId, DbType.Int32));
                    parameters.Add(dataProvider.CreateParameter("@MemberId", 4, o.Member.MemberId, DbType.Int32));
                    parameters.Add(dataProvider.CreateParameter("@OrderDate", 50, o.OrderDate, DbType.DateTime));
                    parameters.Add(dataProvider.CreateParameter("@RequiredDate", 50, o.RequiredDate, DbType.DateTime));
                    parameters.Add(dataProvider.CreateParameter("@ShippedDate", 50, o.ShippedDate, DbType.DateTime));
                    parameters.Add(dataProvider.CreateParameter("@Freight", 4, o.Freight, DbType.Decimal));
                    dataProvider.Insert(SQLUpdate, CommandType.Text, parameters.ToArray());
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
                    var param = dataProvider.CreateParameter("@OrderId", 4, orderId, DbType.Int32);
                    dataProvider.Delete(SQLDelete, CommandType.Text, param);
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

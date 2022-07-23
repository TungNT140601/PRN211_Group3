using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_03_Library.DataAccess
{
    public class OrderDetailDAO
    {
        private static OrderDetailDAO instance;
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

        public IEnumerable<OrderDetail> GetOrderDetailList()
        {
            var orderDetails = new List<OrderDetail>();
            try
            {
                using var context = new FStoreContext();
                orderDetails = context.OrderDetails.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orderDetails;
        }

        public OrderDetail GetOrderDetailByOrderID(int orderId)
        {
            OrderDetail orderDetail = null;
            try
            {
                using var context = new FStoreContext();
                orderDetail = context.OrderDetails.FirstOrDefault(o=> o.OrderId == orderId);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orderDetail;
        }

        public void AddNew(OrderDetail orderDetail)
        {
            try
            {
                OrderDetail _orderDetail = GetOrderDetailByOrderID(orderDetail.OrderId);
                if (_orderDetail == null)
                {
                    using var context = new FStoreContext();
                    context.OrderDetails.Add(orderDetail);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The order detail is already exits.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update (OrderDetail orderDetail)
        {
            try
            {
                OrderDetail _orderDetail = GetOrderDetailByOrderID(orderDetail.OrderId);
                if (_orderDetail != null)
                {
                    using var context = new FStoreContext();
                    context.OrderDetails.Update(orderDetail);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The order detail does not exit.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Remove(int orderID)
        {
            try
            {
                OrderDetail orderDetail = GetOrderDetailByOrderID(orderID);
                if (orderDetail != null)
                {
                    using var context = new FStoreContext();
                    context.OrderDetails.Remove(orderDetail);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The order detail does not exit.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

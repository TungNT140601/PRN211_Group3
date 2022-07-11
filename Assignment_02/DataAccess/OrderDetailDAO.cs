using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BussinessObject.Models;

namespace DataAccess
{
    public class OrderDetailDAO
    {
        private OrderDetailDAO() { }
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

        public List<BussinessObject.Models.OrderDetail>? GetOrderDetails(int orderID)
        {
            List<BussinessObject.Models.OrderDetail>? listOrders = new List<BussinessObject.Models.OrderDetail>();
            try
            {
                FStoreContext DbContext = new FStoreContext();
                listOrders = DbContext.OrderDetails.Where(s => s.OrderId == orderID).ToList();
                if (listOrders.Count == 0)
                    listOrders = null;
            }
            catch (Exception)
            {
                throw new Exception("Get list order details failed! ");
            }
            return listOrders;
        }

        public void AddNewOrderDetail(BussinessObject.Models.OrderDetail orderDetails)
        {
            try
            {
                FStoreContext DbContext = new FStoreContext();
                DbContext.OrderDetails.Add(orderDetails);
                DbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Add failed!");
            }
        }

        public void DeleteOrderDetail(int orderID, int productID)
        {
            try
            {
                FStoreContext DbContext = new FStoreContext();
                BussinessObject.Models.OrderDetail? orderDetail = DbContext.OrderDetails.
                    SingleOrDefault(orderDetail => (orderDetail.OrderId == orderID && orderDetail.ProductId == productID));
                DbContext.OrderDetails.Remove(orderDetail);
                DbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Delete failed!");
            }
        }

        public void UpdateOrderDetail(BussinessObject.Models.OrderDetail orderDetail)
        {
            try
            {
                FStoreContext DbContext = new FStoreContext();
                DbContext.Entry<BussinessObject.Models.OrderDetail>(orderDetail).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                DbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Update failed!");
            }
        }
    }


}

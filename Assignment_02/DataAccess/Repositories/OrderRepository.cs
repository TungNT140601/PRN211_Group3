using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public List<TblOrder> GetOrders() => OrderDAO.Instance.GetOrders();
        public TblOrder GetOrderByID(int ID) => OrderDAO.Instance.GetOrderByID(ID);
        public void AddOrder(TblOrder order) => OrderDAO.Instance.AddOrder(order);
        public void UpdateOrder(TblOrder order) => OrderDAO.Instance.UpdateOrder(order);
        public void DeleteOrder(int orderID) => OrderDAO.Instance.DeleteOrder(orderID);
    }
}

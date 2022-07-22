using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_03_Library.DataAccess;

namespace Assignment_03_Library.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public Order GetOrderByID(int orderID) => OrderDAO.Instance.GetOrderByID(orderID);
        public IEnumerable<Order> GetOrderList() => OrderDAO.Instance.GetOrderList();
        public void Addnew(Order order) => OrderDAO.Instance.Addnew(order);
        public void Update(Order order) => OrderDAO.Instance.Update(order);
        public void Remove(int orderID) => OrderDAO.Instance.Remove(orderID);
    }
}

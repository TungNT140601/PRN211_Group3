using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
namespace DataAccess.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public OrderObject GetOderById(int orderID) => OrderDAO.Instance.GetOrderById(orderID);
        public IEnumerable<OrderObject> GetOrders() => OrderDAO.Instance.getOrderList();
        public void InsertOrder(OrderObject order) => OrderDAO.Instance.AddNew(order);
        public void DeleteOrder(int orderId) => OrderDAO.Instance.Remove(orderId);
        public void UpdateOrder(OrderObject order) => OrderDAO.Instance.Update(order);

        public IEnumerable<OrderObject> SearchByDay(DateTime min, DateTime max) => OrderDAO.Instance.SearchByDay(min, max);
        public IEnumerable<OrderObject> SortBySale() => OrderDAO.Instance.SortBySale();

        public OrderObject GetOrderByID(int orderID)
        {
            throw new NotImplementedException();
        }

        public void DeleteMem(int orderID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderObject> SearchByDay(int memID, string pass)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderObject> SortBySales()
        {
            throw new NotImplementedException();
        }
    }
}

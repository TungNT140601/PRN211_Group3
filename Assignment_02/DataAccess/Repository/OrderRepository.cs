using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
namespace DataAccess.Repository
{
<<<<<<< HEAD
    //public class OrderRepository : IOrderRepository
    //{
    //    public OrderObject GetOderById(int orderID) => OrderObject.Instance.GetOderById(orderID);
    //    public IEnumerable<MemberObject> GetMembers() => MemberDAO.Instance.GetMemberList();
    //    public void InsertMem(MemberObject mem) => MemberDAO.Instance.AddNew(mem);
    //    public void DeleteMem(int memID) => MemberDAO.Instance.Remove(memID);
    //    public void UpdateMem(MemberObject mem) => MemberDAO.Instance.Update(mem);
    //}
=======
    public class OrderRepository : IOrderRepository
    {
        public OrderObject GetOderById(int orderID) => OrderDAO.Instance.GetOrderById(orderID);
        public IEnumerable<OrderObject> GetOrders() => OrderDAO.Instance.getOrderList();
        public void InsertOrder(OrderObject order) => OrderDAO.Instance.AddNew(order);
        public void DeleteOrder(int orderId) => OrderDAO.Instance.Remove(orderId);
        public void UpdateOrder(OrderObject order) => OrderDAO.Instance.Update(order);

        public IEnumerable<OrderObject> SearchByDay(DateTime min, DateTime max) => OrderDAO.Instance.SearchByDay(min, max);
        public IEnumerable<OrderObject> SortBySale() => OrderDAO.Instance.SortBySale();
    }
>>>>>>> 994d2024d79a6dc9e9e2a848b4955e1f4118b3c2
}

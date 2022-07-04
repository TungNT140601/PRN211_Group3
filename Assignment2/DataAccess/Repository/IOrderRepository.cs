using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
namespace DataAccess.Repository
{
    public interface IOrderRepository
    {
        IEnumerable<OrderObject> GetOrders();
        OrderObject GetOrderByID(int orderID);
        void InsertOrder(OrderObject order);
        void UpdateOrder(OrderObject order);
        void DeleteOrder(int orderID);
        IEnumerable<OrderObject> SearchByDay(DateTime min, DateTime max);
        IEnumerable<OrderObject> SortBySales();
    }


}

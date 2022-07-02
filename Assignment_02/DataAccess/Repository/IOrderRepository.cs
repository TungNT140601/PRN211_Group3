using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
namespace DataAccess.Repository
 {   public interface IOrderRepository {
        IEnumerable<OrderObject> GetOrders();
        OrderObject GetOrderByID(int orderID);
        void InsertOrder(OrderObject order);
        void UpdateOrder(OrderObject order);
        void DeleteMem(int orderID);
        IEnumerable<OrderObject> SearchByDay(int memID, String pass);
        IEnumerable<OrderObject> SortBySales();
    }

  
}

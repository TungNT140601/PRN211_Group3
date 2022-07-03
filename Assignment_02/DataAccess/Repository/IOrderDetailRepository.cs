using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
namespace DataAccess.Repository
{
    public interface IOrderDetailRepository
    {
        IEnumerable<OrderDetailDAO> GetOrderDetailList ();
        OrderDetailDAO GetOrderDetailByOrderID(int orderID);
        void InsertOrderDetail(OrderDetailDAO order);
        void UpdateOrderDetail(OrderDetailDAO order);
        void DeleteOrderDetail(int orderID);
 
    }


}

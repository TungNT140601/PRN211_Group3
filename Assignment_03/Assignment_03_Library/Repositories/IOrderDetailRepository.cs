using Assignment_03_Library.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_03_Library.Repositories
{
    public interface IOrderDetailRepository
    {
        IEnumerable<OrderDetail> GetOrderDetails();
        OrderDetail GetOrderDetailByOrderID(int orderID);
        void InsertOrderDetail(OrderDetail orderDetail);    
        void DeleteOrderDetail(int orderID);
        void UpdateOrderDetail(OrderDetail orderDetail);
    }
}

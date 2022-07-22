using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_03_Library.DataAccess;

namespace Assignment_03_Library.Repositories
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetOrderList();
        Order GetOrderByID(int orderID);
        void Addnew(Order order);
        void Update(Order order);
        void Remove(int orderID);
    }
}

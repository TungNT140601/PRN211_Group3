using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface IOrderRepository
    {
        List<TblOrder> GetOrders();
        TblOrder GetOrderByID(int ID);
        void AddOrder(TblOrder order);
        void UpdateOrder(TblOrder order);
        void DeleteOrder(int orderID);
    }
}

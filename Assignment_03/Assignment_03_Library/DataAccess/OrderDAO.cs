using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_03_Library.DataAccess
{
    public class OrderDAO
    {
        private static OrderDAO instance = null;
        private static readonly object instanceLock = new object();
        public static OrderDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if(instance == null)
                    {
                        instance = new OrderDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<Order> GetOrderList()
        {
            var orders =  new List<Order>();
            try
            {
                using var context = new FStoreContext();
                orders = context.Orders.ToList();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                
            }
            return orders;
        }

        public Order GetOrderByID(int orderID)
        {
            Order order = null;
            try
            {
                using var context = new FStoreContext();
                order = context.Orders.SingleOrDefault(c => c.OrderId == orderID);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return order;
        }
        //---------------------------------------------------------------------------------------
        public void Addnew(Order order)
        {
            try
            {
                Order _order = GetOrderByID(order.OrderId);
                if(_order == null)
                {
                    using var context = new FStoreContext();
                    context.Orders.Add(order);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The order is already exist.");
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        // ------------------------------------------------------------------------
        public void Update(Order order)
        {
            try
            {
                Order _order = GetOrderByID(order.OrderId);
                if (_order != null)
                {
                    using var context = new FStoreContext();
                    context.Orders.Update(order);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The order does not already exist.");
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        //-----------------------------------------------------------
        public void Remove(int orderID)
        {
            try
            {
                Order order = GetOrderByID(orderID);
                if (order != null)
                {
                    using var context = new FStoreContext();
                    context.Orders.Remove(order);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The order does not already exist.");
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }// end Remove

    }// end class
}

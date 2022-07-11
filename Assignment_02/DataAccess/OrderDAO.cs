using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderDAO : FStoreContext
    {
        private static OrderDAO instance = null;
        private static readonly object instanceLock = new object();
        public static OrderDAO Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new OrderDAO();
                }
                return instance;
            }
        }
        public OrderDAO() { }
        public List<TblOrder> GetOrders()
        {
            List<TblOrder> orders;
            try
            {
                FStoreContext fStoreContext = new FStoreContext();
                orders = fStoreContext.TblOrders.ToList();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orders;
        }

        public TblOrder GetOrderByID(int ID)
        {
            TblOrder? order;
            try
            {
                FStoreContext fStoreContext = new FStoreContext();
                order = fStoreContext.TblOrders.Where(p => p.OrderId == ID).FirstOrDefault();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return order;
        }

        public void AddOrder(TblOrder order)
        {
            try
            {
                FStoreContext fStoreContext = new FStoreContext();
                fStoreContext.TblOrders.Add(order);
                fStoreContext.SaveChanges();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateOrder(TblOrder order)
        {
            try
            {
                FStoreContext fStoreContext = new FStoreContext();
                fStoreContext.Entry<TblOrder>(order).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                fStoreContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void DeleteOrder(int orderID)
        {
            try
            {
                FStoreContext fStoreContext = new FStoreContext();
                TblOrder? order = fStoreContext.TblOrders.SingleOrDefault(p => p.OrderId == orderID);
                fStoreContext.TblOrders.Remove(order);
                fStoreContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

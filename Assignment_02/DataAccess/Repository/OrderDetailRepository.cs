using System.Text;
using System.Threading.Tasks;
using BusinessObject;
namespace DataAccess.Repository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        public OrderDetailObject GetOrderDetailByOrderID(int orderID) => OrderDetailDAO.Instance.GetOrderDetailByOrderId(orderID);
        public IEnumerable<OrderDetailObject> GetOrderDetail() => OrderDetailDAO.Instance.getOrderDetailList();
        public void InsertOrderDetail(OrderDetailObject orderdetail) => OrderDetailDAO.Instance.AddNew(orderdetail);
        public void DeleteOrderDetail(int orderId) => OrderDetailDAO.Instance.Remove(orderId);
        public void UpdateOrderDetail(OrderDetailObject order) => OrderDetailDAO.Instance.Update(order);


    }
}

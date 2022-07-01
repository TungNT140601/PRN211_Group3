using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using DataAccess.Repository;
namespace DataAccess.Repository
{
    public class ProductRepository : IProductRepository
    {
        public ProductObject GetProductByID(int proID) => ProductDAO.Instance.GetProductByID(proID);
        public IEnumerable<ProductObject> GetProducts() => ProductDAO.Instance.GetProductList();
        public void InsertPro(ProductObject pro) => ProductDAO.Instance.AddNew(pro);
        public void DeletePro(int proID) => ProductDAO.Instance.Remove(proID);
        public void UpdatePro(ProductObject pro) => ProductDAO.Instance.Update(pro);
    }
}

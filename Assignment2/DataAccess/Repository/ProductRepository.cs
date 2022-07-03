using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ProductRepository : IProductRepository
    {
        public IEnumerable<ProductObject> GetProducts() => ProductDAO.Instance.GetProductList();
        public ProductObject GetProductByID(int ID)
        {
            throw new NotImplementedException();
        }
        public void InsertProduct(ProductObject product)
        {
            throw new NotImplementedException();
        }
        public void UpdateProduct(ProductObject product)
        {
            throw new NotImplementedException();
        }
        public void DeleteProduct(ProductObject product)
        {
            throw new NotImplementedException();
        }

    }
}

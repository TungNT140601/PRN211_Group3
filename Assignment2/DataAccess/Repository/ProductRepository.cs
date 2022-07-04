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
        public ProductObject GetProductByID(int ID) => ProductDAO.Instance.GetProductByID(ID);
        public void InsertProduct(ProductObject product) => ProductDAO.Instance.AddNew(product);
        public void UpdateProduct(ProductObject product) => ProductDAO.Instance.Update(product);
        public void DeleteProduct(int product) => ProductDAO.Instance.Remove(product);
        public IEnumerable<ProductObject> SearchProduct(int proID, int stock) => ProductDAO.Instance.SearchProduct(proID, stock);
        public IEnumerable<ProductObject> SearchProduct(string name) => ProductDAO.Instance.SearchProduct(name);
        public IEnumerable<ProductObject> SearchProduct(decimal price) => ProductDAO.Instance.SearchProduct(price);

    }
}

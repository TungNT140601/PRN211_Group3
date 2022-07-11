using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessObject.Models;
namespace DataAccess.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public IEnumerable<Product> GetProducts() => ProductDAO.Instance.GetProductList();
        public Product GetProductByID(int ID) => ProductDAO.Instance.GetProductByID(ID);
        public void InsertProduct(Product product) => ProductDAO.Instance.AddNew(product);
        public void UpdateProduct(Product product) => ProductDAO.Instance.Update(product);
        public void DeleteProduct(int product) => ProductDAO.Instance.Remove(product);
        public IEnumerable<Product> SearchProduct(int proID, int stock) => ProductDAO.Instance.SearchProduct(proID, stock);
        public IEnumerable<Product> SearchProduct(string name) => ProductDAO.Instance.SearchProduct(name);
        public IEnumerable<Product> SearchProduct(decimal price) => ProductDAO.Instance.SearchProduct(price);

    }
}

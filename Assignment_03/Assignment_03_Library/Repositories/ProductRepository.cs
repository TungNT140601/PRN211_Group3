using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_03_Library.DataAccess;
namespace Assignment_03_Library.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public IEnumerable<Product> GetProducts() => ProductDAO.Instance.GetProducts();
        public Product GetProductById(int id) => ProductDAO.Instance.GetProductById(id);
        public void Add(Product product) => ProductDAO.Instance.Add(product);
        public void Update(Product pro) => ProductDAO.Instance.Update(pro);
        public void Delete(int id) => ProductDAO.Instance.Delete(id);
        public List<Product> GetProductsByName(string name) => ProductDAO.Instance.GetProductsByName(name);
        public List<Product> GetProductsByUnitPrice(decimal unitPrice) => ProductDAO.Instance.GetProductsByUnitPrice(unitPrice);
    }
}

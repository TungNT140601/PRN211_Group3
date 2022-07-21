using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_03_Library.DataAccess;
namespace Assignment_03_Library.Repositories
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetProducts();
        public Product GetProductById(int id);
        public void Add(Product product);
        public void Update(Product pro);
        public void Delete(int id);
        public List<Product> GetProductsByName(string name);
        public List<Product> GetProductsByUnitPrice(decimal unitPrice);
    }
}

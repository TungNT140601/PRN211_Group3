using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessObject.Models;
namespace DataAccess.Repositories
{
    public interface IProductRepository
    {
        public List<Product> GetProductList();
        public Product GetProductByID(int ID);
        public void InsertProduct(Product product);
        public void UpdateProduct(Product product);
        public void DeleteProduct(int product);
        public List<Product> GetProductByStock(int stock1, int stock2);
        public List<Product> GetProductByName(string name);
         public List<Product> GetProductByPrice(decimal price1, decimal price2);
    }
}

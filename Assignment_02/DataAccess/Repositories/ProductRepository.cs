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
        public List<Product> GetProductList() => ProductDAO.Instance.GetProductList();
        public Product GetProductByID(int ID) => ProductDAO.Instance.GetProductByID(ID);
        public void InsertProduct(Product product) => ProductDAO.Instance.AddNew(product);
        public void UpdateProduct(Product product) => ProductDAO.Instance.Update(product);
        public void DeleteProduct(int product) => ProductDAO.Instance.Remove(product);
        public List<Product> GetProductByStock(int stock1, int stock2) => ProductDAO.Instance.GetProductByStock(stock1, stock2);
        public List<Product> GetProductByName(string name) => ProductDAO.Instance.GetProductByName(name);
        public List<Product> GetProductByPrice(decimal price1, decimal price2) => ProductDAO.Instance.GetProductByPrice(price1, price2);


    }
}

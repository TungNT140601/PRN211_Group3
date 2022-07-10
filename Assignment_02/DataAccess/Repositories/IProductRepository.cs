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
        IEnumerable<Product> GetProducts();
        Product GetProductByID(int ID);
        void DeleteProduct(int product);
        void InsertProduct(Product product);
        void UpdateProduct(Product product);
        IEnumerable<Product> SearchProduct(int proID, int stock);
        IEnumerable<Product> SearchProduct(string name);
        IEnumerable<Product> SearchProduct(decimal price);
    }
}

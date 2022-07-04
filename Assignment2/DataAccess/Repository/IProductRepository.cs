using System.Collections;
using BusinessObject;

namespace DataAccess.Repository
{
    public interface IProductRepository
    {
        IEnumerable<ProductObject> GetProducts();
        ProductObject GetProductByID(int ID);
        void DeleteProduct(int product);
        void InsertProduct(ProductObject product);
        void UpdateProduct(ProductObject product);
        IEnumerable<ProductObject> SearchProduct(int proID, int stock);
        IEnumerable<ProductObject> SearchProduct(string name);
        IEnumerable<ProductObject> SearchProduct(decimal price);
    }
}

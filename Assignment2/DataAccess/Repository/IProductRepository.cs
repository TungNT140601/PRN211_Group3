using System.Collections;
using BusinessObject;

namespace DataAccess.Repository
{
    public interface IProductRepository
    {
        IEnumerable<ProductObject> GetProducts();
        ProductObject GetProductByID(int ID);
        void DeleteProduct(ProductObject product);
        void InsertProduct(ProductObject product);
        void UpdateProduct(ProductObject product);
    }
}

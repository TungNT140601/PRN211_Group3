using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
namespace DataAccess.Repository
{
    public interface IProductRepository
    {
        IEnumerable<ProductObject> GetProducts();
        ProductObject GetProductByID(int proID);
        void InsertPro(ProductObject pro);
        void UpdatePro(ProductObject pro);
        void DeletePro(int proID);
        IEnumerable<ProductObject> SearchProByIdAndName(int proID, String proName);
        IEnumerable<ProductObject> SearchProByUPriceAndUStock(int price, String stock);
    }
}

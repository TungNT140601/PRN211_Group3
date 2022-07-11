using System.Data;
using BussinessObject.Models;
using Microsoft.Data.SqlClient;


namespace DataAccess
{
    public class ProductDAO : FStoreContext
    {
        private static ProductDAO instance = null;
        private static readonly object instanceLock = new object();
        private ProductDAO() { }
        public static ProductDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ProductDAO();
                    }
                    return instance;
                }
            }
        }

        // Get List Product
        public List<Product> GetProductList()
        {
            List<Product> listProducts;
            try
            {
                FStoreContext DbContext = new FStoreContext();
                listProducts = DbContext.Products.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return listProducts;
        }


        // Get IdByList
        public Product GetProductByID(int proID)
        {
            Product? product;
            try
            {
                FStoreContext DbContext = new FStoreContext();
                product = DbContext.Products
                          .Where(a => a.ProductId == proID)
                          .FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return product;
        }

        // Get ProductStock
        public List<Product> GetProductByStock(int stock1, int stock2)
        {
            List<Product> listProducts = new List<Product>();
            if (stock1 > stock2)
            {
                var stock = stock1;
                stock1 = stock2;
                stock2 = stock;
            }
            try
            {
                FStoreContext DbContext = new FStoreContext();
                listProducts = DbContext.Products
                               .Where(a => a.UnitInStock <= stock2 && a.UnitInStock >= stock1)
                               .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listProducts;

        }

        // GetNameByList
        public List<Product> GetProductByName(string name)
        {
            List<Product> listProducts = new List<Product>();
            try
            {
                FStoreContext DbContext = new FStoreContext();
                listProducts = DbContext.Products
                          .Where(a => a.ProductName == name)
                          .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return listProducts;
        }

        //GetPriceByList
        public List<Product> GetProductByPrice(decimal price1, decimal price2)
        {
            List<Product> listProducts = new List<Product>();
            if (price1 > price2)
            {
                var price = price1;
                price1 = price2;
                price2 = price;
            }
            try
            {
                FStoreContext DbContext = new FStoreContext();
                listProducts = DbContext.Products
                          .Where(a => a.UnitPrice <= price2 && a.UnitPrice >= price1)
                          .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return listProducts;
        }

        // Add Products
        public void AddNew(Product pro)
        {
            try
            {
                FStoreContext DbContext = new FStoreContext();
                DbContext.Products.Add(pro);
                DbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        //UpdateProducts
        public void Update(Product pro)
        {
            try
            {
                FStoreContext DbContext = new FStoreContext();
                DbContext.Entry<Product>(pro).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                DbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        //RemoveProducts
        public void Remove(int proID)
        {
            try
            {
                FStoreContext DbContext = new FStoreContext();
                Product? product = DbContext.Products.SingleOrDefault(product => product.ProductId == proID);
                DbContext.Products.Remove(product);
                DbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}


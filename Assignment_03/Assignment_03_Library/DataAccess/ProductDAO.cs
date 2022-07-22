using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_03_Library.DataAccess
{
    public class ProductDAO
    {
        private static ProductDAO instance = null;
        private static readonly object instanceLock = new object();
        public static ProductDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ProductDAO();
                }
                return instance;
            }
        }
        public IEnumerable<Product> GetProducts()
        {
            using var context = new FStoreContext();
            return context.Products.ToList();
        }
        public Product GetProductById(int id)
        {
            Product product = null;
            try
            {
                using var context = new FStoreContext();
                product = context.Products.Where(p => p.ProductId == id).SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return product;
        }
        public void Add(Product product)
        {
            try
            {
                using var context = new FStoreContext();
                Product pro = GetProductById(product.ProductId);
                if (pro == null)
                {
                    context.Products.Add(product);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("This Product is already exist");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Update(Product pro)
        {
            try
            {
                Product product = GetProductById(pro.ProductId);
                if (product != null)
                {
                    using var context = new FStoreContext();
                    context.Products.Update(pro);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("This Product does not exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Delete(int id)
        {
            try
            {
                Product product = GetProductById(id);
                if (product != null)
                {
                    using var context = new FStoreContext();
                    context.Products.Remove(product);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("This Product does not exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Product> GetProductsByName(string name)
        {
            List<Product> listProducts = new List<Product>();
            try
            {
                using var context = new FStoreContext();
                context.Products.Where(p => p.ProductName.Contains(name)).ToList();
            }
            catch (Exception)
            {
                throw new Exception("Get list by name fail");
            }
            return listProducts;
        }
        public List<Product> GetProductsByUnitPrice(decimal unitPrice)
        {
            List<Product> listProducts = new List<Product>();
            try
            {
                using var context = new FStoreContext();
                context.Products.Where(p => p.UnitPrice.Equals(unitPrice)).ToList();
            }
            catch (Exception)
            {
                throw new Exception("Get list by Unit Price fail");
            }
            return listProducts;
        }
    }
}

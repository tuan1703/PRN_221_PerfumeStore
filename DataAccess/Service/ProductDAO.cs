using BusinessObject.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Service
{
    public class ProductDAO
    {
        private static ProductDAO instance = null;
        private static readonly object instanceLock = new object();
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

        public IEnumerable<Product> GetAllProducts()
        {

            var products = new List<Product>();
            try
            {
                using var context = new PerfumesStoreContext();
                products = context.Products.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return products;

        }

        public Product GetProductID(int proId)
        {
            Product product = null;
            try
            {
                using var context = new PerfumesStoreContext();
                product = context.Products.SingleOrDefault(p => p.ProductId == proId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return product;
        }

        public IEnumerable<Product> GetTop5Products()
        {
            var top5Products = new List<Product>();
            try
            {
                using (var context = new PerfumesStoreContext())
                {
                    top5Products = context.Products.OrderByDescending(p => p.ProductId).Take(10).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return top5Products;
        }

        public IEnumerable<Product> GetProductsByCategory(string category)
        {
            var productsByCategory = new List<Product>();
            try
            {
                using var context = new PerfumesStoreContext();
                productsByCategory = context.Products.Where(p => p.Name.Equals(category)).ToList();


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return productsByCategory;
        }

        public void AddNew(Product product)
        {
            using var context = new PerfumesStoreContext();
            if(product == null)
            {
                context.Products.Add(product);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Product ID does exits!");
            }
           
        }

        public void Update(Product product)
        {
            if (product.ProductId == null)
            {
                throw new Exception("Product ID cannot be null!");
            }

            // Check if the product exists by its ID
            var existingProduct = GetProductID(product.ProductId);
            if (existingProduct == null)
            {
                throw new Exception("Product does not exist!");
            }

            using var context = new PerfumesStoreContext();
            context.Products.Update(product);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            Product? product = GetProductID(id);
            if (product == null)
            {
                throw new Exception($"Product {id} not found");
            }
            using var context = new PerfumesStoreContext();
            context.Products.Remove(product);
            context.SaveChanges();
        }
    }
}

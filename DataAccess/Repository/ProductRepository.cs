using BusinessObject.Object;
using DataAccess.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ProductRepository
    {
        public IEnumerable<Product> GetProductByCategory(string category) => ProductDAO.Instance.GetProductsByCategory(category);

        public Product GetProductByID(int proId) => ProductDAO.Instance.GetProductID(proId);

        public IEnumerable<Product> GetProducts() => ProductDAO.Instance.GetAllProducts();

        public IEnumerable<Product> GetTop5Products() => ProductDAO.Instance.GetTop5Products();

        public void Insert(Product product) => ProductDAO.Instance.AddNew(product);

        public void Remove(int id) => ProductDAO.Instance.Delete(id);


        public void Update(Product product) => ProductDAO.Instance.Update(product);
    }
}

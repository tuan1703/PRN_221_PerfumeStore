using BusinessObject.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        IEnumerable<Product> GetProductByCategory(string category);

        IEnumerable<Product> GetTop5Products();

        Product GetProductByID(int proId);
        void Insert(Product product);
        void Update(Product product);
        void Remove(int id);
    }
}

using BusinessObject.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAll();
        void CreateOrder(Order order);
        Order getOrderByID(int id);

        IEnumerable<Order> GetByUserId(int id);
        void Update(Order order);
        void Remove(int id);
    }
}

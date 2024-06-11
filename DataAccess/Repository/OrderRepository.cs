using BusinessObject.Object;
using DataAccess.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public void CreateOrder(Order order) => OrderDAO.Instance.CreateOrder(order);

        public IEnumerable<Order> GetAll() => OrderDAO.Instance.GetAllOrder();

        public Order getOrderByID(int id) => OrderDAO.Instance.GetOrderById(id);


        public IEnumerable<Order> GetByUserId(int id) => OrderDAO.Instance.GetByUserId(id);


        public void Remove(int id) => OrderDAO.Instance.Remove(id);

        public void Update(Order order) => OrderDAO.Instance.Update(order);
    }
}

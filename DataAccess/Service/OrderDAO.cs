using BusinessObject.Object;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Service
{
    public class OrderDAO
    {
        private static OrderDAO instance = null;
        private static readonly object instanceLock = new object();
        public static OrderDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDAO();
                    }
                    return instance;
                }
            }
        }

        public void CreateOrder(Order order)
        {
            using var context = new PerfumesStoreContext();
            context.Orders.Add(order);
            context.SaveChanges();
        }

        public IEnumerable<Order> GetAllOrder()
        {
            using var context = new PerfumesStoreContext();
            List<Order> list = context.Orders
                .ToList();
            return list;
        }

        public Order GetOrderById(int id)
        {
            Order order = null;
            try
            {
                using var context = new PerfumesStoreContext();
                order = context.Orders.SingleOrDefault(o => o.OrderId == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return order;
        }

        public IEnumerable<Order> GetByUserId(int id)
        {
            using var context = new PerfumesStoreContext();
            return context.Orders
                .Include(i => i.UserId)
                .Where(o => o.UserId == id)
                .ToList();
        }

        public void Remove(int id)
        {
            Order? order = GetOrderById(id);
            if (order == null)
                throw new Exception("Order does not exist");
            using var context = new PerfumesStoreContext();
            context.Orders.Remove(order);
            context.SaveChanges();
        }

        public void Update(Order order)
        {
            if (GetOrderById(order.OrderId) == null)
                throw new Exception("Order does not exist");
            using var context = new PerfumesStoreContext();
            context.Orders.Update(order);
            context.SaveChanges();
        }
    }
}

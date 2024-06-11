using BusinessObject.Object;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Service
{
    public class OrderDetailDAO
    {
        private static OrderDetailDAO instance = null;
        private static readonly object instanceLock = new object();
        public static OrderDetailDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDetailDAO();
                    }
                    return instance;
                }
            }
        }

        public void AddNew(OrderDetail orderDetail)
        {
            using var context = new PerfumesStoreContext();
            context.OrderDetails.Add(orderDetail);
            context.SaveChanges();
        }

        public List<OrderDetail> GetOrderDetailsByOrderId(int orderId)
        {
            using var context = new PerfumesStoreContext();
            var orderDetail = context.OrderDetails
                                        .Include(o => o.Product) // Include the Product information
                                        .Where(o => o.OrderId == orderId)
                                        .ToList();
            return orderDetail;
        }
    }
}

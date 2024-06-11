using BusinessObject.Object;
using DataAccess.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        public void AddOrderDetail(OrderDetail orderDetail) => OrderDetailDAO.Instance.AddNew(orderDetail);

        public List<OrderDetail> GetOrderDetailsByOrderId(int orderId) => OrderDetailDAO.Instance.GetOrderDetailsByOrderId(orderId);
    }
}

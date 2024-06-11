using BusinessObject.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IOrderDetailRepository
    {
        void AddOrderDetail(OrderDetail orderDetail);
        List<OrderDetail> GetOrderDetailsByOrderId(int orderId);
    }
}

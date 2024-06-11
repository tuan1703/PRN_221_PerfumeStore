using BusinessObject.Object;
using DataAccess.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class CartRepository : ICartRepository
    {
        public void AddToCart(Cart cartItem) => CartDAO.Instance.AddToCart(cartItem);
    }
}

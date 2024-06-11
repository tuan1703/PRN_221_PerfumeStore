using BusinessObject.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Service
{
    public class CartDAO
    {
        private static CartDAO instance = null;
        private static readonly object instanceLock = new object();
        public static CartDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CartDAO();
                    }
                    return instance;
                }
            }
        }

        public void AddToCart(Cart cartItem)
        {
            using var context = new PerfumesStoreContext();
            context.Carts.Add(cartItem);
            context.SaveChanges();

        }
    }
}

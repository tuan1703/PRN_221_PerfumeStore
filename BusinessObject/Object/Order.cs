using System;
using System.Collections.Generic;

namespace BusinessObject.Object;

public partial class Order
{
    public int OrderId { get; set; }

    public int? UserId { get; set; }

    public decimal TotalAmount { get; set; }

    public string OrderStatus { get; set; } = null!;

    public DateOnly? CreatedAt { get; set; }

    public decimal TotalPrice { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual User? User { get; set; }
}

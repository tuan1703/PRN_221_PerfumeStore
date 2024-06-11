using System;
using System.Collections.Generic;

namespace BusinessObject.Object;

public partial class Cart
{
    public int CartId { get; set; }

    public int UserId { get; set; }

    public string ProductName { get; set; } = null!;

    public decimal Price { get; set; }

    public int Quantity { get; set; }
}

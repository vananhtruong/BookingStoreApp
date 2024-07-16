using System;
using System.Collections.Generic;

namespace BusnessObject;

public partial class OrderBookDetail
{
    public int OrderBookId { get; set; }

    public int BookId { get; set; }

    public int? Quantity { get; set; }

    public decimal? TotalPrice { get; set; }

    public virtual Book Book { get; set; } = null!;

    public virtual OrderBook OrderBook { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace BusnessObject;

public partial class OrderBook
{
    public int OrderBookId { get; set; }

    public DateOnly? OrderDate { get; set; }

    public decimal? TotalPrice { get; set; }

    public bool? OrderStatus { get; set; }

    public int MemberId { get; set; }

    public virtual BookManagementMember Member { get; set; } = null!;

    public virtual ICollection<OrderBookDetail> OrderBookDetails { get; set; } = new List<OrderBookDetail>();
}

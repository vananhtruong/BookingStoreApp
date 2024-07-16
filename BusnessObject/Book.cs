using System;
using System.Collections.Generic;

namespace BusnessObject;

public partial class Book
{
    public int BookId { get; set; }

    public string BookName { get; set; } = null!;

    public string? Description { get; set; }

    public DateOnly? ReleaseDate { get; set; }

    public int? Quantity { get; set; }

    public decimal? Price { get; set; }

    public int BookCategoryId { get; set; }

    public string? Author { get; set; }

    public string? BookImg { get; set; }

    public virtual BookCategory BookCategory { get; set; } = null!;

    public virtual ICollection<OrderBookDetail> OrderBookDetails { get; set; } = new List<OrderBookDetail>();
}

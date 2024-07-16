using System;
using System.Collections.Generic;

namespace BusnessObject;

public partial class BookCategory
{
    public int BookCategoryId { get; set; }

    public string BookCategoryName { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}

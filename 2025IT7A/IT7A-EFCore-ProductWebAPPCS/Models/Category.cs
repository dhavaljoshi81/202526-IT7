using System;
using System.Collections.Generic;

namespace IT7A_EFCore_ProductWebAPPCS.Models;

public partial class Category
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}

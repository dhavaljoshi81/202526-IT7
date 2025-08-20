using System;
using System.Collections.Generic;

namespace IT7A_EFCore_ProductWebAPPCS.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public int Rate { get; set; }

    public int CategoryId { get; set; }

    public virtual Category Category { get; set; } = null!;
}

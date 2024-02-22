using System;
using System.Collections.Generic;

namespace BO
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public string Weight { get; set; } = null!;

        public virtual OrderDetail? OrderDetail { get; set; }
    }
}

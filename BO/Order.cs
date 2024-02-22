using System;
using System.Collections.Generic;

namespace BO
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int OrderId { get; set; }
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal? Total { get; set; }

        public virtual Member IdNavigation { get; set; } = null!;
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}

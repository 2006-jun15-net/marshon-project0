using System;
using System.Collections.Generic;

namespace MarshonStore.DataAccess.Model
{
    public partial class Orders
    {
        public Orders()
        {
            OrderHistory = new HashSet<OrderHistory>();
        }

        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public DateTime? OrderDate { get; set; }
        public decimal Cost { get; set; }
        public int? StoreId { get; set; }
        public string OrderInfo { get; set; }

        public virtual Customers Customer { get; set; }
        public virtual Stores Store { get; set; }
        public virtual ICollection<OrderHistory> OrderHistory { get; set; }
    }
}

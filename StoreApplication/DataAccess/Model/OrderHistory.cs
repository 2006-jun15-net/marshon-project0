using System;
using System.Collections.Generic;

namespace DataAccess.Model
{
    public partial class OrderHistory
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int? Amount { get; set; }

        public virtual Orders Order { get; set; }
        public virtual Products Product { get; set; }
    }
}

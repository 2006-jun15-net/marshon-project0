using System;
using System.Collections.Generic;
using System.Text;
using MarshonStore.Library.RepositoryInterfaces;

namespace MarshonStore.Library.Model
{
    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal Cost { get; set; }
        public int? StoreId { get; set; }
        public string OrderInfo { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace MarshonStore.Library.Model
{
    public class Store
    {
        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public string StoreLocation { get; set; }
        public List<Order> OrderHistory { get; set; } // get all order history of a store
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using MarshonStore.Library.RepositoryInterfaces;

namespace MarshonStore.Library.Model
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public List<Order> OrderHistory { get; set; } // get all order history of a customer
    }
}

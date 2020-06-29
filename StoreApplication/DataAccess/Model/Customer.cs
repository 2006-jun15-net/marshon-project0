using System;
using System.Collections.Generic;

namespace DataAccess.Model
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Orders>();
        }

        public int CustomerId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}

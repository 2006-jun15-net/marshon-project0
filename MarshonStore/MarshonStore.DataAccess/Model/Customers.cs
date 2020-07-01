using System;
using System.Collections.Generic;

namespace MarshonStore.DataAccess.Model
{
    public partial class Customers
    {
        public Customers()
        {
            Orders = new HashSet<Orders>(); //
        }

        public int CustomerId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}

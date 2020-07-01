using System;
using System.Collections.Generic;
using System.Text;
using MarshonStore.DataAccess.Model;
using MarshonStore.Library.Model;

namespace MarshonStore.DataAccess
{
    class Mapper
    {
        public static Customers ModelToEntity(Customer c)
        {
            return new Customers { Firstname = c.Firstname, Lastname = c.Lastname };
        }
        public static Products ModelToEntity(Product p)
        {
            return new Products { ProductName = p.Name, ProductPrice = p.Price };
        }
    }
}

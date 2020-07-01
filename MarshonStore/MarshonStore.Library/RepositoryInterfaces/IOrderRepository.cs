using System;
using System.Collections.Generic;
using System.Text;
using MarshonStore.Library.Model;

namespace MarshonStore.Library.RepositoryInterfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        IEnumerable<Order> GetDetailsOfOrder();
    }
}

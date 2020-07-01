using System;
using System.Collections.Generic;
using System.Text;
using MarshonStore.Library.Model;



namespace MarshonStore.Library.RepositoryInterfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        IEnumerable<Customer> GetCustomerByFirstName(string firstn);
        IEnumerable<Customer> GetCustomerByLastName(string lastn);
    }
}

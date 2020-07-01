using System;
using System.Collections.Generic;
using System.Text;
using MarshonStore.Library.RepositoryInterfaces;
using MarshonStore.Library.Model;
using System.Linq;



namespace MarshonStore.DataAccess.Repositories
{
    //Gets Context from GenericRepository sets it to the proper entity here through generics
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public IEnumerable<Customer> GetCustomerByFirstName(string firstn)
        {
            //return ToList of result
            return (IEnumerable<Customer>)dbcontext.Customer.Where(e => e.Firstname == firstn).ToList(); //added a cast
        }

        public IEnumerable<Customer> GetCustomerByLastName(string lastn)
        {
            //return ToList of result
            return (IEnumerable<Customer>)dbcontext.Customer.Where(e => e.Lastname == lastn).ToList(); //added a cast
        }



    }
}

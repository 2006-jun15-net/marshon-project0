using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace MarshonStore.Library.RepositoryInterfaces
{
    public interface IRepository<E> where E : class
    {
        void Add(E obj); // add object to repository
        void Delete(object id); //named 'remove' in other examples
        IEnumerable<E> GetAll(); // get all tables of this entity
        E GetById(object id); // get tables of this entity with matching ids 
        void Save(); // save tracked changes
    }
}

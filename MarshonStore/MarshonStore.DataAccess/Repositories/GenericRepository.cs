using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MarshonStore.DataAccess.Model;
using System.Linq;
using MarshonStore.Library.RepositoryInterfaces;
using Microsoft.Extensions.Logging;


namespace MarshonStore.DataAccess.Repositories
{
    public class GenericRepository<E> : IRepository<E> where E : class
    {
        
       public static readonly ILoggerFactory MyLoggerFactory
            = LoggerFactory.Create(builder => { builder.AddConsole(); });
        

        public static readonly DbContextOptions<StoreDatabaseContext> Options = new DbContextOptionsBuilder<StoreDatabaseContext>()
            .UseLoggerFactory(MyLoggerFactory)
            .UseSqlServer(SecretConfiguration.ConnectionString)
            .Options;

        protected StoreDatabaseContext dbcontext = null;
        protected DbSet<E> dbtable = null;

        public GenericRepository()
        {
            this.dbcontext = new StoreDatabaseContext();
            this.dbtable = dbcontext.Set<E>();
        }



        public void Add(E obj)
        {
            dbtable.Add(obj);
        }

        public void Delete(object id)
        {
            E tableToDelete = dbtable.Find(id);
            dbtable.Remove(tableToDelete);
        }

        public IEnumerable<E> GetAll()
        {
            return dbtable;
        }

        public E GetById(object id)
        {
            return dbtable.Find(id);
        }

        public void Save()
        {
            dbcontext.SaveChanges();
        }
    }
}

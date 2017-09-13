using DataAccess.Interfaces;
using Db;
using LinqKit;
using Models;
using SearchFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CustomerRepository : ICustomerRepository
    {
        public CustomerRepository(Context context)
        {
            this.Context = context;
        }

        private Context Context { get; set; }

        public IList<Customer> Read(CustomerFilters filters)
        {
            var predicate = PredicateBuilder.New<Customer>(true);
            if (filters.Ids != null && filters.Ids.Any()) predicate = predicate.And(c => filters.Ids.Contains(c.Id));
            if (!string.IsNullOrWhiteSpace(filters.Name)) predicate = predicate.And(c => c.Name.Contains(filters.Name));

            return Context.Customers.AsExpandable().Where(predicate).ToList();
        }

        public void Create(Customer entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Customer entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid Id)
        {
            throw new NotImplementedException();
        }

        public bool IsExist(Guid id) => Context.Customers.Any(c => c.Id == id);

    }
}

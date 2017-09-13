using DataAccess.Shared.Interfaces;
using Models;
using SearchFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        IList<Customer> Read(CustomerFilters filters);
    }
}

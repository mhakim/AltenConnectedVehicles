using Application.Interfaces;
using DataAccess.Interfaces;
using DataAccess.Shared;
using DataAccess.Shared.Interfaces;
using Models;
using Resources;
using SearchFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class CustomerService : ICustomerService
    {
        private IValidator<CustomerResource> Validator { get; set; }

        private ICustomerRepository Repository { get; set; }

        private IUnitOfWork UnitOfWork { get; set; }

        public CustomerService(
            IValidator<CustomerResource> validator, 
            ICustomerRepository repository,
            IUnitOfWork unitOfWork)
        {
            Validator = validator;
            Repository = repository;
            UnitOfWork = unitOfWork;
        }

        public void Create(CustomerResource customer)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IList<CustomerResource> Read(CustomerFilters filters)
        {
            filters = filters ?? new CustomerFilters();
            var vehicles = Repository.Read(filters);
            return Map(vehicles);
        }

        public void Update(CustomerResource vehicle)
        {
            throw new NotImplementedException();
        }

        private List<CustomerResource> Map(IList<Customer> customers)
        {
            var resources = new List<CustomerResource>();

            foreach (var c in customers) resources.Add(new CustomerResource(c.Id, c.Name, c.Address));

            return resources;
        }

    }
}

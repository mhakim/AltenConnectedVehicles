using Resources;
using SearchFilters;
using System;
using System.Collections.Generic;

namespace Application.Interfaces
{
    /// <summary>
    /// ICustomerService operations
    /// </summary>
    public interface ICustomerService
    {
        /// <summary>
        /// select filtered customers data
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        IList<CustomerResource> Read(CustomerFilters filters);

        /// <summary>
        /// update existing customer
        /// </summary>
        /// <param name="vehicle"></param>
        void Update(CustomerResource vehicle);

        /// <summary>
        /// create new customer resource
        /// </summary>
        /// <param name="customer"></param>
        void Create(CustomerResource customer);

        /// <summary>
        /// delete customer
        /// </summary>
        /// <param name="id"></param>
        void Delete(Guid id);
    }
}
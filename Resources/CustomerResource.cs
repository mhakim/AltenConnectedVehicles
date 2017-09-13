using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resources
{
    /// <summary>
    /// Customer Resource
    /// </summary>
    public class CustomerResource : IResource
    {
        public CustomerResource()
        {

        }

        public CustomerResource(Guid id, string name, string address)
        {
            Id = id;
            Name = name;
            Address = address;
        }

        /// <summary>
        /// customer id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// customer name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// customer address
        /// </summary>
        public string Address { get; set; }
    }
}

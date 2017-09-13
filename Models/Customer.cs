using System.Collections.Generic;

namespace Models
{
    public class Customer : BaseEntity
    {
        /// <summary>
        /// customer name
        /// </summary>
        public string Name { get; set; }

        public string Address { get; set; }

        public IList<Vehicle> Vehicles { get; set; }
    }
}
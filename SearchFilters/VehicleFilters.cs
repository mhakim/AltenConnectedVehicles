using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchFilters
{
    /// <summary>
    /// search criteria for reading vehicles
    /// </summary>
    public class VehicleFilters
    {
        public VehicleFilters()
        {

        }

        public VehicleFilters(Guid? vehicleId = null, Guid? customerId = null, bool? isAlive = null)
        {
            VehicleId = vehicleId;
            CustomerId = customerId;
            IsAlive = isAlive;
        }

        /// <summary>
        /// Vehicle Id filter
        /// null means select all Vehicles
        /// </summary>
        public Guid? VehicleId { get; set; }

        /// <summary>
        /// CustomerId filter
        /// null means select vehicles for all customers
        /// </summary>
        public Guid? CustomerId { get; set; }

        /// <summary>
        /// IsAlive filter
        /// true means select vehicles with healty connection
        /// false means select vehicles with lost connection
        /// null means select all vehicles regardless of it's status 
        /// </summary>
        public bool? IsAlive { get; set; }
    }
}

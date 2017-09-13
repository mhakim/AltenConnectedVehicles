using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resources
{
    /// <summary>
    /// Vehicle Resource representation
    /// </summary>
    public class VehicleResource : IResource
    {
        public VehicleResource()
        {

        }

        public VehicleResource(Guid id, string vin, string registrationNumber, string ownerName, bool isAlive)
        {
            Id = id;
            VIN = vin;
            RegistrationNumber = registrationNumber;
            OwnerName = ownerName;
            IsAlive = isAlive;
        }

        /// <summary>
        /// Vehicle Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// vehicle vin also called a chassis number, is a unique code, including a serial number, used by the automotive industry to identify individual motor vehicles 
        /// </summary>
        public string VIN { get; set; }

        /// <summary>
        /// Registration Number is the license plate 
        /// it is established by the government.
        /// </summary>
        public string RegistrationNumber { get; set; }

        /// <summary>
        /// vehicle owner
        /// </summary>
        public string OwnerName { get; set; }

        /// <summary>
        /// indicates wether the connection between the vehicle and the server is healthy or not
        /// </summary>
        public bool IsAlive { get; set; }
    }
}

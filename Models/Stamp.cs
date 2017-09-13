using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// stamp model
    /// </summary>
    public class Stamp
    {
        /// <summary>
        /// stamp id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// stamp vehicle id
        /// </summary>
        public Guid VehicleId { get; set; }

        /// <summary>
        /// stamp vehicle
        /// </summary>
        public Vehicle Vehicle { get; set; }

        /// <summary>
        /// Stamp Time
        /// </summary>
        public DateTimeOffset StampTime { get; set; }        
    }
}

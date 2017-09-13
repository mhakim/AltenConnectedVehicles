using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// Vehicle model
    /// </summary>
    public class Vehicle : BaseEntity
    {
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
        /// vehicle owner id
        /// </summary>
        public Guid OwnerId { get; set; }

        /// <summary>
        /// vehicle owner
        /// </summary>
        public Customer Owner { get; set; }

        /// <summary>
        /// Last Stamp Time
        /// this field will enhance app performance as we dont have to get all stamps to know the last one
        /// 99 percent of times we need stamps that will be to know the last stamp time so cahcing it here will have a great effect on app performance
        /// </summary>
        public DateTimeOffset? LastStampTime { get; set; }

        /// <summary>
        /// vehicle is considered alive if we recived a ping request from it in less than 60 sec
        /// </summary>
        public bool IsAlive
        {
            get
            {
                if (LastStampTime == null) return false;
                return LastStampTime >= DateTimeOffset.Now.AddMinutes(-1);
            }
        }


    }
}

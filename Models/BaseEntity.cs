using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// Base Entity
    /// </summary>
    public class BaseEntity
    {
        /// <summary>
        /// entity Id 
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// entity creation date
        /// </summary>
        public DateTimeOffset CreatedAt { get; set; }

        /// <summary>
        /// entity update date
        /// </summary>
        public DateTimeOffset UpdatedAt { get; set; }
    }
}

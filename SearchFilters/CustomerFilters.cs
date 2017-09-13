using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchFilters
{
    /// <summary>
    /// search criteria for reading customers
    /// </summary>
    public class CustomerFilters
    {
        /// <summary>
        /// customers ids filters 
        /// note that you can select many customers at once
        /// empty list means select all
        /// </summary>
        public List<Guid> Ids { get; set; }

        /// <summary>
        /// select all customer their names contains the name filter
        /// </summary>
        public string Name { get; set; }
    }
}

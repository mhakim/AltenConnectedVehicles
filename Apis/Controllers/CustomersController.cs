using Application.Interfaces;
using Resources;
using SearchFilters;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Apis.Controllers
{
    /// <summary>
    /// Customers resource Controller
    /// </summary>
    public class CustomersController : ApiController
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="service"></param>
        public CustomersController(ICustomerService service)
        {
            Service = service;
        }

        public ICustomerService Service { get; private set; }

        /// <summary>
        /// get a filtered list of VehicleResource 
        /// </summary>
        /// <param name="filters"></param>
        [SwaggerResponse(HttpStatusCode.OK, "OK", typeof(IList<CustomerResource>))]
        public IList<CustomerResource> Get([FromUri]CustomerFilters filters)
        {
            return Service.Read(filters);
        }

    }
}

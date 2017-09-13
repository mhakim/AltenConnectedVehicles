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
    /// Vehicles resource Controller
    /// </summary>
    public class VehiclesController : ApiController
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="service"></param>
        public VehiclesController(IVehicleService service)
        {
            Service = service;
        }

        public IVehicleService Service { get; private set; }

        /// <summary>
        /// get a filtered list of VehicleResource 
        /// </summary>
        /// <param name="filters"></param>
        [SwaggerResponse(HttpStatusCode.OK, "OK", typeof(IList<VehicleResource>))]
        public IList<VehicleResource> Get([FromUri]VehicleFilters filters)
        {
            return Service.Read(filters ?? new VehicleFilters());
        }

    }
}

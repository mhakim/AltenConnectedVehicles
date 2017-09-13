using Application.Interfaces;
using Resources;
using SearchFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Apis.Controllers
{
    /// <summary>
    /// Stamps resource Controller
    /// </summary>
    public class StampsController : ApiController
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="service"></param>
        public StampsController(IVehicleService service)
        {
            Service = service;
        }

        public IVehicleService Service { get; private set; }

        /// <summary>
        /// Add vehicle stamp AKA ping, network request, checkin
        /// this stamp used to determine the connection ststus for vehicles
        /// </summary>
        /// <param name="vehicleId">
        /// vehicle Id (required)
        /// </param>
        public void Post([FromBody]Guid vehicleId)
        {
            Service.AddStamp(vehicleId);
        }

    }
}

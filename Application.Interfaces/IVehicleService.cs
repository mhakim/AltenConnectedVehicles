using Resources;
using SearchFilters;
using System;
using System.Collections.Generic;

namespace Application.Interfaces
{
    /// <summary>
    /// IVehicleService operations
    /// </summary>
    public interface IVehicleService
    {
        /// <summary>
        /// select filtered vehicles
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        IList<VehicleResource> Read(VehicleFilters filters);

        /// <summary>
        /// create new vehicle resource
        /// </summary>
        /// <param name="vehicle"></param>
        void Create(VehicleResource vehicle);

        /// <summary>
        /// update existing vehicle resource
        /// </summary>
        /// <param name="vehicle"></param>
        void Update(VehicleResource vehicle);

        /// <summary>
        /// delete vehicle
        /// </summary>
        /// <param name="id"></param>
        void Delete(Guid id);

        /// <summary>
        /// add new vehicle stamp indicating healthy network connection
        /// </summary>
        /// <param name="id"></param>
        void AddStamp(Guid id);
    }
}
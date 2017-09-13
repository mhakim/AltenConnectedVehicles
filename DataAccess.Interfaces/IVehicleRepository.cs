using DataAccess.Shared.Interfaces;
using Models;
using SearchFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IVehicleRepository : IRepository<Vehicle>
    {
        IList<Vehicle> Read(VehicleFilters filters, DateTimeOffset? stampAfter );

        void AddStamp(Stamp stamp);

        void UpdateLastStamp(Guid vehicleId, DateTimeOffset stampTime);
    }
}

using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using SearchFilters;
using Db;
using LinqKit;

namespace DataAccess
{
    public class VehicleRepository : IVehicleRepository
    {
        public VehicleRepository(Context context)
        {
            this.Context = context;
        }

        private Context Context { get; set; }

        public IList<Vehicle> Read(VehicleFilters filters, DateTimeOffset? lastStamp)
        {
            var predicate = PredicateBuilder.New<Vehicle>(true);
            if (filters.VehicleId != null) predicate = predicate.And(v => v.Id == filters.VehicleId);
            if (filters.CustomerId != null) predicate = predicate.And(v => v.OwnerId == filters.CustomerId);
            if (filters.IsAlive.HasValue && filters.IsAlive.Value) predicate = predicate.And(v => v.LastStampTime >= lastStamp);
            // not alive means last stamp null or old
            if (filters.IsAlive.HasValue && !filters.IsAlive.Value) predicate = predicate.And(v => v.LastStampTime == null || v.LastStampTime < lastStamp);

            return Context.Vehicles.Include("Owner").AsExpandable().Where(predicate).ToList();
        }

        public void Update(Vehicle entity)
        {
            throw new NotImplementedException();
        }

        public void Create(Vehicle entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid Id)
        {
            throw new NotImplementedException();
        }

        public bool IsExist(Guid id) => Context.Vehicles.Any(v => v.Id == id);

        public void AddStamp(Stamp stamp)
        {
            Context.Stamps.Add(stamp);
            Context.SaveChanges();
        }

        public void UpdateLastStamp(Guid vehicleId, DateTimeOffset stampTime)
        {
            var vehicle = Context.Vehicles.SingleOrDefault(v => v.Id == vehicleId);
            if (vehicle == null) return;

            vehicle.LastStampTime = stampTime;
        }
    }
}

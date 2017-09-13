using Application.Interfaces;
using System;
using System.Collections.Generic;
using Resources;
using SearchFilters;
using DataAccess.Interfaces;
using Models;
using System.Linq;
using DataAccess.Shared.Interfaces;

namespace Application
{
    public class VehicleService : IVehicleService
    {
        private IValidator<VehicleResource> Validator { get; set; }

        private IVehicleRepository Repository { get; set; }

        private IUnitOfWork UnitOfWork { get; set; }

        public VehicleService(IValidator<VehicleResource> validator,
            IVehicleRepository repository,
            IUnitOfWork unitOfWork)
        {
            Validator = validator;
            Repository = repository;
            UnitOfWork = unitOfWork;
        }

        public IList<VehicleResource> Read(VehicleFilters filters)
        {
            filters = filters ?? new VehicleFilters();
            DateTimeOffset? lastStamp = null;
            if (filters.IsAlive.HasValue) lastStamp = DateTimeOffset.Now.AddMinutes(-1);

            var vehicles = Repository.Read(filters, lastStamp);
            return Map(vehicles);
        }

        public void Update(VehicleResource vehicle)
        {
            throw new NotImplementedException();
        }

        public void Create(VehicleResource vehicle)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        //public bool IsAlive(Guid id)
        //{
        //    var filters = new VehicleFilters(id);
        //    var vehicles = Repository.Read(filters, null);

        //    if (vehicles == null || vehicles.Count == 0) return false;
        //    return vehicles.First().IsAlive;
        //}

        public void AddStamp(Guid id)
        {
            if (!Repository.IsExist(id)) return;

            var stamp = new Stamp()
            {
                Id = Guid.NewGuid(),
                StampTime = DateTimeOffset.Now,
                VehicleId = id
            };
            Repository.UpdateLastStamp(id, stamp.StampTime);
            Repository.AddStamp(stamp);
            UnitOfWork.Save();
        }

        private List<VehicleResource> Map(IList<Vehicle> vehicles)
        {
            var resources = new List<VehicleResource>();

            foreach (var v in vehicles) resources.Add(new VehicleResource(v.Id, v.VIN, v.RegistrationNumber, v.Owner?.Name, v.IsAlive));

            return resources;
        }

    }
}

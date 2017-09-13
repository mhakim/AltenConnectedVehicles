namespace Db.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Diagnostics;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Db.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Db.Context context)
        {
            context.Customers.AddOrUpdate(c => c.Id, GetC1(), GetC2(), GetC3());
        }

        private Customer GetC1()
        {
            var v1 = CreateVehicle(new Guid("b8297130-7760-4bd0-93c3-e4d09b0d12b9"), "YS2R4X20005399401", "ABC123");
            var v2 = CreateVehicle(new Guid("231f4fba-aed6-4717-ad5a-ac4c5bb0424a"), "VLUR4X20009093588", "DEF456");
            var v3 = CreateVehicle(new Guid("26cd9916-4757-4134-9cb6-85d8f430fa3b"), "VLUR4X20009048066", "GHI789");
            return CreateCustomer(new Guid("5d373405-c027-4456-a6ed-d507eb31313b"),
                "Kalles Grustransporter AB",
                "Cementvägen 8, 111 11 Södertälje ",
                v1, v2, v3);
        }

        private Customer GetC2()
        {
            var v4 = CreateVehicle(new Guid("a4bc2384-3061-40eb-84d4-8e37fd390945"), "YS2R4X20005388011", "JKL012");
            var v5 = CreateVehicle(new Guid("ac50ae42-2d1c-476a-8bd7-70c898189137"), "YS2R4X20005387949", "MNO345");
            return CreateCustomer(new Guid("296c3fe4-6e46-4567-8794-381d6d660977"), "Johans Bulk AB", "Balkvägen 12, 222 22 Stockholm", v4, v5);

        }

        private Customer GetC3()
        {
            var v6 = CreateVehicle(new Guid("0e22bfc2-b0fd-4cca-a618-d529b9f5f2c5"), "YS2R4X20005387765", "PQR678");
            var v7 = CreateVehicle(new Guid("4049d005-0a1c-4d33-9fd5-780710111e58"), "YS2R4X20005387055", "STU901");
            return CreateCustomer(new Guid("85a832a4-57d2-413e-b201-524e5e7513b6"), "Haralds Värdetransporter AB", "Budgetvägen 1, 333 33 Uppsala", v6, v7);
        }

        private Customer CreateCustomer(Guid id, string name, string address, params Vehicle[] vehicles)
        {
            var customer = new Customer
            {
                Id = id,
                Name = name,
                Address = address,
                CreatedAt = DateTimeOffset.Now,
                UpdatedAt = DateTimeOffset.Now
            };
            customer.Vehicles = new List<Vehicle>(vehicles);
            return customer;
        }

        private Vehicle CreateVehicle(Guid id, string VIN, string registrationNumber)
        {
            return new Vehicle()
            {
                Id = id,
                VIN = VIN,
                RegistrationNumber = registrationNumber,
                LastStampTime = null,
                CreatedAt = DateTimeOffset.UtcNow,
                UpdatedAt = DateTimeOffset.UtcNow
            };
        }


    }
}

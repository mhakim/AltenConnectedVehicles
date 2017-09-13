using Application.Interfaces;
using DataAccess.Interfaces;
using DataAccess.Shared.Interfaces;
using Models;
using NSubstitute;
using Resources;
using SearchFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Application.Tests.VehicleServiceTests
{
    public class ReadTests
    {
        public ReadTests()
        {
            UnitOfWork = Substitute.For<IUnitOfWork>();
            Repository = Substitute.For<IVehicleRepository>();
            Validator = Substitute.For<IValidator<VehicleResource>>();

            Service = new VehicleService(Validator, Repository, UnitOfWork);
        }

        private IUnitOfWork UnitOfWork { get; set; }
        private IVehicleRepository Repository { get; set; }
        private IValidator<VehicleResource> Validator { get; set; }
        private IVehicleService Service { get; set; }

        [Fact]
        public void Read_NullFilters_NoErrors()
        {
            // arrange

            // act
            Service.Read(null);

            // assert
            Repository.ReceivedWithAnyArgs().Read(null, null);
        }

        [Fact]
        public void Read_OneItem_MappedCorrectly()
        {
            // arrange
            var gId = new Guid("a7985278-d042-4ad8-b01b-b0ecf4897680");
            var vin = "vin1";
            var time = new DateTimeOffset(2017, 1, 1, 1, 1, 1, new TimeSpan(0));
            var regNo = "regno1";

            Repository.Read(null, null)
                .ReturnsForAnyArgs(
                new List<Vehicle>()
                {
                    new Vehicle() {
                        Id = gId,
                        VIN = vin,
                        LastStampTime =time ,
                        RegistrationNumber = regNo
                    }
                });

            // act
            var actualResource = Service.Read(null).SingleOrDefault();

            // assert
            Assert.True(actualResource != null);
            Assert.Equal(gId, actualResource.Id);
            Assert.Equal(vin, actualResource.VIN);
            Assert.Equal(regNo, actualResource.RegistrationNumber);
            Assert.False(actualResource.IsAlive);
        }

        [Fact]
        public void Read_OneAliveVehicle_MappedCorrectly()
        {
            // arrange
            var time = DateTimeOffset.Now;

            Repository.Read(null, null)
                .ReturnsForAnyArgs(
                new List<Vehicle>()
                {
                    new Vehicle() {
                        LastStampTime =time
                    }
                });

            // act
            var actualResource = Service.Read(null).SingleOrDefault();

            // assert
            var expectedAlive = true;
            Assert.True(actualResource != null);
            Assert.Equal(expectedAlive, actualResource.IsAlive);
        }



        [Fact]
        public void Read_notAliveVehicle_MappedCorrectly()
        {
            // arrange
            var time = DateTimeOffset.Now.AddMinutes(-2);

            Repository.Read(null, null)
                .ReturnsForAnyArgs(
                new List<Vehicle>()
                {
                    new Vehicle() {
                        LastStampTime = time
                    }
                });
            var filters = new VehicleFilters() { IsAlive = false };

            // act
            var actualResource = Service.Read(filters).SingleOrDefault();

            // assert
            var expectedAlive = false;
            Assert.True(actualResource != null);
            Assert.Equal(expectedAlive, actualResource.IsAlive);
        }
    }
}

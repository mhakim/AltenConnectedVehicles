using Application.Interfaces;
using DataAccess.Interfaces;
using DataAccess.Shared.Interfaces;
using NSubstitute;
using Resources;
using System;
using Xunit;

namespace Application.Tests.VehicleServiceTests
{
    public class AddStampTests
    {
        public AddStampTests()
        {
             UnitOfWork = Substitute.For<IUnitOfWork>();
             Repository = Substitute.For<IVehicleRepository>();
             Validator = Substitute.For<IValidator<VehicleResource>>();

            Service = new VehicleService(Validator, Repository, UnitOfWork);
        }

        private IUnitOfWork UnitOfWork { get;  set; }
        private IVehicleRepository Repository { get;  set; }
        private IValidator<VehicleResource> Validator { get;  set; }
        private IVehicleService Service { get; set; }

        [Fact]
        public void AddStamp_unexistingVehicle_NoErrors()
        {
            // arrange
            Repository.IsExist(Guid.Empty).ReturnsForAnyArgs(false);

            // act 
            Service.AddStamp(Guid.Empty);

            // assert
            UnitOfWork.DidNotReceive().Save();
        }

        [Fact]
        public void AddStamp_ValidVehicle_DataSaved()
        {
            // arrange
            Repository.IsExist(Guid.Empty).ReturnsForAnyArgs(true);

            // act 
            Service.AddStamp(Guid.Empty);

            // assert
            UnitOfWork.Received().Save();
        }

    }
}

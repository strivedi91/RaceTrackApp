using Castle.Core.Logging;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using RaceTrack.Web.Controllers;
using RaceTrack.Web.CQRS;
using RaceTrack.Web.CQRS.Commands;
using RaceTrack.Web.CQRS.DTO;
using RaceTrack.Web.CQRS.Queries;
using RaceTrack.Web.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace RaceTrack.Test
{
    public class RaceTrackTest
    {
        private Mock<IMediator> _mediator;
        private Mock<ILogger<HomeController>> _logger;

        private Mock<TrackDbContext> _db;

        public RaceTrackTest()
        {
            _mediator = new Mock<IMediator>();
            _logger = new Mock<ILogger<HomeController>>();
            _db = new Mock<TrackDbContext>();
        }


        [Fact]
        public async Task AddNewVehicleOnTrack_Failure()
        {
            AddVehicleOnTrackCommand addVehicleOnTrackCommand = new AddVehicleOnTrackCommand()
            {
                AreThereTwoStrapsOnVehicle = false,
                HaveLessThan85PerTireWear = false,
                IsNotLiftedMoreThan5Inches = false,
                Identification = "AAA",
                Type = "Truck"
            };

            var addNewVehicleHandler = new AddVehicleOnTrackCommandHandler(_db.Object);
            var result = await addNewVehicleHandler.Handle(addVehicleOnTrackCommand, new CancellationToken());

            Assert.NotNull(result);
            Assert.Equal($"Truck does not match the citeria to be on track!", result.Message);
        }

        [Fact]
        public async void HomeController_AddNewVehicleOnTrack_Success()
        {
            // Arrange
            AddVehicleOnTrackCommand addVehicleOnTrackCommand = new AddVehicleOnTrackCommand()
            {
                AreThereTwoStrapsOnVehicle = false,
                HaveLessThan85PerTireWear = false,
                IsNotLiftedMoreThan5Inches = false,
                Identification = "AAA",
                Type = "Truck"
            };

            Response<AddVehicleOnTrackCommand> response = new Response<AddVehicleOnTrackCommand>(new AddVehicleOnTrackCommand
            {
                AreThereTwoStrapsOnVehicle = false,
                HaveLessThan85PerTireWear = false,
                Identification = "AAA",
                IsNotLiftedMoreThan5Inches = false,
                Type = "Truck"
            }, "", $"Truck does not match the citeria to be on track!");

            _mediator.Setup(x => x.Send(It.IsAny<AddNewVehicleOnTrack>(), new CancellationToken())).
                ReturnsAsync(response);

            var homeController = new HomeController(_logger.Object, _mediator.Object);

            //Action
            var result = await homeController.AddVehicleOnTrack(addVehicleOnTrackCommand);

            //Assert

            Assert.IsType<OkObjectResult>(result);
        }
    }
}

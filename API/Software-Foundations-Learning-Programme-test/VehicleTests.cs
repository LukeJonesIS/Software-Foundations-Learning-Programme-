using Moq;
using Software_Foundations_Learning_Programme_.Controllers;
using Software_Foundations_Learning_Programme_.Models;
using Software_Foundations_Learning_Programme_.Services;
using Microsoft.AspNetCore.Mvc;
using Software_Foundations_Learning_Programme_.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Software_Foundations_Learning_Programme_.Tests
{
    public class VehiclesControllerTests
    {
        private readonly Mock<IEvGrantRepository> _mockEvGrantRepository;
        private readonly VehiclesController _controller;

        public VehiclesControllerTests()
        {
            _mockEvGrantRepository = new Mock<IEvGrantRepository>();
            _controller = new VehiclesController(_mockEvGrantRepository.Object);
        }

        [Fact]
        public async Task GetVehicles_ReturnsOkResult_WhenVehicleExists()
        {
            var vrn = "CAS300";
            var expectedVehicle  = new Vehicle
            {
                Vrn = vrn,
                Make = "Volkswagen",
                Model = "Fox",
                Fuel_type = "petrol"
            };

            _mockEvGrantRepository.Setup(repo => repo.GetVehicle(vrn))
                .ReturnsAsync(expectedVehicle);

            var result = await _controller.GetVehicles(vrn);

            var actionResult = Assert.IsType<ActionResult<VehicleDto>>(result);
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var returnValue = Assert.IsType<Vehicle>(okResult.Value);

            Assert.Equal(vrn, returnValue.Vrn);
            Assert.Equal("Volkswagen", returnValue.Make);
            Assert.Equal("Fox", returnValue.Model);
            Assert.Equal("petrol", returnValue.Fuel_type);
        }

        [Fact]
        public async Task GetVehicles_ReturnsNotFoundResult_WhenVehicleDoesNotExist()
        {
            var vrn = "INVALID123";
            
            _mockEvGrantRepository.Setup(repo => repo.GetVehicle(vrn))
                .ReturnsAsync((Vehicle)null);
            var result = await _controller.GetVehicles(vrn);

            var actionResult = Assert.IsType<ActionResult<VehicleDto>>(result);
            Assert.IsType<NotFoundResult>(actionResult.Result);
        }
    }
}

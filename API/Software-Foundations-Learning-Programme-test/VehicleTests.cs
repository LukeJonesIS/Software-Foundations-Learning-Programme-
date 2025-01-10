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

        // Test for GetVehicles - when a valid VRN is provided and the vehicle is found
        [Fact]
        public async Task GetVehicles_ReturnsOkResult_WhenVehicleExists()
        {
            // Arrange
            var vrn = "CAS300";
            var expectedVehicle  = new Vehicle
            {
                Vrn = vrn,
                Make = "Volkswagen",
                Model = "Fox",
                Fuel_type = "petrol"
            };

            // Mocking GetVehicle to return a specific VehicleDto when called with a VRN
            _mockEvGrantRepository.Setup(repo => repo.GetVehicle(vrn))
                .ReturnsAsync(expectedVehicle);

            // Act
            var result = await _controller.GetVehicles(vrn);

            // Assert
            var actionResult = Assert.IsType<ActionResult<VehicleDto>>(result);
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var returnValue = Assert.IsType<Vehicle>(okResult.Value);

            // Check that the returned VehicleDto has correct values
            Assert.Equal(vrn, returnValue.Vrn);
            Assert.Equal("Volkswagen", returnValue.Make);
            Assert.Equal("Fox", returnValue.Model);
            Assert.Equal("petrol", returnValue.Fuel_type);
        }

        // Test for GetVehicles - when an invalid VRN is provided and the vehicle is not found
        [Fact]
        public async Task GetVehicles_ReturnsNotFoundResult_WhenVehicleDoesNotExist()
        {
            // Arrange
            var vrn = "INVALID123";
            
            // Mocking GetVehicle to return null when called with an invalid VRN
            _mockEvGrantRepository.Setup(repo => repo.GetVehicle(vrn))
                .ReturnsAsync((Vehicle)null);

            // Act
            var result = await _controller.GetVehicles(vrn);

            // Assert
            var actionResult = Assert.IsType<ActionResult<VehicleDto>>(result);
            Assert.IsType<NotFoundResult>(actionResult.Result);
        }
    }
}

using Moq;
using Software_Foundations_Learning_Programme_.Controllers;
using Software_Foundations_Learning_Programme_.Models;
using Software_Foundations_Learning_Programme_.Services;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using Software_Foundations_Learning_Programme_.Entities;

namespace Software_Foundations_Learning_Programme_.Tests
{
    public class ApplicationsControllerTests
    {
        private readonly Mock<IEvGrantRepository> _mockEvGrantRepository;
        private readonly ApplicationsController _controller;

        public ApplicationsControllerTests()
        {
            _mockEvGrantRepository = new Mock<IEvGrantRepository>();
            _controller = new ApplicationsController(_mockEvGrantRepository.Object);
        }

        [Fact]
        public async Task CreateApplication_ReturnsCreatedAtAction_WhenApplicationIsCreated()
        {
            // Arrange
            var applicationDto = new ApplicationCreationDto
            {
                Name = "John Doe",
                Email = "john.doe@example.com",
                Address = "123 Fake Street, Fake Town, FT1 2AB",
                Vrn = "ABC1234"
            };

            var applicationToReturn = new Application
            {
                Id = 0, // Simulating the ID after creation
                Name = applicationDto.Name,
                Email = applicationDto.Email,
                Address = applicationDto.Address,
                Vrn = applicationDto.Vrn
            };

            // Mocking AddApplication and SaveChangesAsync
            _mockEvGrantRepository.Setup(repo => repo.AddApplication(It.IsAny<Application>())).Verifiable();
            _mockEvGrantRepository.Setup(repo => repo.SaveChangesAsync())
                .ReturnsAsync(true);  

            // Act
            var result = await _controller.CreateApplication(applicationDto);

            // Assert
            var actionResult = Assert.IsType<ActionResult<Application>>(result);
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(actionResult.Result);

            // Validate that the response contains the correct URL and application data
            Assert.Equal(nameof(ApplicationsController.CreateApplication), createdAtActionResult.ActionName);
            Assert.Equal(0, createdAtActionResult.RouteValues["id"]);
            var returnValue = Assert.IsType<Application>(createdAtActionResult.Value);
            Assert.Equal(applicationDto.Name, returnValue.Name);
            Assert.Equal(applicationDto.Email, returnValue.Email);
            Assert.Equal(applicationDto.Address, returnValue.Address);
            Assert.Equal(applicationDto.Vrn, returnValue.Vrn);

            // Verify that AddApplication and SaveChangesAsync were called
            _mockEvGrantRepository.Verify(repo => repo.AddApplication(It.IsAny<Application>()), Times.Once);
            _mockEvGrantRepository.Verify(repo => repo.SaveChangesAsync(), Times.Once);
        }
    }
}

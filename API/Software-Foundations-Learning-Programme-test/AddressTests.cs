using Moq;
using Software_Foundations_Learning_Programme_.Controllers;
using Software_Foundations_Learning_Programme_.Models;
using Software_Foundations_Learning_Programme_.Services;
using Microsoft.AspNetCore.Mvc;
using Software_Foundations_Learning_Programme_.Entities;

namespace Software_Foundations_Learning_Programme_.Tests
{
    public class AddressesControllerTests
    {
        private readonly Mock<IEvGrantRepository> _mockEvGrantRepository;
        private readonly AddressesController _controller;

        public AddressesControllerTests()
        {
            _mockEvGrantRepository = new Mock<IEvGrantRepository>();
            _controller = new AddressesController(_mockEvGrantRepository.Object);
        }

        [Fact]
        public async Task GetAddresses_ReturnsOkResult_WhenAddressExists()
        {
            var postcode = "FA12_6KE";
            var expectedAddress = new List<Address>
            {
                new Address
                {
                    Postcode = postcode,
                    Address_line1 = "2 Dummy Lane",
                    Address_line2 = "Fake Town",
                    City = "London"
                }
            };
            _mockEvGrantRepository.Setup(repo => repo.GetAddresses(postcode))
                .ReturnsAsync(expectedAddress);



            var result = await _controller.GetAddresses(postcode);

            var actionResult = Assert.IsType<ActionResult<AddressDto>>(result);
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var returnValue = Assert.IsType<List<Address>>(okResult.Value);

            var firstAddressDto = Assert.Single(returnValue);

            Assert.Equal(postcode, firstAddressDto.Postcode);
            Assert.Equal("2 Dummy Lane", firstAddressDto.Address_line1);
            Assert.Equal("Fake Town", firstAddressDto.Address_line2);
            Assert.Equal("London", firstAddressDto.City);

        }

        [Fact]
        public async Task GetAddresses_ReturnsNotFoundResult_WhenAddressDoesNotExist()
        {
            var postcode = "FA99_9ZZ";
            _mockEvGrantRepository.Setup(repo => repo.GetAddresses(postcode))
                .ReturnsAsync(new List<Address>()); 

            var result = await _controller.GetAddresses(postcode);

            var actionResult = Assert.IsType<ActionResult<AddressDto>>(result);
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var returnValue = Assert.IsType<List<Address>>(okResult.Value);

            Assert.Empty(returnValue);
        }
    }
}
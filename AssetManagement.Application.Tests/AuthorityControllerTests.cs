using AssetManagement.Application.Controllers;
using AssetManagement.Contracts.AuthorityDtos;
using AssetManagement.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;

namespace AssetManagement.Application.Tests
{
    public class AuthorityControllerTests
    {
        [Fact]
        public async Task LoginAccount_InvalidObjectPassed_ReturnsBadRequest()
        {
            // Arrange
            var request = new LoginRequest()
            {
                Username = "helghast127553",
                Password = "12345678"
            };
            var userManager = new Mock<UserManager<AppUser>>();
            var configuration = new Mock<IConfiguration>();

            var controller = new AuthorityController(userManager.Object, configuration.Object);

            controller.ModelState.AddModelError("UserName", "Required");
            controller.ModelState.AddModelError("Password", "Required");

            // Act
            var badResponse = await controller.Authenticate(request);

            // Assert
            Assert.IsType<BadRequestObjectResult>(badResponse);
        }
    }
}
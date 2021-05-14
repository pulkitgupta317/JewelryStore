using JewelryStore.Controllers;
using JewelryStore.Services.Contracts;
using JewelryStore.Services.Dtos;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using Xunit;

namespace JewelryStore.Tests
{
    public class UserControllerTests
    {
        [Fact]
        public void TestAuthenticate_BadRequest_WhenValidRequest()
        {
            // Arrange
            AuthRequestDto authRequest = new AuthRequestDto()
            {
                UserName= "Steve",
                Password ="Temp@1234"
            };
            AuthReponseDto authReponseDto = new AuthReponseDto
            {
                AccessToken = "test",
                ExpireIn = 10,
                UserName = "steve",
                UserRole = "Privilaged"
            };
            Mock<IUserService> userServiceMock = new Mock<IUserService>();
            userServiceMock.Setup(x => x.AuthenticateUser(It.IsAny<AuthRequestDto>())).Returns(authReponseDto);
            UserController userController = new UserController(userServiceMock.Object);

            // Act
            var result = userController.Authenticate(authRequest);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void TestAuthenticate_BadRequest_WhenInvalidRequest()
        {
            // Arrange
            AuthRequestDto authRequest = new AuthRequestDto()
            {
                Password = "sdad",
                UserName = "dsa"
            };
            Mock<IUserService> userServiceMock = new Mock<IUserService>();
            userServiceMock.Setup(x => x.AuthenticateUser(It.IsAny<AuthRequestDto>())).Throws(new UnauthorizedAccessException("Invalid Username"));
            UserController userController = new UserController(userServiceMock.Object);

            // Act and Assert
            Assert.Throws<UnauthorizedAccessException>(() => userController.Authenticate(authRequest));
        }
    }
}

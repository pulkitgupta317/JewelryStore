using JewelryStore.DataLayer.Models;
using JewelryStore.DataLayer.Repositories.Contracts;
using JewelryStore.Services.Dtos;
using JewelryStore.Services.Implementations;
using Moq;
using System;
using Xunit;

namespace JewelryStore.Service.Tests
{
    public class UserTest
    {
        public UserTest()
        {
        }

        [Fact]
        public void GetUserTest()
        {
            // Arrange
            var configuration = LocalConfiguration.GetConfiguration();
            var repository = new Mock<IUserRepository>();
            UserRole userRole = new UserRole
            {
                Id = Guid.NewGuid(),
                Name = "Privileged",
                IsActive = true,
                CreatedOn = DateTime.Now
            };

            User user = new User
            {
                CreatedOn = DateTime.Now,
                Id = Guid.NewGuid(),
                IsActive = true,
                Name = "Mathew",
                Password = "pass@1234",
                UserRole = userRole,
                UserRoleId = userRole.Id
            };
            repository.Setup(x => x.GetUser(It.IsAny<string>())).Returns(user);

            //Act
            AuthRequestDto authRequest = new AuthRequestDto 
            {
                Password = "pass@1234",
                UserName = "Mathew"
            };
            var target = new UserService(repository.Object, configuration);
            var result = target.AuthenticateUser(authRequest);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Mathew", result.UserName);
            Assert.Equal("Privileged", result.UserRole);
        }

        [Fact]
        public void Get_Forbidden_When_User_Not_Present()
        {
            // Arrange
            var configuration = LocalConfiguration.GetConfiguration();
            var repository = new Mock<IUserRepository>();

            UserRole userRole = new UserRole
            {
                Id = Guid.NewGuid(),
                Name = "Privileged",
                IsActive = true,
                CreatedOn = DateTime.Now
            };

            User user = new User
            {
                CreatedOn = DateTime.Now,
                Id = Guid.NewGuid(),
                IsActive = false,
                Name = "Mathew",
                Password = "pass@1234",
                UserRole = userRole,
                UserRoleId = userRole.Id
            };
            repository.Setup(x => x.GetUser(It.IsAny<string>())).Returns(user);

            //Act
            AuthRequestDto authRequest = new AuthRequestDto
            {
                Password = "pass@1234",
                UserName = "Mathew"
            };
            var target = new UserService(repository.Object, configuration);

            // Assert
            Assert.Throws<UnauthorizedAccessException>(() => target.AuthenticateUser(authRequest));
        }

        [Fact]
        public void Get_Forbidden_When_User_Password_Not_Same()
        {
            // Arrange
            var configuration = LocalConfiguration.GetConfiguration();
            var repository = new Mock<IUserRepository>();

            UserRole userRole = new UserRole
            {
                Id = Guid.NewGuid(),
                Name = "Privileged",
                IsActive = true,
                CreatedOn = DateTime.Now
            };

            User user = new User
            {
                CreatedOn = DateTime.Now,
                Id = Guid.NewGuid(),
                IsActive = false,
                Name = "Mathew",
                Password = "pass@1234",
                UserRole = userRole,
                UserRoleId = userRole.Id
            };
            repository.Setup(x => x.GetUser(It.IsAny<string>())).Returns(user);

            //Act
            AuthRequestDto authRequest = new AuthRequestDto
            {
                Password = "abcdef",
                UserName = "Mathew"
            };
            var target = new UserService(repository.Object, configuration);

            // Assert
            Assert.Throws<UnauthorizedAccessException>(() => target.AuthenticateUser(authRequest));
        }

        [Fact]
        public void Get_Forbidden_When_User_Not_Active()
        {
            // Arrange
            var configuration = LocalConfiguration.GetConfiguration();
            var repository = new Mock<IUserRepository>();

            User user = null;
            repository.Setup(x => x.GetUser(It.IsAny<string>())).Returns(user);

            //Act
            AuthRequestDto authRequest = new AuthRequestDto
            {
                Password = "pass@1234",
                UserName = "Mathew"
            };
            var target = new UserService(repository.Object, configuration);

            // Assert
            Assert.Throws<UnauthorizedAccessException>(() => target.AuthenticateUser(authRequest));
        }
    }
}

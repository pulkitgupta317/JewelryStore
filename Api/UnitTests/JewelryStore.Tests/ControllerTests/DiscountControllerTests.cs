using JewelryStore.Controllers;
using JewelryStore.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using Xunit;

namespace JewelryStore.Tests
{
    public class DiscountControllerTests
    {

        [Fact]
        public void GetDiscountTest_WhenUserValid()
        {
            // Arrange
            Mock<IDiscountService> discountMock = new Mock<IDiscountService>();
            discountMock.Setup(x => x.GetDiscountByUserRole(It.IsAny<Guid>())).Returns(2);

            DiscountController discountController = new DiscountController(discountMock.Object);
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Role, Guid.NewGuid().ToString()));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString()));
            var mockContext = new Mock<HttpContext>(MockBehavior.Strict);
            mockContext.SetupGet(h => h.User.Claims).Returns(claims);
            discountController.ControllerContext = new ControllerContext()
            {
                HttpContext = mockContext.Object
            };

            //Act
            var discount = discountController.GetDiscount();

            // Assert
            Assert.NotNull(discount);
            Assert.IsType<OkObjectResult>(discount);
        }

        [Fact]
        public void GetDiscountTest_WhenUserNotValid()
        {
            // Arrange
            Mock<IDiscountService> discountMock = new Mock<IDiscountService>();
            discountMock.Setup(x => x.GetDiscountByUserRole(It.IsAny<Guid>())).Returns(2);

            DiscountController discountController = new DiscountController(discountMock.Object);

            //Act and Assert
            Assert.Throws<NullReferenceException>(() => discountController.GetDiscount());
        }
    }
}

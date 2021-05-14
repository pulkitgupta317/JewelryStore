using JewelryStore.DataLayer.Models;
using JewelryStore.DataLayer.Repositories.Contracts;
using JewelryStore.Services.Implementations;
using Moq;
using System;
using Xunit;

namespace JewelryStore.Service.Tests
{
    public class DiscountTest
    {
        public DiscountTest()
        {
            //var configuration = LocalConfiguration.GetConfiguration();
            //var repository = new Mock<IDiscountRepository>();
            //Discount discount = new Discount()
            //{
            //    DiscountPer = 10
            //};
            //repository.Setup(x => x.GetDiscountByUserRole(It.IsAny<Guid>())).Returns(discount);
        }

        [Fact]
        public void GetDiscountTest()
        {
            // Arrange
            var configuration = LocalConfiguration.GetConfiguration();
            var repository = new Mock<IDiscountRepository>();
            Discount discount = new Discount()
            {
                DiscountPer = 10
            };
            repository.Setup(x => x.GetDiscountByUserRole(It.IsAny<Guid>())).Returns(discount);

            //Act
            var target = new DiscountService(repository.Object);
            var result = target.GetDiscountByUserRole(Guid.NewGuid());

            // Assert
            Assert.Equal(10, result);
        }
    }
}

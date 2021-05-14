using JewelryStore.DataLayer.Models;
using JewelryStore.DataLayer.Repositories.Contracts;
using JewelryStore.DataLayer.Repositories.Implementations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace JewelryStore.DataLayer.Tests
{
    public class DiscountTests
    {
        private DbContextOptions<JewelryStoreDbContext> _dbContextOptions = new DbContextOptionsBuilder<JewelryStoreDbContext>()
            .UseInMemoryDatabase(databaseName: "JewelryShop")
            .Options;

        private List<UserRole> _userRoles;
        private List<Discount> _discounts;

        public DiscountTests()
        {
            SeedDb();
        }

        [Fact]
        public void GetDiscountForExistingUserRoleTest()
        {
            IDiscountRepository discountRepository = new DiscountRepository(new JewelryStoreDbContext(_dbContextOptions));
            var userRoleId = _userRoles.First().Id;
            var discount = discountRepository.GetDiscountByUserRole(userRoleId);
            Assert.Equal(_discounts.First(x => x.UserRoleId.Equals(userRoleId)).DiscountPer, discount.DiscountPer);
        }

        [Fact]
        public void GetDiscountForNonExistingUserRoleTest()
        {
            IDiscountRepository discountRepository = new DiscountRepository(new JewelryStoreDbContext(_dbContextOptions));
            var userRoleId = Guid.NewGuid();
            var discount = discountRepository.GetDiscountByUserRole(userRoleId);
            Assert.Null(discount);
        }

        private void SeedDb()
        {
            using var context = new JewelryStoreDbContext(_dbContextOptions);
            _userRoles = new List<UserRole>
            {
                new UserRole { Id = Guid.NewGuid(), CreatedOn = DateTime.Now, Name = "Privilaged", IsActive = true},
                new UserRole { Id = Guid.NewGuid(), CreatedOn = DateTime.Now, Name = "Regular", IsActive = true}
            };
            _discounts = new List<Discount>
            {
                new Discount { Id = Guid.NewGuid(), CreatedOn = DateTime.Now, DiscountPer = 2, IsActive = true, UserRoleId = _userRoles.First().Id },
                new Discount { Id = Guid.NewGuid(), CreatedOn = DateTime.Now, DiscountPer = 0, IsActive = true, UserRoleId = _userRoles.Skip(1).First().Id }
            };
            context.AddRange(_userRoles);
            context.AddRange(_discounts);
            context.SaveChanges();
        }
    }
}

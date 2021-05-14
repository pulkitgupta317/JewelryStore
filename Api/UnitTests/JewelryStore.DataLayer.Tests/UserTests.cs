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
    public class UserTests
    {
        private DbContextOptions<JewelryStoreDbContext> _dbContextOptions = new DbContextOptionsBuilder<JewelryStoreDbContext>()
            .UseInMemoryDatabase(databaseName: "JewelryShop")
            .Options;

        private List<UserRole> _userRoles;
        private List<User> _users;

        public UserTests()
        {
            SeedDb();
        }

        [Fact]
        public void GetExistingUserTest()
        {
            IUserRepository userRepository = new UserRepository(new JewelryStoreDbContext(_dbContextOptions));
            var user = _users[0];
            var actualUser = userRepository.GetUser(user.Name);
            Assert.Equal(user.Id, actualUser.Id);
        }

        [Fact]
        public void GetNonExistingUserTest()
        {
            IUserRepository userRepository = new UserRepository(new JewelryStoreDbContext(_dbContextOptions));
            var actualUser = userRepository.GetUser("Something");
            Assert.Null(actualUser);
        }

        private void SeedDb()
        {
            using var context = new JewelryStoreDbContext(_dbContextOptions);
            _userRoles = new List<UserRole>
            {
                new UserRole { Id = Guid.NewGuid(), CreatedOn = DateTime.Now, Name = "Privilaged", IsActive = true},
                new UserRole { Id = Guid.NewGuid(), CreatedOn = DateTime.Now, Name = "Regular", IsActive = true}
            };
            _users = new List<User>
            {
                new User { Id = Guid.NewGuid(), CreatedOn = DateTime.Now, Name = "Abby", Password = "temp@123", IsActive = true, UserRoleId = _userRoles.First().Id },
               new User { Id = Guid.NewGuid(), CreatedOn = DateTime.Now, Name = "Barack", Password = "temp@123", IsActive = true, UserRoleId = _userRoles.Skip(1).First().Id },
            };
            context.AddRange(_userRoles);
            context.AddRange(_users);
            context.SaveChanges();
        }
    }
}

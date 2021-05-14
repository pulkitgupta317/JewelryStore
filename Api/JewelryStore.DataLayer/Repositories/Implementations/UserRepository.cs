using ContactManagement.DataLayer;
using JewelryStore.DataLayer.Models;
using JewelryStore.DataLayer.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace JewelryStore.DataLayer.Repositories.Implementations
{
    public class UserRepository: GenericRepository<User>, IUserRepository
    {
        public UserRepository(JewelryStoreDbContext context) : base(context)
        {

        }

        public User GetUser(string userName)
        {
            return GetQueryable(x => x.Name.Equals(userName), "UserRole").FirstOrDefault();
        }
    }
}

using ContactManagement.DataLayer;
using JewelryStore.DataLayer.Models;
using JewelryStore.DataLayer.Repositories.Contracts;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace JewelryStore.DataLayer.Repositories.Implementations
{
    public class DiscountRepository : GenericRepository<Discount>, IDiscountRepository
    {
        public DiscountRepository(JewelryStoreDbContext context): base(context)
        {

        }

        public Discount GetDiscountByUserRole(Guid userRoleId)
        {
            return GetQueryable(x => x.UserRoleId.Equals(userRoleId)).FirstOrDefault();
        }
    }
}

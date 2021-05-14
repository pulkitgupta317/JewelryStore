using JewelryStore.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace JewelryStore.DataLayer.Repositories.Contracts
{
    public interface IDiscountRepository
    {
        Discount GetDiscountByUserRole(Guid userRoleId);
    }
}

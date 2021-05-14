using System;
using System.Collections.Generic;
using System.Text;

namespace JewelryStore.Services.Contracts
{
    public interface IDiscountService
    {
        decimal GetDiscountByUserRole(Guid userRoleId);
    }
}

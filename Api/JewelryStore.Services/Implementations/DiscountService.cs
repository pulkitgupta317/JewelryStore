using JewelryStore.DataLayer.Repositories.Contracts;
using JewelryStore.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace JewelryStore.Services.Implementations
{
    public class DiscountService : IDiscountService
    {
        private readonly IDiscountRepository _discountRepository;

        public DiscountService(IDiscountRepository discountRepository)
        {
            _discountRepository = discountRepository;
        }

        public decimal GetDiscountByUserRole(Guid userRoleId)
        {
            var discount = _discountRepository.GetDiscountByUserRole(userRoleId);
            return discount == null ? 0 : discount.DiscountPer;
        }
    }
}

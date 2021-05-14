using System;
using System.Collections.Generic;
using System.Text;

namespace JewelryStore.DataLayer.Models
{
    public class Discount: Base.BaseEntity
    {
        public decimal DiscountPer { get; set; }

        public Guid UserRoleId { get; set; }

        public UserRole UserRole { get; set; }
    }
}

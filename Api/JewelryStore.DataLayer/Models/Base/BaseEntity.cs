using System;

namespace JewelryStore.DataLayer.Models.Base
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}

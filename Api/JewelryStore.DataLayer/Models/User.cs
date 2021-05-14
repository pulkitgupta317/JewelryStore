using System;

namespace JewelryStore.DataLayer.Models
{
    public class User: Base.BaseEntity
    {
        public string Name { get; set; }

        public Guid UserRoleId { get; set; }

        public string Password { get; set; }

        public UserRole UserRole { get; set; }
    }
}

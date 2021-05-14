using JewelryStore.DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace JewelryStore.DataLayer
{
    public class JewelryStoreDbContext: DbContext
    {
        public JewelryStoreDbContext(DbContextOptions<JewelryStoreDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<UserRole> UserRole { get; set; }

        public virtual DbSet<User> User { get; set; }

        public virtual DbSet<Discount> Discount { get; set; }
    }
}

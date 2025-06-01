using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Osus.Core;

namespace Osus.Data
{
    public class OsusDbContext : DbContext
    {
        public OsusDbContext() : base("DefaultConnection")
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductVariation> ProductVariations { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderAddress> OrderAddress { get; set; }
        public DbSet<User> Users { get; set; }
    }
}

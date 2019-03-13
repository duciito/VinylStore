using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using VinylStore.Entities;

namespace VinylStore.Repositories
{
    public class VinylStoreDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        public VinylStoreDbContext()
            : base(@"Server=DESKTOP-LMH9NVO;Database=VinylStore;Trusted_Connection=True;")
        {
            Users = Set<User>();
            Products = Set<Product>();
            Genres = Set<Genre>();
            Orders = Set<Order>();
            OrderItems = Set<OrderItem>();
        }
    }

}
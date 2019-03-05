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

        public VinylStoreDbContext()
            : base(@"Server=DESKTOP-LMH9NVO;Database=VinylStore;Trusted_Connection=True;")
        {
            Users = Set<User>();
        }
    }

}
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using VinylStore.Entities;

namespace VinylStore.Repositories
{
    public class UsersRepository : BaseRepository<User>
    {
        public User GetByUsernameAndPassword(string username, string password)
        {
            VinylStoreDbContext context = new VinylStoreDbContext();

            return context.Users.Where(i => i.Username == username &&
            i.Password == password).FirstOrDefault();
        }
    }
}
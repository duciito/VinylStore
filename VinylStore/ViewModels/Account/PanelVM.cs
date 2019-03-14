using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VinylStore.Entities;

namespace VinylStore.ViewModels.Account
{
    public class PanelVM
    {
        public List<User> Users { get; set; }
        public List<Order> Orders { get; set; }
    }
}
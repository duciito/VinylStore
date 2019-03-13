using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VinylStore.Entities;

namespace VinylStore.ViewModels.Account
{
    public class IndexVM
    {
        public Dictionary<Product, int> CartProducts { get; set; }
        public List<Order> Orders { get; set; }
    }
}
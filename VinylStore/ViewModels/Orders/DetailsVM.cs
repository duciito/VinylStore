using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VinylStore.Entities;

namespace VinylStore.ViewModels.Orders
{
    public class DetailsVM
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public Dictionary<Product, int> OrderProducts { get; set; }
        public bool IsApproved { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
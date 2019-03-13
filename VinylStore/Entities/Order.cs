using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VinylStore.Entities
{
    public class Order : BaseEntity
    {
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public bool IsApproved { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        public List<OrderItem> OrderItems { get; set; }
    }
}
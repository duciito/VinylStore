using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VinylStore.Entities
{
    public class Product : BaseEntity
    {
        public int GenreId { get; set; }
        public string Artist { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string VinylImgPath { get; set; }
        public bool OnSale { get; set; }

        [ForeignKey("GenreId")]
        public Genre Genre { get; set; }

        public List<OrderItem> OrderItems { get; set; }

        public override bool Equals(object obj)
        {
            var k = obj as Product;
            if (k != null)
            {
                return this.Id == k.Id;
            }
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VinylStore.Entities
{
    public class Genre : BaseEntity
    {
        public string Name { get; set; }

        public List<Product> Vinyls { get; set; }
    }
}
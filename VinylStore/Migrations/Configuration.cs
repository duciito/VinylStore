namespace VinylStore.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using VinylStore.Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<VinylStore.Repositories.VinylStoreDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "VinylStore.Repositories.VinylStoreDbContext";
        }

        protected override void Seed(VinylStore.Repositories.VinylStoreDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            Genre jazz = new Genre { Name = "Джаз" };
            Genre blues = new Genre { Name = "Блус" };
            Genre funk = new Genre { Name = "Фънк" };

            context.Genres.AddOrUpdate(g => g.Name, jazz);
            context.Genres.AddOrUpdate(g => g.Name, blues);
            context.Genres.AddOrUpdate(g => g.Name, funk);

            context.Products.AddOrUpdate(p => p.Id, new Product
            {
                Artist = "Elliot Galvin trio",
                Title = "The Influencing Machine",
                Genre = jazz,
                Price = 7.99m,
                VinylImgPath = "/Content/img/elliot.jpg",
                OnSale = true
            });

            context.Products.AddOrUpdate(p => p.Id, new Product
            {
                Artist = "LTF",
                Title = "Catapult / Spiral",
                Genre = jazz,
                Price = 5.69m,
                VinylImgPath = "/Content/img/catapult.jpg",
                OnSale = false
            });

            context.Products.AddOrUpdate(p => p.Id, new Product
            {
                Artist = "Mary Halvorson octet",
                Title = "Away With You",
                Genre = jazz,
                Price = 9.49m,
                VinylImgPath = "/Content/img/mary.jpg",
                OnSale = false
            });

            context.Products.AddOrUpdate(p => p.Id, new Product
            {
                Artist = "Zara McFarlane",
                Title = "Peace Begins Within",
                Genre = jazz,
                Price = 4.99m,
                VinylImgPath = "/Content/img/zara.jpg",
                OnSale = false
            });

            context.Products.AddOrUpdate(p => p.Id, new Product
            {
                Artist = "Iamddb",
                Title = "Vibe vol. 2",
                Genre = jazz,
                Price = 8.99m,
                VinylImgPath = "/Content/img/vibe.jpg",
                OnSale = false
            });

            context.Products.AddOrUpdate(p => p.Id, new Product
            {
                Artist = "Sun Ra",
                Title = "Media Dreams",
                Genre = jazz,
                Price = 10.99m,
                VinylImgPath = "/Content/img/sun.jpg",
                OnSale = false
            });

            context.Products.AddOrUpdate(p => p.Id, new Product
            {
                Artist = "Steve Blum",
                Title = "Phases",
                Genre = blues,
                Price = 8.49m,
                VinylImgPath = "/Content/img/steve.jpg",
                OnSale = false
            });

            context.Products.AddOrUpdate(p => p.Id, new Product
            {
                Artist = "Homeshake",
                Title = "Fresh Air",
                Genre = blues,
                Price = 7.19m,
                VinylImgPath = "/Content/img/fresh.jpg",
                OnSale = false
            });

            context.Products.AddOrUpdate(p => p.Id, new Product
            {
                Artist = "Kristofer Maddigan",
                Title = "Cuphead",
                Genre = blues,
                Price = 11.99m,
                VinylImgPath = "/Content/img/cuphead.jpg",
                OnSale = false
            });

            context.Products.AddOrUpdate(p => p.Id, new Product
            {
                Artist = "Shabaka And The Ancestors",
                Title = "Wisdom Of Elders",
                Genre = blues,
                Price = 9.99m,
                VinylImgPath = "/Content/img/wisdom.jpg",
                OnSale = false
            });

            context.Products.AddOrUpdate(p => p.Id, new Product
            {
                Artist = "Tuba Skinny",
                Title = "Owl Call Blues",
                Genre = blues,
                Price = 14.99m,
                VinylImgPath = "/Content/img/owl.jpg",
                OnSale = false
            });

            context.Products.AddOrUpdate(p => p.Id, new Product
            {
                Artist = "Carolina Reapers Swing",
                Title = "Unreasonably Hot",
                Genre = blues,
                Price = 8.49m,
                VinylImgPath = "/Content/img/carolina.jpg",
                OnSale = false
            });

            context.Products.AddOrUpdate(p => p.Id, new Product
            {
                Artist = "Keenan McKenzie",
                Title = "Forged In Rhythm",
                Genre = funk,
                Price = 9.99m,
                VinylImgPath = "/Content/img/keenan.jpg",
                OnSale = false
            });

            context.Products.AddOrUpdate(p => p.Id, new Product
            {
                Artist = "Ghost",
                Title = "Snapshot",
                Genre = funk,
                Price = 6.89m,
                VinylImgPath = "/Content/img/ghost.jpg",
                OnSale = false
            });

            context.Products.AddOrUpdate(p => p.Id, new Product
            {
                Artist = "Dojo Cuts",
                Title = "Take From Me",
                Genre = funk,
                Price = 12.49m,
                VinylImgPath = "/Content/img/dojo.jpg",
                OnSale = false
            });

            context.Products.AddOrUpdate(p => p.Id, new Product
            {
                Artist = "Smerin's Anti-Social Club",
                Title = "Jelly Deals",
                Genre = funk,
                Price = 8.99m,
                VinylImgPath = "/Content/img/jelly.jpg",
                OnSale = false
            });

            context.Products.AddOrUpdate(p => p.Id, new Product
            {
                Artist = "Tetelepta & Lekatompessy",
                Title = "Kering#004",
                Genre = funk,
                Price = 10.49m,
                VinylImgPath = "/Content/img/kering.jpg",
                OnSale = false
            });

            context.Products.AddOrUpdate(p => p.Id, new Product
            {
                Artist = "Omega Supreme Records",
                Title = "Superstructure",
                Genre = funk,
                Price = 7.89m,
                VinylImgPath = "/Content/img/super.jpg",
                OnSale = false
            });

            base.Seed(context);
        }
    }
}

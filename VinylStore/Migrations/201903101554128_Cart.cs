namespace VinylStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Cart : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "Cart_Id", "dbo.Carts");
            DropForeignKey("dbo.Carts", "Id", "dbo.Users");
            DropIndex("dbo.Products", new[] { "Cart_Id" });
            DropIndex("dbo.Carts", new[] { "Id" });
            DropColumn("dbo.Products", "Cart_Id");
            DropColumn("dbo.Users", "CartId");
            DropTable("dbo.Carts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Users", "CartId", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "Cart_Id", c => c.Int());
            CreateIndex("dbo.Carts", "Id");
            CreateIndex("dbo.Products", "Cart_Id");
            AddForeignKey("dbo.Carts", "Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Products", "Cart_Id", "dbo.Carts", "Id");
        }
    }
}

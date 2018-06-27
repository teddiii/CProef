namespace CproefLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class supplier : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 50),
                        email = c.String(nullable: false, maxLength: 255),
                        phonenr = c.String(nullable: false),
                        streetname_and_number = c.String(nullable: false),
                        city = c.String(nullable: false),
                        postalcode = c.Int(nullable: false),
                        created_at = c.DateTime(nullable: false),
                        modified_at = c.DateTime(nullable: false),
                        deleted_at = c.DateTime(),
                    })
                .PrimaryKey(t => t.id)
                .Index(t => t.email, unique: true);
            
            AddColumn("dbo.Products", "Supplier_Id", c => c.Int());
            AddColumn("dbo.Clients", "phonenr", c => c.String(nullable: false));
            AddColumn("dbo.Clients", "streetname_and_number", c => c.String(nullable: false));
            AddColumn("dbo.Clients", "city", c => c.String(nullable: false));
            AddColumn("dbo.Clients", "postalcode", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "Supplier_Id");
            AddForeignKey("dbo.Products", "Supplier_Id", "dbo.Suppliers", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Supplier_Id", "dbo.Suppliers");
            DropIndex("dbo.Suppliers", new[] { "email" });
            DropIndex("dbo.Products", new[] { "Supplier_Id" });
            DropColumn("dbo.Clients", "postalcode");
            DropColumn("dbo.Clients", "city");
            DropColumn("dbo.Clients", "streetname_and_number");
            DropColumn("dbo.Clients", "phonenr");
            DropColumn("dbo.Products", "Supplier_Id");
            DropTable("dbo.Suppliers");
        }
    }
}

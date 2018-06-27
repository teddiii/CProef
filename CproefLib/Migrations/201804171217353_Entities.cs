namespace CproefLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Entities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 255),
                        created_at = c.DateTime(nullable: false),
                        modified_at = c.DateTime(nullable: false),
                        deleted_at = c.DateTime(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 255),
                        descr = c.String(),
                        unit_price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Currentstock = c.Int(nullable: false),
                        is_active = c.Boolean(nullable: false),
                        Brand_Id = c.Int(),
                        created_at = c.DateTime(nullable: false),
                        modified_at = c.DateTime(nullable: false),
                        deleted_at = c.DateTime(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Brands", t => t.Brand_Id)
                .Index(t => t.Brand_Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 255),
                        is_active = c.Boolean(nullable: false),
                        parent_id = c.Int(),
                        created_at = c.DateTime(nullable: false),
                        modified_at = c.DateTime(nullable: false),
                        deleted_at = c.DateTime(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Categories", t => t.parent_id)
                .Index(t => t.parent_id);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        id = c.Guid(nullable: false, identity: true),
                        lastname = c.String(name: "last name", nullable: false, maxLength: 255),
                        firstname = c.String(name: "first name", nullable: false, maxLength: 255),
                        user_name = c.String(nullable: false, maxLength: 50),
                        email = c.String(nullable: false, maxLength: 255),
                        encrypted_pwd = c.String(nullable: false, maxLength: 255),
                        pwd_salt = c.String(maxLength: 255),
                        created_at = c.DateTime(nullable: false),
                        modified_at = c.DateTime(nullable: false),
                        deleted_at = c.DateTime(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        created_at = c.DateTime(nullable: false),
                        modified_at = c.DateTime(nullable: false),
                        deleted_at = c.DateTime(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Payment_Options",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        created_at = c.DateTime(nullable: false),
                        modified_at = c.DateTime(nullable: false),
                        deleted_at = c.DateTime(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        user_id = c.Guid(nullable: false),
                        firstname = c.String(name: "first name", nullable: false, maxLength: 255),
                        lastname = c.String(name: "last name", nullable: false, maxLength: 255),
                        user_name = c.String(nullable: false, maxLength: 50),
                        encrypted_pwd = c.String(nullable: false, maxLength: 255),
                        pwd_salt = c.String(maxLength: 255),
                        email = c.String(nullable: false, maxLength: 255),
                        created_at = c.DateTime(nullable: false),
                        modified_at = c.DateTime(nullable: false),
                        deleted_at = c.DateTime(),
                    })
                .PrimaryKey(t => t.user_id);
            
            CreateTable(
                "dbo.CategoriesProducts",
                c => new
                    {
                        Categories_Id = c.Int(nullable: false),
                        Products_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Categories_Id, t.Products_Id })
                .ForeignKey("dbo.Categories", t => t.Categories_Id, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Products_Id, cascadeDelete: true)
                .Index(t => t.Categories_Id)
                .Index(t => t.Products_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CategoriesProducts", "Products_Id", "dbo.Products");
            DropForeignKey("dbo.CategoriesProducts", "Categories_Id", "dbo.Categories");
            DropForeignKey("dbo.Categories", "parent_id", "dbo.Categories");
            DropForeignKey("dbo.Products", "Brand_Id", "dbo.Brands");
            DropIndex("dbo.CategoriesProducts", new[] { "Products_Id" });
            DropIndex("dbo.CategoriesProducts", new[] { "Categories_Id" });
            DropIndex("dbo.Categories", new[] { "parent_id" });
            DropIndex("dbo.Products", new[] { "Brand_Id" });
            DropTable("dbo.CategoriesProducts");
            DropTable("dbo.Users");
            DropTable("dbo.Payment_Options");
            DropTable("dbo.Languages");
            DropTable("dbo.Clients");
            DropTable("dbo.Categories");
            DropTable("dbo.Products");
            DropTable("dbo.Brands");
        }
    }
}

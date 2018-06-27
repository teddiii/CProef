namespace CproefLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrdersCouriers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Couriers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        email = c.String(nullable: false, maxLength: 255),
                        phonenr = c.String(nullable: false),
                        name = c.String(nullable: false, maxLength: 50),
                        created_at = c.DateTime(nullable: false),
                        modified_at = c.DateTime(nullable: false),
                        deleted_at = c.DateTime(),
                    })
                .PrimaryKey(t => t.id)
                .Index(t => t.email, unique: true);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Orderdate = c.DateTime(nullable: false),
                        ProcessDate = c.DateTime(nullable: false),
                        SendDate = c.DateTime(nullable: false),
                        Courier_Id = c.Int(),
                        created_at = c.DateTime(nullable: false),
                        modified_at = c.DateTime(nullable: false),
                        deleted_at = c.DateTime(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Couriers", t => t.Courier_Id)
                .Index(t => t.Courier_Id);
            
            CreateIndex("dbo.Clients", "user_name", unique: true);
            CreateIndex("dbo.Clients", "email", unique: true);
        }
        
        public override void Down()
        {
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
            
            DropForeignKey("dbo.Orders", "Courier_Id", "dbo.Couriers");
            DropIndex("dbo.Orders", new[] { "Courier_Id" });
            DropIndex("dbo.Couriers", new[] { "email" });
            DropIndex("dbo.Clients", new[] { "email" });
            DropIndex("dbo.Clients", new[] { "user_name" });
            DropTable("dbo.Orders");
            DropTable("dbo.Couriers");
        }
    }
}

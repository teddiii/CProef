namespace CproefLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Status : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        description = c.String(nullable: false),
                        created_at = c.DateTime(nullable: false),
                        modified_at = c.DateTime(nullable: false),
                        deleted_at = c.DateTime(),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.Orders", "Client_Id", c => c.Guid());
            AddColumn("dbo.Orders", "Status_Id", c => c.Int());
            CreateIndex("dbo.Orders", "Client_Id");
            CreateIndex("dbo.Orders", "Status_Id");
            AddForeignKey("dbo.Orders", "Client_Id", "dbo.Clients", "id");
            AddForeignKey("dbo.Orders", "Status_Id", "dbo.Status", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "Status_Id", "dbo.Status");
            DropForeignKey("dbo.Orders", "Client_Id", "dbo.Clients");
            DropIndex("dbo.Orders", new[] { "Status_Id" });
            DropIndex("dbo.Orders", new[] { "Client_Id" });
            DropColumn("dbo.Orders", "Status_Id");
            DropColumn("dbo.Orders", "Client_Id");
            DropTable("dbo.Status");
        }
    }
}

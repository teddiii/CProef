namespace CproefLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Defaultspecs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DefaultSpecs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        description = c.String(nullable: false),
                        value = c.String(nullable: false),
                        Categories_Id = c.Int(),
                        created_at = c.DateTime(nullable: false),
                        modified_at = c.DateTime(nullable: false),
                        deleted_at = c.DateTime(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Categories", t => t.Categories_Id)
                .Index(t => t.Categories_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DefaultSpecs", "Categories_Id", "dbo.Categories");
            DropIndex("dbo.DefaultSpecs", new[] { "Categories_Id" });
            DropTable("dbo.DefaultSpecs");
        }
    }
}

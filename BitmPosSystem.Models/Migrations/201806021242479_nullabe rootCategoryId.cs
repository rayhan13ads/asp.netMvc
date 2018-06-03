namespace BitmPosSystem.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullaberootCategoryId : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Categories", new[] { "RootCategoryId" });
            AlterColumn("dbo.Categories", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Categories", "CateogryCode", c => c.String(nullable: false));
            AlterColumn("dbo.Categories", "RootCategoryId", c => c.Int());
            CreateIndex("dbo.Categories", "RootCategoryId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Categories", new[] { "RootCategoryId" });
            AlterColumn("dbo.Categories", "RootCategoryId", c => c.Int(nullable: false));
            AlterColumn("dbo.Categories", "CateogryCode", c => c.String());
            AlterColumn("dbo.Categories", "Name", c => c.String());
            CreateIndex("dbo.Categories", "RootCategoryId");
        }
    }
}

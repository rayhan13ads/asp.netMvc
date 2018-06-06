namespace BitmPosSystem.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_purchaseModel_add_organisetion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Purchases", "OrganisetioId", c => c.Int(nullable: false));
            CreateIndex("dbo.Purchases", "OrganisetioId");
            AddForeignKey("dbo.Purchases", "OrganisetioId", "dbo.Organisetions", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Purchases", "OrganisetioId", "dbo.Organisetions");
            DropIndex("dbo.Purchases", new[] { "OrganisetioId" });
            DropColumn("dbo.Purchases", "OrganisetioId");
        }
    }
}

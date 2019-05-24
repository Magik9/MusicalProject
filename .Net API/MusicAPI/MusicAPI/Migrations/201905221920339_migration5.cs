namespace MusicAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Discoes", "Band_id", "dbo.Bands");
            DropIndex("dbo.Discoes", new[] { "Band_id" });
            DropIndex("dbo.Branoes", new[] { "Disco_id" });
            AddColumn("dbo.Discoes", "Band_id1", c => c.Int());
            AlterColumn("dbo.Discoes", "Band_id", c => c.Int(nullable: false));
            AlterColumn("dbo.Branoes", "Disco_id", c => c.Int());
            AlterColumn("dbo.Branoes", "disco_id", c => c.Int(nullable: false));
            CreateIndex("dbo.Discoes", "Band_id1");
            CreateIndex("dbo.Branoes", "Disco_id");
            AddForeignKey("dbo.Discoes", "Band_id1", "dbo.Bands", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Discoes", "Band_id1", "dbo.Bands");
            DropIndex("dbo.Branoes", new[] { "Disco_id" });
            DropIndex("dbo.Discoes", new[] { "Band_id1" });
            AlterColumn("dbo.Branoes", "disco_id", c => c.Int());
            AlterColumn("dbo.Branoes", "Disco_id", c => c.Int(nullable: false));
            AlterColumn("dbo.Discoes", "Band_id", c => c.Int());
            DropColumn("dbo.Discoes", "Band_id1");
            CreateIndex("dbo.Branoes", "Disco_id");
            CreateIndex("dbo.Discoes", "Band_id");
            AddForeignKey("dbo.Discoes", "Band_id", "dbo.Bands", "id");
        }
    }
}

namespace MusicAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration4 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Branoes", new[] { "Disco_id" });
            AlterColumn("dbo.Branoes", "disco_id", c => c.Int(nullable: false));
            CreateIndex("dbo.Branoes", "Disco_id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Branoes", new[] { "Disco_id" });
            AlterColumn("dbo.Branoes", "disco_id", c => c.Int());
            CreateIndex("dbo.Branoes", "Disco_id");
        }
    }
}

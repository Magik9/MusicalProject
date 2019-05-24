namespace MusicAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration6 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Branoes", new[] { "Disco_id" });
            AlterColumn("dbo.Branoes", "Disco_id", c => c.Int());
            AlterColumn("dbo.Branoes", "Disco_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Branoes", "Disco_id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Branoes", new[] { "Disco_id" });
            AlterColumn("dbo.Branoes", "Disco_Id", c => c.Int());
            AlterColumn("dbo.Branoes", "Disco_id", c => c.Int(nullable: false));
            CreateIndex("dbo.Branoes", "Disco_id");
        }
    }
}

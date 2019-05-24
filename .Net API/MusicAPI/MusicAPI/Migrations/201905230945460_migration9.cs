namespace MusicAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration9 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Branoes", new[] { "Disco_Id" });
            AlterColumn("dbo.Branoes", "Disco_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Branoes", "Disco_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Branoes", new[] { "Disco_Id" });
            AlterColumn("dbo.Branoes", "Disco_Id", c => c.Int(nullable: false, identity: true));
            CreateIndex("dbo.Branoes", "Disco_Id");
        }
    }
}

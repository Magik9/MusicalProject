namespace MusicAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration7 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Branoes", "Disco_id", "dbo.Discoes");
            DropIndex("dbo.Branoes", new[] { "Disco_id" });
            AlterColumn("dbo.Branoes", "Disco_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Branoes", "Disco_Id");
            AddForeignKey("dbo.Branoes", "Disco_Id", "dbo.Discoes", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Branoes", "Disco_Id", "dbo.Discoes");
            DropIndex("dbo.Branoes", new[] { "Disco_Id" });
            AlterColumn("dbo.Branoes", "Disco_Id", c => c.Int());
            CreateIndex("dbo.Branoes", "Disco_id");
            AddForeignKey("dbo.Branoes", "Disco_id", "dbo.Discoes", "id");
        }
    }
}

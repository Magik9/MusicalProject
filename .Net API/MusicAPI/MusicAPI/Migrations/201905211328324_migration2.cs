namespace MusicAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Branoes", "id_album");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Branoes", "id_album", c => c.Int(nullable: false));
        }
    }
}

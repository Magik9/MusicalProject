namespace MusicAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Discoes", "id_band");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Discoes", "id_band", c => c.Int(nullable: false));
        }
    }
}

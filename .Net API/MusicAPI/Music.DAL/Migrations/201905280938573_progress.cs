namespace Music.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class progress : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Brano", "a");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Brano", "a", c => c.Int(nullable: false));
        }
    }
}

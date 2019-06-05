namespace Music.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Disco", "Anno", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Disco", "Anno", c => c.Int(nullable: false));
        }
    }
}

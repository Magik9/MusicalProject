namespace Music.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class progress1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Art_Strum", "CreatedOn");
            DropColumn("dbo.Art_Strum", "ModifiedOn");
            DropColumn("dbo.Artista", "CreatedOn");
            DropColumn("dbo.Artista", "ModifiedOn");
            DropColumn("dbo.Strumento", "CreatedOn");
            DropColumn("dbo.Strumento", "ModifiedOn");
            DropColumn("dbo.Band-Art", "CreatedOn");
            DropColumn("dbo.Band-Art", "ModifiedOn");
            DropColumn("dbo.Band", "CreatedOn");
            DropColumn("dbo.Band", "ModifiedOn");
            DropColumn("dbo.Band_Gen", "CreatedOn");
            DropColumn("dbo.Band_Gen", "ModifiedOn");
            DropColumn("dbo.Genere", "CreatedOn");
            DropColumn("dbo.Genere", "ModifiedOn");
            DropColumn("dbo.Brano", "CreatedOn");
            DropColumn("dbo.Brano", "ModifiedOn");
            DropColumn("dbo.Disco", "CreatedOn");
            DropColumn("dbo.Disco", "ModifiedOn");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Disco", "ModifiedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Disco", "CreatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Brano", "ModifiedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Brano", "CreatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Genere", "ModifiedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Genere", "CreatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Band_Gen", "ModifiedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Band_Gen", "CreatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Band", "ModifiedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Band", "CreatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Band-Art", "ModifiedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Band-Art", "CreatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Strumento", "ModifiedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Strumento", "CreatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Artista", "ModifiedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Artista", "CreatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Art_Strum", "ModifiedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Art_Strum", "CreatedOn", c => c.DateTime(nullable: false));
        }
    }
}

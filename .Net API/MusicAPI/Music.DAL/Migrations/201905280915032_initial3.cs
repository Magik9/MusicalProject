namespace Music.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Art_Strum",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Artista_Id = c.Int(nullable: false),
                        Strumento_Id = c.Int(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Band_Gen",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Band_Id = c.Int(nullable: false),
                        Genere_Id = c.Int(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Band_Gen");
            DropTable("dbo.Art_Strum");
        }
    }
}

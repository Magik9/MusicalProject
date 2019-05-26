namespace MusicAPI.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bands",
                c => new
                    {
                        id = c.Int(nullable: false),
                        nome = c.String(),
                        genere = c.String(),
                        nMembri = c.Int(nullable: false),
                        anno = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Discoes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Titolo = c.String(),
                        anno = c.Int(nullable: false),
                        id_band = c.Int(nullable: false),
                        Band_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Bands", t => t.Band_id)
                .Index(t => t.Band_id);
            
            CreateTable(
                "dbo.Branoes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        titolo = c.String(),
                        durata = c.String(),
                        id_band = c.Int(nullable: false),
                        id_album = c.Int(nullable: false),
                        Disco_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Discoes", t => t.Disco_id)
                .Index(t => t.Disco_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Discoes", "Band_id", "dbo.Bands");
            DropForeignKey("dbo.Branoes", "Disco_id", "dbo.Discoes");
            DropIndex("dbo.Branoes", new[] { "Disco_id" });
            DropIndex("dbo.Discoes", new[] { "Band_id" });
            DropTable("dbo.Branoes");
            DropTable("dbo.Discoes");
            DropTable("dbo.Bands");
        }
    }
}

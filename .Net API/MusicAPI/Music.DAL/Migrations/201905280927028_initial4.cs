namespace Music.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial4 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Art_Strum", "Artista_Id");
            CreateIndex("dbo.Art_Strum", "Strumento_Id");
            CreateIndex("dbo.Band-Art", "Band_Id");
            CreateIndex("dbo.Band-Art", "Artista_Id");
            CreateIndex("dbo.Band_Gen", "Band_Id");
            CreateIndex("dbo.Band_Gen", "Genere_Id");
            AddForeignKey("dbo.Art_Strum", "Artista_Id", "dbo.Artista", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Art_Strum", "Strumento_Id", "dbo.Strumento", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Band-Art", "Artista_Id", "dbo.Artista", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Band-Art", "Band_Id", "dbo.Band", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Band_Gen", "Band_Id", "dbo.Band", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Band_Gen", "Genere_Id", "dbo.Genere", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Band_Gen", "Genere_Id", "dbo.Genere");
            DropForeignKey("dbo.Band_Gen", "Band_Id", "dbo.Band");
            DropForeignKey("dbo.Band-Art", "Band_Id", "dbo.Band");
            DropForeignKey("dbo.Band-Art", "Artista_Id", "dbo.Artista");
            DropForeignKey("dbo.Art_Strum", "Strumento_Id", "dbo.Strumento");
            DropForeignKey("dbo.Art_Strum", "Artista_Id", "dbo.Artista");
            DropIndex("dbo.Band_Gen", new[] { "Genere_Id" });
            DropIndex("dbo.Band_Gen", new[] { "Band_Id" });
            DropIndex("dbo.Band-Art", new[] { "Artista_Id" });
            DropIndex("dbo.Band-Art", new[] { "Band_Id" });
            DropIndex("dbo.Art_Strum", new[] { "Strumento_Id" });
            DropIndex("dbo.Art_Strum", new[] { "Artista_Id" });
        }
    }
}

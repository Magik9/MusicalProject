using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using Music.DAL.TablesClasses;


namespace Music.DAL.DBContext
{
    public class MusicContext : DbContext
    {
        public MusicContext() : base("MusicContext")
        {
     
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var conventions = new List<PluralizingTableNameConvention>().ToArray();
            modelBuilder.Conventions.Remove(conventions);
        }

        public DbSet<Brano> Brani { get; set; }
        public DbSet<Disco> Dischi { get; set; }
        public DbSet<Band> Bands { get; set; }
        public DbSet<Genere> Generi { get; set; }
        public DbSet<Artista> Artisti { get; set; }
        public DbSet<Strumento> Strumenti { get; set; }
    }
}
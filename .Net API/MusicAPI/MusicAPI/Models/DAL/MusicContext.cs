using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using MusicAPI.Models.ClassiTabelle;


namespace MusicAPI.Models.DAL
{
	public class MusicContext : DbContext
	{
        public MusicContext() : base("MusicContext")
        {
            
        }

        public DbSet<Brano> Brani { get; set; }
        public DbSet<Disco> Dischi { get; set; }
        public DbSet<Band> Bands { get; set; }

    }
}
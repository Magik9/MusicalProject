using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.DAL.TablesClasses
{
    [Table("Band-Art")]
    public class Band_Art : EntityBase
    {
        [ForeignKey("Band")]
        public int Band_Id { get; set; }
        public virtual Band Band { get; set; }

        [ForeignKey("Artista")]
        public int Artista_Id { get; set; }
        public virtual Artista Artista { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.DAL.TablesClasses
{
    public class Band_Gen : EntityBase
    {
        [ForeignKey("Band")]
        public int Band_Id { get; set; }
        public virtual Band Band { get; set; }

        [ForeignKey("Genere")]
        public int Genere_Id { get; set; }
        public virtual Genere Genere { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.DAL.TablesClasses
{
    public class Art_Strum : EntityBase
    {
        [ForeignKey("Artista")]
        public int Artista_Id { get; set; }
        public virtual Artista Artista { get; set; }

        [ForeignKey("Strumento")]
        public int Strumento_Id { get; set; }
        public virtual Strumento Strumento { get; set; }
    }
}

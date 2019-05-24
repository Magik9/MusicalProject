using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MusicAPI.Models.ClassiTabelle
{
    public class Brano
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string titolo { get; set; }
        public string durata { get; set; }
        public int id_band { get; set; }

        [ForeignKey("Disco")]
        public int Disco_Id { get; set; }
        public virtual Disco Disco { get; set; }
    }
}
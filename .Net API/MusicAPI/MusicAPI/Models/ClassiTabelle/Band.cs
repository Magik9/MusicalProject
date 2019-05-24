using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MusicAPI.Models.ClassiTabelle
{
    public class Band
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id{ get; set; }
        public string nome { get; set; }
        public string genere { get; set; }
        public int nMembri { get; set; }
        public int anno { get; set; }

        public virtual List<Disco> Dischi { get; set; }
    }
}
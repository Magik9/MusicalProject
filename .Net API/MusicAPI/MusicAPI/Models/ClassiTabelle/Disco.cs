using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MusicAPI.Models.ClassiTabelle
{
    public class Disco
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string Titolo { get; set; }
        public int anno { get; set; } 
        public int Band_id { get; set; }

        public virtual ICollection<Brano> Brani { get; set; }
    }
}
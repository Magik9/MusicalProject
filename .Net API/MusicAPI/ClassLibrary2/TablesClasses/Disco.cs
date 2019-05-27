﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MusicAPI.DAL.TablesClasses
{
    public class Disco
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string Titolo { get; set; }
        public int anno { get; set; }

        [ForeignKey("Band")]
        public int Band_id { get; set; }
        public virtual Band Band { get; set; }

        public virtual ICollection<Brano> Brani { get; set; }
    }
}
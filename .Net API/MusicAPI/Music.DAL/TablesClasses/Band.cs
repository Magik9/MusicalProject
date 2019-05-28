using Music.DAL.TablesClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Music.DAL.TablesClasses
{
    [Table("Band")]
    public class Band:EntityBase

    {
        public string Nome { get; set; }
        public string Genere { get; set; }
        public int AnnoFondazione { get; set; }

    }
}
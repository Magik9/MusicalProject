using Music.DAL.TablesClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Music.DAL.TablesClasses
{
    [Table("Disco")]

    public class Disco:EntityBase
    {
        public string Titolo { get; set; }
        public int Anno { get; set; }

        [ForeignKey("Band")]
        public int Band_Id { get; set; }
        public virtual Band Band { get; set; }
    }
}
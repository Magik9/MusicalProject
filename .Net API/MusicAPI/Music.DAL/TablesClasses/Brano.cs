using Music.DAL.TablesClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Music.DAL.TablesClasses
{
    [Table("Brano")]
    public class Brano: EntityBase
    {   
        public string Titolo { get; set; }
        public string Durata { get; set; }
        public int a { get; set; }

        [ForeignKey("Disco")]
        public int Disco_Id { get; set; }
        public virtual Disco Disco { get; set; }

    }
}
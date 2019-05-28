using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.DAL.TablesClasses
{
    [Table("Strumento")]
    public class Strumento : EntityBase
    {
        public string Tipo { get; set; }
    }
}

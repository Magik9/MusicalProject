using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.DAL.TablesClasses
{
    [Table("Genere")]
    public class Genere : EntityBase
    {
        public string Nome { get; set; }
    }
}

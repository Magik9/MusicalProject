using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Music.DAL.TablesClasses
{
    [Table("Disco")]

    public class Disco:EntityBase
    {
        [Required]
        public string Titolo { get; set; }
        
        public int Anno { get; set; }
        public string Image { get; set; }

        [Required]
        [ForeignKey("Band")]
        public int Band_Id { get; set; }
        public virtual Band Band { get; set; }

        public virtual List<Brano> Brani { get; set; }
    }
}
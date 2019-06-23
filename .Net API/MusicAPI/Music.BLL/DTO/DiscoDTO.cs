using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.BLL.DTO
{
    public class DiscoDTO
    {
        public int Id { get; set; }
        public string titolo { get; set; }
        public int anno { get; set; }
        public string band { get; set; }
        public string genere { get; set; }
        public string image { get; set; }
        public int Band_Id { get; set; }
    }
}

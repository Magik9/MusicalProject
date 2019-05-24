using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicAPI.BLL.DTO
{
    public class DiscoDTO
    {
        public int id { get; set; }
        public string Titolo { get; set; }
        public int anno { get; set; }

        public List<BranoDTO> Brani { get; set; }

    }
}

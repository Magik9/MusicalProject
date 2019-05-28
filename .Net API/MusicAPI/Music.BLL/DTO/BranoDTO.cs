using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.BLL.DTO
{
    public class BranoDTO
    {
        public int id { get; set; }
        public string titolo { get; set; }
        public string band { get; set; }
        public string disco { get; set; }
        public int anno { get; set; }
        public string durata { get; set; }
    }
}

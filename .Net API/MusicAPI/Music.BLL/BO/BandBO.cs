using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.BLL.BO
{
    public class BandBO
    {
        public int Id { get; set; }
        public string nome { get; set; }
        public string genere { get; set; }
        public int annoFondazione { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.DAL.TablesClasses
{
    class Band_Art : EntityBase
    {
        public int Band_Id { get; set; }
        public int Artista_Id { get; set; }
    }
}

﻿

using System.Collections.Generic;

namespace MusicAPI.BLL.DTO
{
    public class BandDTO
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string genere { get; set; }
        public int nMembri { get; set; }
        public int anno { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.BLL.BO
{
    public class DiscoBO
    {
        public int Id { get; set; }
        public string titolo { get; set; }
        public int anno { get; set; }
        public string band { get; set; }
        public string genere { get; set; }
    }
}
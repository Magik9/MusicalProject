
using AutoMapper;
using System.Collections.Generic;
using Music.DAL.TablesClasses;

namespace Music.BLL.DTO
{
    public class BandDTO
    {
        public int Id { get; set; }
        public string nome { get; set; }
        public string genere { get; set; }
        public int annoFondazione { get; set; }


    }
}

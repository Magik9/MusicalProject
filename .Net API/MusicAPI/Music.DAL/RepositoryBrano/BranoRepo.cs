using Music.DAL.DBContext;
using Music.DAL.TablesClasses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Music.DAL.RepositoryBrano
{
    public class BranoRepo
    {
        private MusicContext _context = null;

        public BranoRepo(MusicContext context)
        {
            _context = context;
        }

        public Brano GetSingleBrano(int id)
        {
            return _context.Brani.SingleOrDefault(b => b.Id == id);
        }

        public List<Brano> GetBraniDisco(int id)
        {
            return _context.Dischi.SingleOrDefault(x => x.Id == id).Brani.ToList();
        }

        public List<Brano> GetBrani()
        {
            return _context.Brani.ToList();
        }

        public void SaveNewBrano(Brano brano)
        {
            brano.CreatedOn = DateTime.Now;
            brano.ModifiedOn = DateTime.Now;

            _context.Brani.Add(brano);
            _context.SaveChanges();
        }

        public void UpdateSingleBrano(Brano brano)
        {
            brano.ModifiedOn = DateTime.Now;
            _context.SaveChanges();
        }

        public void DeleteSingleBrano(int id)
        {
            var brano = _context.Brani.FirstOrDefault(b => b.Id == id);
            _context.Brani.Remove(brano);
            _context.SaveChanges();
        }
    }
}

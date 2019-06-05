using Music.DAL.DBContext;
using Music.DAL.TablesClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.DAL.RepositoryDisco
{
    public class DiscoRepo
    {
        private MusicContext _context = null;

        public DiscoRepo(MusicContext context)
        {
            _context = context;
        }

        public Disco GetSingleDisco(int id)
        {
                return _context.Dischi.SingleOrDefault(d => d.Id == id);
        }

        public List<Disco> GetDischi()
        {
            return _context.Dischi.ToList();
        }

        public List<Disco> GetDischiBand(int id)
        {
            return _context.Bands.SingleOrDefault(x => x.Id == id)
                      .Dischi.ToList();
        }

        public void MoveDisco(int fromId, int toId)
        {
            _context.Dischi.SingleOrDefault(x => x.Id == fromId)
                .Brani.ForEach(y => y.Disco_Id = toId);

            _context.SaveChanges();
        }

        public void SaveNewDisco(Disco disco)
        {
            disco.CreatedOn = DateTime.Now;
            disco.ModifiedOn = DateTime.Now;
            
            _context.Dischi.Add(disco);
            _context.SaveChanges();
        }

        public void UpdateDisco(Disco disco)
        {
            disco.ModifiedOn = DateTime.Now;

            _context.SaveChanges();
        }

        public void DeleteDisco(int id)
        {
            _context.Dischi.Remove(_context.Dischi.FirstOrDefault(x => x.Id == id));
            _context.SaveChanges();
        }
    }
}

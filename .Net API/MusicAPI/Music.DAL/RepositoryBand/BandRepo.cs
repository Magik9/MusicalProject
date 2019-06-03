using Music.DAL.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Music.DAL.TablesClasses;

namespace Music.DAL.RepositoryBand
{
    public class BandRepo
    {
        private MusicContext _context = null;

        public BandRepo(MusicContext context)
        {
            _context = context;
        }

        public Band GetSingleBand(int id)
        {
            return _context.Bands.FirstOrDefault(d => d.Id == id);
        }

        public List<Band> GetBands()
        {
            return _context.Bands.ToList();
        }

        public void SaveNewBand(Band band)
        {
            band.CreatedOn = DateTime.Now;
            band.ModifiedOn = DateTime.Now;

            _context.Bands.Add(band);
            _context.SaveChanges();
        }

        public void UpdateBand(Band band)
        {
            band.ModifiedOn = DateTime.Now;

            _context.SaveChanges();
        }

        public void MoveBand(int fromId, int toId)
        {
            _context.Bands.SingleOrDefault(x => x.Id == fromId)
                .Dischi.ForEach(y => y.Band_Id = toId);

            _context.SaveChanges();
        }

        public void DeleteBand(int id)
        {
                _context.Bands.Remove(_context.Bands.FirstOrDefault(x => x.Id == id));
                _context.SaveChanges();
        }
    }
}

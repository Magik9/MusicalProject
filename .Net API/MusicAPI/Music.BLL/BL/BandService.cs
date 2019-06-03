using AutoMapper;
using Music.BLL.DTO;
using Music.DAL.DBContext;
using Music.DAL.TablesClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using Music.DAL.RepositoryBand;


namespace Music.BLL.BL
{
    public class BandService
    {
        private BandRepo _bandRepo = null;

        public BandService(BandRepo bandRepo)
        {
            _bandRepo = bandRepo;
        }

        public BandDTO GetBand(int id)
        {
            Band band = _bandRepo.GetSingleBand(id);

            return Mapper.Map<BandDTO>(band);
        }

        public List<BandDTO> GetBands()
        {
            List<BandDTO> bands = _bandRepo.GetBands()
                .Select(x => Mapper.Map<BandDTO>(x)).ToList();

            return bands;
        }

        public void UpdateBandOnDB(BandDTO bandDTO)
        {
            Band band = _bandRepo.GetSingleBand(bandDTO.Id);
            Mapper.Map(bandDTO, band);

            _bandRepo.UpdateBand(band);
        }

        public Band BandFrom(BandDTO bandDTO)
        {
            Band band = new Band();
            Mapper.Map(bandDTO, band);

            return band;
        }

        public Band AddBandIfNotExist(BandDTO bandDTO)
        {
            Band band = _bandRepo.GetBands()
              .FirstOrDefault(x =>
              string.Equals(x.Nome, bandDTO.nome, StringComparison.OrdinalIgnoreCase));

            if (band == null)
            {
                band = BandFrom(bandDTO);
                _bandRepo.SaveNewBand(band);

                return null;
            }
            return band;
        }

        public void UpdateBand(BandDTO bandDTO)
        {
                Band band = _bandRepo.GetBands()
                  .SingleOrDefault(x => x.Nome == bandDTO.nome && x.Id != bandDTO.Id);
                if (band == null)
                    UpdateBandOnDB(bandDTO);
                else
                    _bandRepo.MoveBand(bandDTO.Id, band.Id);
        }

        public void DeleteBand(int id)
        {
            _bandRepo.DeleteBand(id);
        }

    }
}

using AutoMapper;
using Music.BLL.BO;
using Music.BLL.DTO;
using Music.DAL.RepositoryBand;
using Music.DAL.RepositoryDisco;
using Music.DAL.TablesClasses;
using System.Collections.Generic;
using System.Linq;


namespace Music.BLL.BL
{
    public class DiscoService
    {
        private DiscoRepo _discoRepo = null;
        private BandService _bandService = null;
        private BandRepo _bandRepo = null;

        public DiscoService(DiscoRepo ilmiodiscoRepo, BandService bandService, BandRepo bandRepo)
        {
            _discoRepo = ilmiodiscoRepo;
            _bandService = bandService;
            _bandRepo = bandRepo;
        }

        public DiscoDTO GetDisco(int id)
        {
            Disco disco = _discoRepo.GetSingleDisco(id);

            return Mapper.Map<DiscoDTO>(disco);
        }

        public List<DiscoDTO> GetDischi()
        {
            List<DiscoDTO> dischi = _discoRepo.GetDischi()
                .Select(x => Mapper.Map<DiscoDTO>(x)).ToList();

            return dischi;
        }

        public List<DiscoDTO> GetDischiBand(int id)
        {
            List<DiscoDTO> dischi = _discoRepo.GetDischiBand(id)
                .Select(x => Mapper.Map<DiscoDTO>(x)).ToList();

            return dischi;
        }

        public Disco AddDiscoIfNotExist(Disco newDisco)
        {
            Band band = _bandService.AddBandIfNotExist(newDisco.Band);
            if (band != null)
            {
                var d = _bandRepo.GetSingleBand(band.Id)
                    .Dischi.SingleOrDefault(x => x.Titolo == newDisco.Titolo);

                if (d != null)
                    return d;

                newDisco.Band_Id = band.Id;
            }
            else
                newDisco.Band_Id = _bandRepo.GetBands().Last().Id;
            newDisco.Band = null;
            _discoRepo.SaveNewDisco(newDisco);

            return null;
        }

        public void UpdateDiscoOnDB(DiscoBO discoBO)
        {
            Disco oldDisco = _discoRepo.GetDischi().SingleOrDefault(x => x.Id == discoBO.Id);
            Mapper.Map(discoBO, oldDisco);

            _discoRepo.UpdateDisco(oldDisco);
        }

        public void UpdateDisco(DiscoBO discoBO)
        {
            Band band = new Band();
            band.Nome = discoBO.band;
            band = _bandService.AddBandIfNotExist(band);
            Disco disco = _discoRepo.GetSingleDisco(discoBO.Id);

            if (band != null) //se la band esiste gia
            {
                var d = _bandRepo.GetSingleBand(band.Id)
                     .Dischi.SingleOrDefault(x => x.Titolo == discoBO.titolo && x.Id != discoBO.Id);

                if (d == null)
                {
                    disco.Band_Id = band.Id;
                }
                else
                {
                    _discoRepo.MoveDisco(discoBO.Id, d.Id);
                }
            }
            else
            {
                disco.Band_Id = _bandRepo.GetBands().Last().Id;
            }

            disco.Titolo = discoBO.titolo;   
            _discoRepo.UpdateDisco(disco);
        }

        public void DeleteDisco(int id)
        {
            _discoRepo.DeleteDisco(id);
        }

    }
}

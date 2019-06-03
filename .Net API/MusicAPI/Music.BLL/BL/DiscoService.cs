using AutoMapper;
using Music.BLL.DTO;
using Music.DAL.DBContext;
using Music.DAL.RepositoryBand;
using Music.DAL.RepositoryDisco;
using Music.DAL.TablesClasses;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Music.BLL.BL
{

    public class DiscoService
    {
        private DiscoRepo _discoRepo = null;
        private BandService _bandService = null;
        private BandRepo _bandRepo = null;

        public DiscoService(DiscoRepo discoRepo, BandService bandService, BandRepo bandRepo)
        {
            _discoRepo = discoRepo;
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

        public void UpdateDiscoOnDB(DiscoDTO discoDTO)
        {
            Disco oldDisco = _discoRepo.GetDischi().SingleOrDefault(x => x.Id == discoDTO.Id);
            Mapper.Map(discoDTO, oldDisco);

            _discoRepo.UpdateDisco(oldDisco);
        }

        public Disco AddDiscoIfNotExist(DiscoDTO discoDTO)
        {
            Disco disco = new Disco();
            BandDTO bandDTO = Mapper.Map<BandDTO>(discoDTO);
            Band band = _bandService.AddBandIfNotExist(bandDTO);
            if (band != null)
            {
                var d = _bandRepo.GetSingleBand(band.Id)
                    .Dischi.SingleOrDefault(x => x.Titolo == discoDTO.titolo && x.Id != discoDTO.Id);

                if (d == null)
                    discoDTO.Band_Id = band.Id;
                else
                    return d;
            }
            else
                discoDTO.Band_Id = _bandRepo.GetBands().Last().Id;

            Mapper.Map(discoDTO, disco);
            _discoRepo.SaveNewDisco(disco);

            return null;
        }

        public void UpdateDisco(DiscoDTO discoDTO)
        {
             BandDTO bandDTO = Mapper.Map<BandDTO>(discoDTO);
             Band band = _bandService.AddBandIfNotExist(bandDTO);
             if (band != null) //se la band esiste gia
             {
                var d = _bandRepo.GetSingleBand(band.Id)
                     .Dischi.SingleOrDefault(x => x.Titolo == discoDTO.titolo && x.Id != discoDTO.Id);

                if (d == null)
                    discoDTO.Band_Id = band.Id;
                else
                    _discoRepo.MoveDisco(discoDTO.Id, d.Id);
             }
             else
                discoDTO.Band_Id = _bandRepo.GetBands().Last().Id;

             UpdateDiscoOnDB(discoDTO);
        }

        public void DeleteDisco(int id)
        {
            _discoRepo.DeleteDisco(id);
        }

    }
}

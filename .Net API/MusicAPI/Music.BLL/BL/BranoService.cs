using AutoMapper;
using Music.BLL.DTO;
using Music.DAL.DBContext;
using Music.DAL.RepositoryBrano;
using Music.DAL.RepositoryDisco;
using Music.DAL.TablesClasses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Music.BLL.BL
{
    public class BranoService
    {
        private BranoRepo _branoRepo = null;
        private DiscoRepo _discoRepo = null;
        private DiscoService _discoService = null;

        public BranoService(BranoRepo branoRepo, DiscoRepo discoRepo, DiscoService discoService)
        {
            _branoRepo = branoRepo;
            _discoRepo = discoRepo;
            _discoService = discoService;
        }

        public BranoDTO GetBrano(int id)
        {
            Brano brano = _branoRepo.GetSingleBrano(id);
            
            return Mapper.Map<BranoDTO>(brano);
        }

        public List<BranoDTO> GetBrani()
        {
            List<BranoDTO> brani = _branoRepo.GetBrani()
                .Select(x => Mapper.Map<BranoDTO>(x)).ToList();

            return brani;
        }

        public List<BranoDTO> GetBraniDisco(int id)
        {
            List<BranoDTO> brani = _branoRepo.GetBraniDisco(id)
                .Select(x => Mapper.Map<BranoDTO>(x)).ToList();

            return brani;
        }

        public Brano BranoFrom(BranoDTO branoDTO)
        {
            Brano brano = new Brano();
            Mapper.Map(branoDTO, brano);

            return brano;
        }

        public void AddNewBrano(BranoDTO branoDTO)
        {
            if (!string.IsNullOrEmpty(branoDTO.disco) && !string.IsNullOrEmpty(branoDTO.band))
            {
                DiscoDTO discoDTO = Mapper.Map<DiscoDTO>(branoDTO);
                Disco disco = _discoService.AddDiscoIfNotExist(discoDTO);

                branoDTO.Disco_Id =
                    disco != null
                    ?
                    disco.Id
                    :
                    _discoRepo.GetDischi().Last().Id;

                Brano brano = BranoFrom(branoDTO);
                _branoRepo.SaveNewBrano(brano);
            }
        }
        
        public void UpdateBrano(BranoDTO branoDTO)
        {
            Brano brano = _branoRepo.GetSingleBrano(branoDTO.id);
            Disco disco = _discoRepo.GetDischi().FirstOrDefault(d => d.Titolo == branoDTO.disco);
            if (disco != null)
                brano.Disco_Id = disco.Id;

            brano.Titolo = branoDTO.titolo;
            brano.Durata = branoDTO.durata;

            _branoRepo.UpdateSingleBrano(brano);
        }

        public void DeleteBrano(int id)
        {
            _branoRepo.DeleteSingleBrano(id);
        }
    }
}

using AutoMapper;
using Music.BLL.BO;
using Music.BLL.DTO;
using Music.DAL.RepositoryBrano;
using Music.DAL.RepositoryDisco;
using Music.DAL.TablesClasses;
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

        public Brano BranoFrom(BranoBO branoBO)
        {
            Brano brano = new Brano();
            Mapper.Map(branoBO, brano);

            return brano;
        }

        public void AddNewBrano(BranoBO branoBO)
        {
            if (!string.IsNullOrEmpty(branoBO.disco) && !string.IsNullOrEmpty(branoBO.band))
            {
                Disco newDisco = Mapper.Map<Disco>(branoBO);
                Disco disco = _discoService.AddDiscoIfNotExist(newDisco);

                Brano brano = BranoFrom(branoBO);

                brano.Disco_Id =
                    disco != null
                    ?
                    disco.Id
                    :
                    _discoRepo.GetDischi().Last().Id;

                _branoRepo.SaveNewBrano(brano);
            }
        }
        
        public void UpdateBrano(BranoDTO branoDTO)
        {
            Brano brano = _branoRepo.GetSingleBrano(branoDTO.id);
            Disco disco = _discoRepo.GetDischi().SingleOrDefault(d => d.Titolo == branoDTO.disco && d.Band.Nome == branoDTO.band);
            if (disco != null)
                _branoRepo.GetSingleBrano(branoDTO.id).Disco_Id = disco.Id;

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

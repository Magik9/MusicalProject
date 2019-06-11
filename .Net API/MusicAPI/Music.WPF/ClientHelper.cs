using APIClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Music.WPF
{
    public class ClientHelper
    {
        private BranoClient BranoClient;
        private DiscoClient DiscoClient;

        public ClientHelper()
        {
            BranoClient = new BranoClient(new HttpClient());
            DiscoClient = new DiscoClient(new HttpClient());
        }


        public async Task<List<BranoDTO>> LoadBrani()
        {
            var Task = await BranoClient.ListaBraniAsync();
            return Task.ToList();
        }


        public async Task<List<BranoDTO>> LoadBraniDisco(int id)
        {
            var Task = await BranoClient.BraniDiscoAsync(id);
            return Task.ToList(); 
        }



        public void AddBrano(BranoBO BO)
        {
            BranoClient.AddBranoAsync(BO);
        }



        public void UpdateBrano(BranoDTO DTO)
        {
            BranoClient.UpdateBranoAsync(Map(DTO));
        }



        public void DeleteBrano(int id)
        {
            BranoClient.DeleteBranoAsync(id);
        }




        public async Task<List<DiscoDTO>> LoadDischi()
        {
            var Task = await DiscoClient.ListaDischiAllAsync();
            return Task.ToList();
        }



        private BranoBO Map(BranoDTO DTO)
        {
            return new BranoBO
            {
                Id = DTO.Id,
                Titolo = DTO.Titolo,
                Disco = DTO.Disco,
                Band = DTO.Band,
                Anno = DTO.Anno,
                Durata = DTO.Durata
            };
        }
    }
}

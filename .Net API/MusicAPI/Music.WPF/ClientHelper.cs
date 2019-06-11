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

        public ClientHelper()
        {
            BranoClient = new BranoClient(new HttpClient());
        }


        public async Task<List<BranoDTO>> LoadBrani()
        {
            var Task = await BranoClient.ListaBraniAsync();
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

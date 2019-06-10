using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Windows.Controls.Primitives;
using APIClient;
using Music.WPF.MyDataGrid;

namespace Music.WPF
{
    public class MainWindowModel
    {
        private HttpClient _client = null;
        private BranoClient _branoClient = null;
        public XDataGrid grid;

        public HttpClient Client
        {
            get => _client;
            set
            {
                _client = value;
            }
        }

        public BranoClient BranoClient
        {
            get => _branoClient;
            set
            {
                _branoClient = value;
            }
        }

        private List<BranoDTO> _brani = null;

        public List<BranoDTO> Brani
        {
            get => _brani;
            set
            {
                _brani = value;
                if (grid != null)
                    grid.ItemsSource = Brani;
            }
        }


        public MainWindowModel()
        {
            _client = new HttpClient();
            _branoClient = new BranoClient(_client);
            Brani = new List<BranoDTO>();

            grid = new XDataGrid();
            grid.UpdateHappened += new EventHandler(update_eventHandler);
            grid.DeleteHappened += new EventHandler(delete_eventHandler);
        }



        public async void LoadBrani()
        {
            var Task = await BranoClient.ListaBraniAsync();
            Brani = Task.ToList();
        }



        private void update_eventHandler(object sender, EventArgs e)
        {
            var row = ((ButtonBase)sender).DataContext as BranoDTO;
            BranoClient.UpdateBranoAsync(Map(row));
        }



        private void delete_eventHandler(object sender, EventArgs e)
        {
            var row = ((ButtonBase)sender).DataContext as BranoDTO;
            BranoClient.DeleteBranoAsync(row.Id.Value);
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using APIClient;
using Music.WPF.AddBranoWindow;
using Music.WPF.MyDataGrid;

namespace Music.WPF
{
    public class MainWindowModel
    {
        private ClientHelper ClientHelper;

        public XDataGrid grid;

        private List<BranoDTO> _brani;

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
            this.ClientHelper = new ClientHelper();
            
            Brani = new List<BranoDTO>();

            grid = new XDataGrid();
            grid.UpdateHappened += new RoutedEventHandler(update_eventHandler);
            grid.DeleteHappened += new RoutedEventHandler(delete_eventHandler);
        }



        private void addBrano_Event(object sender, RoutedEventArgs e)
        {
            var branoBO = ((CreateBranoWindow)sender).BO;
            ClientHelper.AddBrano(branoBO);
        }



        private void update_eventHandler(object sender, RoutedEventArgs e)
        {
            var DTO = ((ButtonBase)sender).DataContext as BranoDTO;
            ClientHelper.UpdateBrano(DTO);
        }



        private void delete_eventHandler(object sender, EventArgs e)
        {
            var row = ((ButtonBase)sender).DataContext as BranoDTO;
            ClientHelper.DeleteBrano(row.Id.Value);
        }



        public void ShowCreateBranoView(MainWindow owner)
        {
            var inputBranoView = new CreateBranoWindow(owner);
            inputBranoView.addBranoEvent += new RoutedEventHandler(addBrano_Event);
            inputBranoView.Show();
        }


    }
}

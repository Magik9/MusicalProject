using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public class MainWindowModel : INotifyPropertyChanged
    {
        private ClientHelper ClientHelper;

        public XDataGrid gridBrani;

        private List<BranoDTO> _brani;

        public List<BranoDTO> Brani
        {
            get => _brani;
            set
            {
                _brani = value;
                if (gridBrani != null)
                    gridBrani.ItemsSource = Brani;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private List<DiscoDTO> _dischi;

        public List<DiscoDTO> Dischi
        {
            get => _dischi;
            set
            {
                _dischi = value;
                OnPropertyChanged("Dischi");
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public MainWindowModel()
        {
            this.ClientHelper = new ClientHelper();
            
            Brani = new List<BranoDTO>();

            gridBrani = new XDataGrid();
            
            gridBrani.UpdateHappened += new RoutedEventHandler(update_eventHandler);
            gridBrani.DeleteHappened += new RoutedEventHandler(delete_eventHandler);
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

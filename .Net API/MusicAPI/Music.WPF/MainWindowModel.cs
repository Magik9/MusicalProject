using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using Client;
using Music.WPF.AddBranoWindow;
using Music.WPF.Commands;
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


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public MainWindowModel()
        {
            this.ClientHelper = new ClientHelper();
            
            Brani = new List<BranoDTO>();

            gridBrani = new XDataGrid();
        }


        public ICommand AddBranoCommand => new RelayCommand(o => Add_Click(o), o => true);

        private void Add_Click(object sender)
        {

            var inputBranoView = new CreateBranoWindow(sender);
            inputBranoView.Show();

        }


        public ICommand LoadBraniCommand => new RelayCommand(o => LoadBrani_Click(o), o => true);

        private async void LoadBrani_Click(object sender)
        {

            Brani = await ClientHelper.LoadBrani();

            MainWindow mainWindow = sender as MainWindow;
            mainWindow.braniPanel.Visibility = Visibility.Visible;
            RenderGrid(gridBrani);

        }


        public ICommand LoadDischiCommand => new RelayCommand(o => LoadDischi_Click(o), o => true);

        private async void LoadDischi_Click(object sender)
        {

            Dischi = await ClientHelper.LoadDischi();

            MainWindow mainWindow = sender as MainWindow;
            mainWindow.discoPanel.Visibility = Visibility.Visible;
            RenderGrid(mainWindow.dischiGrid);

        }


        public void RenderGrid(DataGrid grid)
        {
            Storyboard sb = new Storyboard();
            DoubleAnimation da = new DoubleAnimation();

            da.From = grid.ActualHeight;
            da.To = (grid.Items.Count + 1) * 30.10;
            da.Duration = new Duration(TimeSpan.FromSeconds(0.2));
            Storyboard.SetTargetProperty(da, new PropertyPath(FrameworkElement.HeightProperty));
            sb.Children.Add(da);
            grid.BeginStoryboard(sb);
            grid.VerticalScrollBarVisibility = ScrollBarVisibility.Disabled;
        }

    }
}

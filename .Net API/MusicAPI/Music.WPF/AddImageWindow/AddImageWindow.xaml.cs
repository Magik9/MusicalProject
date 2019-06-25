using Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Music.WPF.AddImageWindow
{
    /// <summary>
    /// Logica di interazione per AddImageWindow.xaml
    /// </summary>
    public partial class AddImageWindow : Window, INotifyPropertyChanged
    {
        private MainWindowModel _model;

        private DataGrid _dischiGrid;

        private DiscoDTO _discoItem;

        private string _imageDropped;

        public string ImageDropped
        {
            get => _imageDropped;

            set
            {
                _imageDropped = value;
                OnPropertyChanged("ImageDropped");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public AddImageWindow(object parameter)
        {
            InitializeComponent();
            DataContext = this;

            object[] parameters = (object[])parameter;
            _model = (MainWindowModel)parameters[0];
            _dischiGrid = (DataGrid)parameters[1];
            _discoItem = parameters[2] as DiscoDTO;
        }



        private void DropPanel_Drop(object sender, DragEventArgs e)
        {
            e.Handled = true;
            ImageDropped = e.Data.GetData("Text") as string;
        }


        private void AddImage_Event(object sender, RoutedEventArgs e)
        {
            _discoItem.Img = ImageDropped;
            DiscoDTO disco = _model.Dischi.FirstOrDefault(x => x.Id == _discoItem.Id);
            disco.Img = _discoItem.Img;
            //_dischiGrid.ItemsSource = _model.Dischi;
            _model.OnPropertyChanged("Dischi");
        }
    }
}

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

        public AddImageWindow(object selectedItem)
        {
            InitializeComponent();
            DataContext = this;

            _discoItem = selectedItem as DiscoDTO;
        }



        private void DropPanel_Drop(object sender, DragEventArgs e)
        {
            e.Handled = true;
            ImageDropped = e.Data.GetData("Text") as string;
        }


        private void AddImage_Event(object sender, RoutedEventArgs e)
        {
            _discoItem.Img = ImageDropped;
        }
    }
}

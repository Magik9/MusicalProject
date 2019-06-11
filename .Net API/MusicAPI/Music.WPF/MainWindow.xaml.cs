using APIClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using Music.WPF.MyDataGrid;
using Music.WPF.AddBranoWindow;
using System.Drawing;
using System.Windows.Media;

namespace Music.WPF
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowModel model;
        private ClientHelper clientHelper;


        public MainWindow()
        {

            InitializeComponent();
            this.WindowState = WindowState.Maximized;
            MenuDirection();
            DataContext = new MainWindowModel();
            model = DataContext as MainWindowModel;

            braniPanel.Children.Add(model.gridBrani);

            clientHelper = new ClientHelper();

        }


 
        private async void Load_Click(object sender, RoutedEventArgs e)
        {

            model.Brani = await clientHelper.LoadBrani();

        }


        private void NewBrano_Click(object sender, RoutedEventArgs e)
        {

            model.ShowCreateBranoView(this);

        }


        private async void LoadDischi_Click(object sender, RoutedEventArgs e)
        {
            model.Dischi = await clientHelper.LoadDischi();
        }



        private void MenuDirection()
        {
            var ifLeft = SystemParameters.MenuDropAlignment;
            if (ifLeft)
            {
                // change to false
                var t = typeof(SystemParameters);
                var field = t.GetField("_menuDropAlignment", BindingFlags.NonPublic | BindingFlags.Static);
                field.SetValue(null, false);
                ifLeft = SystemParameters.MenuDropAlignment;
            }
        }


        private async void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid grid = (DataGrid)sender;
            DataGridRow Row = (DataGridRow)grid.ItemContainerGenerator.ContainerFromIndex(grid.SelectedIndex);
            int id = int.Parse((grid.SelectedCells[0].Column.GetCellContent(Row.Item) as TextBlock).Text);
            model.Brani = await clientHelper.LoadBraniDisco(id);
        }
    }
}

using Client;
using Music.WPF.AddBranoWindow;
using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

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
            WindowState = WindowState.Maximized;
            MenuDirection();
            DataContext = new MainWindowModel();
            model = DataContext as MainWindowModel;

            braniPanel.Children.Add(model.gridBrani);

            clientHelper = new ClientHelper();

        }


        private void Add_Click(object sender, RoutedEventArgs e)
        {

            var inputBranoView = new CreateBranoWindow(this);
            inputBranoView.Show();

        }


        private async void Load_Click(object sender, RoutedEventArgs e)
        {

            model.Brani = await clientHelper.LoadBrani();
            braniPanel.Visibility = Visibility.Visible;

            model.RenderGrid(model.gridBrani);

        }


        private async void LoadDischi_Click(object sender, RoutedEventArgs e)
        {
            
            model.Dischi = await clientHelper.LoadDischi();
            discoPanel.Visibility = Visibility.Visible;

            model.RenderGrid(dischiGrid);

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

    }
}

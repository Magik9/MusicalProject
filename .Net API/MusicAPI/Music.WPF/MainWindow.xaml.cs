using APIClient;
using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media.Animation;
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
        private Storyboard sb = new Storyboard();
        private DoubleAnimation da = new DoubleAnimation();
        private DispatcherTimer timer;

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

            model.ShowCreateBranoView(this);

        }



        private async void Load_Click(object sender, RoutedEventArgs e)
        {

            model.Brani = await clientHelper.LoadBrani();
            braniPanel.Visibility = Visibility.Visible;

            model.RenderGrid(model.gridBrani, sb, da);

        }


        private async void LoadDischi_Click(object sender, RoutedEventArgs e)
        {
            
            model.Dischi = await clientHelper.LoadDischi();
            discoPanel.Visibility = Visibility.Visible;

            model.RenderGrid(dischiGrid, sb, da);

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


        private void Show_PopupToolTip(object sender, MouseEventArgs e)
        {
            DataGridRow row = e.Source as DataGridRow;

            var x = (ToolTip)row.ToolTip;

            x.Placement = PlacementMode.MousePoint;
        }


        private void Hide_PopupToolTip(object sender, MouseEventArgs e)
        {
            DataGridRow row = e.Source as DataGridRow;

            var x = row.ToolTip as ToolTip;

            x.IsOpen = false;
        }

        

    }
}

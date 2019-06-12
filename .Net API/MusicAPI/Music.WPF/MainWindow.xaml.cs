using System.Reflection;
using System.Windows;
using System.Windows.Controls;

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


 
        private async void Load_Click(object sender, RoutedEventArgs e)
        {

            model.Brani = await clientHelper.LoadBrani();
            braniPanel.Visibility = Visibility.Visible;

        }


        private void NewBrano_Click(object sender, RoutedEventArgs e)
        {

            model.ShowCreateBranoView(this);
            
        }


        private async void LoadDischi_Click(object sender, RoutedEventArgs e)
        {

            model.Dischi = await clientHelper.LoadDischi();
            discoPanel.Visibility = Visibility.Visible;

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

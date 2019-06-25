using Client;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace Music.WPF.AddBranoWindow
{
    public partial class CreateBranoWindow : Window
    {
        private BranoBO BO;
        
        public CreateBranoWindow(MainWindow owner)
        {
            InitializeComponent();
            this.Owner = owner;
            CenterWindowOnScreen();
        }



        private void btnDialogOk_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Are you sure?", "Delete Confirmation", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                BO = GetInput();
                ClientHelper helper = new ClientHelper();
                helper.AddBrano(BO);
            }
            Close();
        }


        private void addBrano_Event(object sender, RoutedEventArgs e)
        {
            
        }


        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void TxtTitolo_GotFocus(object sender, RoutedEventArgs e)
        {

            if (((TextBox)sender).Text == "Titolo")
                ((TextBox)sender).Clear();

        }

        private void TxtTitolo_LostFocus(object sender, RoutedEventArgs e)
        {

            if (((TextBox)sender).Text == "")
            {
                ((TextBox)sender).Text = "Titolo";
            }

        }

        private void TxtDisco_GotFocus(object sender, RoutedEventArgs e)
        {

            if (((TextBox)sender).Text == "Disco")
                ((TextBox)sender).Clear();

        }

        private void TxtDisco_LostFocus(object sender, RoutedEventArgs e)
        {

            if (((TextBox)sender).Text == "")
            {
                ((TextBox)sender).Text = "Disco";
            }

        }


        private void TxtBand_GotFocus(object sender, RoutedEventArgs e)
        {

            if (((TextBox)sender).Text == "Band")
                ((TextBox)sender).Clear();

        }

        private void TxtBand_LostFocus(object sender, RoutedEventArgs e)
        {

            if (((TextBox)sender).Text == "")
            {
                ((TextBox)sender).Text = "Band";
            }

        }


        private void TxtAnno_GotFocus(object sender, RoutedEventArgs e)
        {

            if (((TextBox)sender).Text == "Anno")
                ((TextBox)sender).Clear();

        }

        private void TxtAnno_LostFocus(object sender, RoutedEventArgs e)
        {

            if (((TextBox)sender).Text == "")
            {
                ((TextBox)sender).Text = "Anno";
            }

        }


        private void TxtDurata_GotFocus(object sender, RoutedEventArgs e)
        {

            if (((TextBox)sender).Text == "Durata")
                ((TextBox)sender).Clear();

        }

        private void TxtDurata_LostFocus(object sender, RoutedEventArgs e)
        {

            if (((TextBox)sender).Text == "")
            {
                ((TextBox)sender).Text = "Durata";
            }

        }


        private BranoBO GetInput()
        {
            return new BranoBO
            {
                Titolo = txtTitolo.Text,
                Disco = txtDisco.Text,
                Band = txtBand.Text,
                Anno = int.Parse(txtAnno.Text),
                Durata = txtDurata.Text
            };
        }


        private void CenterWindowOnScreen()
        {
            double screenWidth = SystemParameters.PrimaryScreenWidth;
            double screenHeight = SystemParameters.PrimaryScreenHeight;
            double windowWidth = this.Width;
            double windowHeight = this.Height;
            this.Left = (screenWidth / 2) - (windowWidth / 2);
            this.Top = (screenHeight / 2) - (windowHeight / 2);
        }


        protected override void OnClosing(CancelEventArgs e)
        {

            base.OnClosing(e);
            if (!e.Cancel && this.Owner != null) this.Owner.Focus();

        }

    }
}

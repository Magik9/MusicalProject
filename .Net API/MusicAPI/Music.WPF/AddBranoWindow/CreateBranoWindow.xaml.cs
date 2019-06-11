using APIClient;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace Music.WPF.AddBranoWindow
{
    /// <summary>
    /// Logica di interazione per CreateBranoWindow.xaml
    /// </summary>
    public partial class CreateBranoWindow : Window
    {
        public BranoBO BO { get; private set; }
        
        public CreateBranoWindow(MainWindow owner)
        {
            InitializeComponent();
            this.Owner = owner;
            CenterWindowOnScreen();
        }

        public RoutedEventHandler addBranoEvent;

        private void btnDialogOk_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Are you sure?", "Delete Confirmation", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                BO = GetInput();
                addBranoEvent?.Invoke(this, e);
            }
            Close();
        }


        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void TxtTitolo_GotFocus(object sender, RoutedEventArgs e)
        {
            ((TextBox)sender).Clear();
        }


        private void TxtDisco_GotFocus(object sender, RoutedEventArgs e)
        {
            ((TextBox)sender).Clear();
        }


        private void TxtBand_GotFocus(object sender, RoutedEventArgs e)
        {
            ((TextBox)sender).Clear();
        }


        private void TxtAnno_GotFocus(object sender, RoutedEventArgs e)
        {
            ((TextBox)sender).Clear();
        }


        private void TxtDurata_GotFocus(object sender, RoutedEventArgs e)
        {
            ((TextBox)sender).Clear();
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

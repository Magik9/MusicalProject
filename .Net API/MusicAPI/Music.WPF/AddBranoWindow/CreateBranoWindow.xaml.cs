
using APIClient;
using System;
using System.Windows;


namespace Music.WPF.AddBranoWindow
{
    /// <summary>
    /// Logica di interazione per CreateBranoWindow.xaml
    /// </summary>
    public partial class CreateBranoWindow : Window
    {
        public BranoBO branoBO { get; private set; }
        
        public CreateBranoWindow()
        {
            InitializeComponent();
        }

        public EventHandler addBranoEvent;

        private void btnDialogOk_Click(object sender, RoutedEventArgs e)
        {
            branoBO = new BranoBO
            {
                Titolo = txtTitolo.Text,
                Disco = txtDisco.Text,
                Band = txtBand.Text,
                Anno = int.Parse(txtAnno.Text),
                Durata = txtDurata.Text
            };

            addBranoEvent?.Invoke(this, e);
        }
    }
}

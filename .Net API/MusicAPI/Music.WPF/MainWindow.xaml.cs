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

namespace Music.WPF
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowModel model;



        public MainWindow()
        {
            InitializeComponent();

            DataContext = new MainWindowModel();

            model = DataContext as MainWindowModel;

            DockPanel mainPanel = MainPanel;

            mainPanel.Children.Add(model.grid);

            MenuDirection();

            this.WindowState = WindowState.Maximized;
        }

        

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            model.LoadBrani();
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

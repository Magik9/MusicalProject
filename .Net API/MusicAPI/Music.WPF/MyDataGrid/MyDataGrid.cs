﻿using Client;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Music.WPF.MyDataGrid
{
    public class XDataGrid : DataGrid
    {
        private bool isManualEditCommit;

        public XDataGrid()
        {
            AutoGenerateColumns = false;
            HorizontalAlignment = HorizontalAlignment.Left;
            RowHeaderWidth = 0;
            CanUserAddRows = false;
            FontSize = 17;
            Margin = new Thickness(0, 10, 10, 0);
            Background = Brushes.White;

            CreateTextColumn("Id", "Id");
            CreateTextColumn("Titolo", "Titolo");
            CreateTextColumn("Disco", "Disco");
            CreateTextColumn("Band", "Band");
            CreateTextColumn("Anno", "Anno");
            CreateTextColumn("Durata", "Durata");

            CreateButtonColumn("Update", "pack://application:,,,/Img/save-button.png")
                .AddHandler(ButtonBase.ClickEvent,  new RoutedEventHandler(UpdateHandler));
            CreateButtonColumn("Delete", "pack://application:,,,/Img/delete-button.png")
                .AddHandler(ButtonBase.ClickEvent, new RoutedEventHandler(DeleteHandler));

            CellEditEnding += EventHandler_CellEndEdit;
        }

        

        private void CreateTextColumn(string columnName, string propertyName)
        {
            DataGridTextColumn column = new DataGridTextColumn();
            Binding binding = new Binding(propertyName);
            column.Binding = binding;
            column.Header = columnName;
            this.Columns.Add(column);
        }



        public FrameworkElementFactory CreateButtonColumn(string columnName, string imagePath)
        {
            DataGridTemplateColumn buttonColumn = new DataGridTemplateColumn();
            DataTemplate buttonTemplate = new DataTemplate();
            FrameworkElementFactory buttonFactory = new FrameworkElementFactory(typeof(Button));
            buttonTemplate.VisualTree = buttonFactory;
            buttonColumn.Header = columnName;
            buttonColumn.CellTemplate = buttonTemplate;
            BitmapImage bitImg = new BitmapImage(new Uri(imagePath,
                UriKind.RelativeOrAbsolute));

            FrameworkElementFactory img = new FrameworkElementFactory(typeof(Image));

            img.SetValue(Image.SourceProperty, bitImg);
            img.SetValue(HeightProperty, 23.0);

            buttonFactory.AppendChild(img);
            buttonFactory.SetValue(BackgroundProperty, Brushes.White);
            buttonFactory.SetValue(BorderBrushProperty, Brushes.White);

            this.Columns.Add(buttonColumn);

            return buttonFactory;
        }



        private void UpdateHandler(object sender, RoutedEventArgs e)
        {
            var DTO = ((ButtonBase)sender).DataContext as BranoDTO;
            ClientHelper helper = new ClientHelper();
            helper.UpdateBrano(DTO);
            DataGridRow Row = (DataGridRow)ItemContainerGenerator.ContainerFromIndex(SelectedIndex);
            Row.Background = Brushes.White;
        }

        private void DeleteHandler(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Are you sure?", "Delete Confirmation", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                var row = ((ButtonBase)sender).DataContext as BranoDTO;
                ClientHelper helper = new ClientHelper();
                helper.DeleteBrano(row.Id.Value);
            }
        }


        void EventHandler_CellEndEdit(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (!isManualEditCommit)
            {
                isManualEditCommit = true;
                DataGrid grid = (DataGrid)sender;
                grid.CommitEdit(DataGridEditingUnit.Row, true);
                e.Row.Background = Brushes.Yellow;
                isManualEditCommit = false;
            }
        }


    }
}

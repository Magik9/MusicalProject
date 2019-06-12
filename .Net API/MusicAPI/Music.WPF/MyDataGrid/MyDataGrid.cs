using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Media;

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

            CreateTextColumn("Id", "Id");
            CreateTextColumn("Titolo", "Titolo");
            CreateTextColumn("Disco", "Disco");
            CreateTextColumn("Band", "Band");
            CreateTextColumn("Anno", "Anno");
            CreateTextColumn("Durata", "Durata");

            CreateButtonColumn("Update", "Update")
                .AddHandler(ButtonBase.ClickEvent,  new RoutedEventHandler(MakeUpdateHappen));
            CreateButtonColumn("Delete", "Delete")
                .AddHandler(ButtonBase.ClickEvent, new RoutedEventHandler(MakeDeleteHappen));

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



        public FrameworkElementFactory CreateButtonColumn(string columnName, string buttonName)
        {
            DataGridTemplateColumn buttonColumn = new DataGridTemplateColumn();
            DataTemplate buttonTemplate = new DataTemplate();
            FrameworkElementFactory buttonFactory = new FrameworkElementFactory(typeof(Button));
            buttonTemplate.VisualTree = buttonFactory;
            buttonFactory.SetValue(ContentControl.ContentProperty, buttonName);
            buttonColumn.Header = columnName;
            buttonColumn.CellTemplate = buttonTemplate;
            this.Columns.Add(buttonColumn);
            

            return buttonFactory;
        }



        public event RoutedEventHandler UpdateHappened;
        public event RoutedEventHandler DeleteHappened;

        private void MakeUpdateHappen(object sender, RoutedEventArgs e)
        {
            UpdateHappened?.Invoke(sender, e);
            DataGridRow Row = (DataGridRow)ItemContainerGenerator.ContainerFromIndex(SelectedIndex);
            Row.Background = Brushes.White;
        }

        private void MakeDeleteHappen(object sender, RoutedEventArgs e)
        {
            DeleteHappened?.Invoke(sender, e);
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

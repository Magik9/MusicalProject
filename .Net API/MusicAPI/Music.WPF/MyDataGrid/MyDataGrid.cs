using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;

namespace Music.WPF.MyDataGrid
{
    public class XDataGrid : DataGrid
    {

        public XDataGrid()
        {
            this.AutoGenerateColumns = false;

            this.RowHeaderWidth = 0;

            CreateTextColumn("Id", "Id");
            CreateTextColumn("Titolo", "Titolo");
            CreateTextColumn("Disco", "Disco");
            CreateTextColumn("Band", "Band");
            CreateTextColumn("Anno", "Anno");
            CreateTextColumn("Durata", "Durata");

            CreateButtonColumn("Update", "Update").AddHandler(ButtonBase.ClickEvent,  new RoutedEventHandler(MakeUpdateHappen));
            CreateButtonColumn("Delete", "Delete").AddHandler(ButtonBase.ClickEvent, new RoutedEventHandler(MakeDeleteHappen));
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


        public event EventHandler UpdateHappened;
        public event EventHandler DeleteHappened;

        private void MakeUpdateHappen(object sender, RoutedEventArgs e)
        {
            UpdateHappened?.Invoke(sender, e);
        }

        private void MakeDeleteHappen(object sender, RoutedEventArgs e)
        {
            DeleteHappened?.Invoke(sender, e);
        }


    }
}

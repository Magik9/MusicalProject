using Client;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Music.WPF.Commands
{
    public class DischiGridCommands
    {
        private bool isManualEditCommit;

        private MainWindowModel _mainViewModel;

        private ClientHelper _helper;

        public DischiGridCommands()
        {
            _helper = new ClientHelper();
        }

        public ICommand SelDiscoChange => new RelayCommand(async o => await SelectionDiscoChange_EventAsync(o), o => true);

        private async Task SelectionDiscoChange_EventAsync(object sender)
        {
            SelectionChangedEventArgs args = (SelectionChangedEventArgs)sender;
            DataGrid grid = (DataGrid)args.Source;
            DiscoDTO Row = (DiscoDTO)grid.SelectedItem;
            _mainViewModel = (MainWindowModel)grid.DataContext;

            if (Row != null)
            {
                int id = int.Parse((grid.SelectedCells[0].Column.GetCellContent(Row) as TextBlock).Text);

                _mainViewModel.Brani = await _helper.LoadBraniDisco(id);

                _mainViewModel.RenderGrid(_mainViewModel.gridBrani);
            }
        }


        public ICommand AddImageDisco => new RelayCommand(o => AddImageDisco_Event(o), o => true);

        private void AddImageDisco_Event(object selectedItem)
        {
            AddImageWindow.AddImageWindow imgWindow = new AddImageWindow.AddImageWindow(selectedItem);
            imgWindow.Show();
        }


        public ICommand CellEditEnd => new RelayCommand(o => DiscoEditEnd_Event(o), o => true);

        private void DiscoEditEnd_Event(object sender)
        {
            if (!isManualEditCommit)
            {
                isManualEditCommit = true;
                var obj = (object[])sender;
                var e = (DataGridCellEditEndingEventArgs)obj[0];
                var grid = (DataGrid)obj[1];
                grid.CommitEdit(DataGridEditingUnit.Row, true);
                e.Row.Background = Brushes.Yellow;
                isManualEditCommit = false;
            }
        }


        public ICommand DeleteDisco => new RelayCommand(o => DiscoDelete_Click(o), o => true);

        private void DiscoDelete_Click(object grid)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Are you sure?", "Delete Confirmation", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                _helper.DeleteDisco(((DataGrid)grid).SelectedItem);
            }
        }


        public ICommand UpdateDisco => new RelayCommand(o => DiscoUpdate_Click(o), o => true);

        private void DiscoUpdate_Click(object sender)
        {
            DataGrid grid = (DataGrid)sender;
            DataGridRow Row = (DataGridRow)grid.ItemContainerGenerator.ContainerFromIndex(grid.SelectedIndex);
            _helper.UpdateDisco(Row.Item);
            Row.Background = Brushes.White;
        }


        public ICommand AddImageWindowCommand => new RelayCommand(o => AddImageWindow_Click(o), o => true);

        private void AddImageWindow_Click(object sender)
        {

            AddImageWindow.AddImageWindow addImageWindow = new AddImageWindow.AddImageWindow(sender);
            addImageWindow.Show();

        }

    }
}

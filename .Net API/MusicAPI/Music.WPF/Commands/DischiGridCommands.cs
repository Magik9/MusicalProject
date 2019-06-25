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

        private ICommand _selDiscoChange;
        public ICommand SelDiscoChange
        {
            get
            {
                if (_selDiscoChange == null)
                    _selDiscoChange = new RelayCommand(async o => await SelectionDiscoChange_EventAsync(o), o => true);
                return _selDiscoChange;
            }
            set
            {
                _selDiscoChange = value;
            }
        }


        private ICommand _addImageDisco;
        public ICommand AddImageDisco
        {
            get
            {
                if (_addImageDisco == null)
                    _addImageDisco = new RelayCommand(o => AddImageDisco_Event(o), o => true);
                return _addImageDisco;
            }
            set
            {
                _addImageDisco = value;
            }
        }


        private ICommand _cellEditEnd;
        public ICommand CellEditEnd
        {
            get
            {
                if (_cellEditEnd == null)
                    _cellEditEnd = new RelayCommand(o => DiscoEditEnd_Event(o), o => true);
                return _cellEditEnd;
            }
            set
            {
                _cellEditEnd = value;
            }
        }


        private ICommand _deleteDisco;
        public ICommand DeleteDisco
        {
            get
            {
                if (_deleteDisco == null)
                    _deleteDisco = new RelayCommand(o => DiscoDelete_Click(o), o => true);
                return _deleteDisco;
            }
            set
            {
                _deleteDisco = value;
            }
        }


        private ICommand _updateDisco;
        public ICommand UpdateDisco
        {
            get
            {
                if (_updateDisco == null)
                    _updateDisco = new RelayCommand(o => DiscoUpdate_Click(o), o => true);
                return _updateDisco;
            }
            set
            {
                _updateDisco = value;
            }
        }


        private async Task SelectionDiscoChange_EventAsync(object sender)
        {
            SelectionChangedEventArgs args = (SelectionChangedEventArgs)sender;
            DataGrid grid = (DataGrid)args.Source;
            DiscoDTO Row = (DiscoDTO)grid.SelectedItem;
            _mainViewModel = (MainWindowModel)grid.DataContext;

            if (Row != null)
            {
                int id = int.Parse((grid.SelectedCells[0].Column.GetCellContent(Row) as TextBlock).Text);

                ClientHelper helper = new ClientHelper();
                _mainViewModel.Brani = await helper.LoadBraniDisco(id);

                _mainViewModel.RenderGrid(_mainViewModel.gridBrani);
            }
        }


        private void AddImageDisco_Event(object selectedItem)
        {
            AddImageWindow.AddImageWindow imgWindow = new AddImageWindow.AddImageWindow(selectedItem);
            imgWindow.Show();
        }


        private void DiscoUpdate_Click(object sender)
        {
            DataGrid grid = (DataGrid)sender;
            DataGridRow Row = (DataGridRow)grid.ItemContainerGenerator.ContainerFromIndex(grid.SelectedIndex);
            ClientHelper helper = new ClientHelper();
            helper.UpdateDisco(Row.Item);
            Row.Background = Brushes.White;
        }


        private void DiscoDelete_Click(object grid)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Are you sure?", "Delete Confirmation", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                ClientHelper helper = new ClientHelper();
                helper.DeleteDisco(((DataGrid)grid).SelectedItem);
            }
        }


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
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using Client;
using Music.WPF.AddBranoWindow;
using Music.WPF.MyDataGrid;

namespace Music.WPF
{
    public class MainWindowModel : INotifyPropertyChanged
    {
        private ClientHelper ClientHelper;
        
        public XDataGrid gridBrani;

        private bool isManualEditCommit;

        private List<BranoDTO> _brani;

        public List<BranoDTO> Brani
        {
            get => _brani;
            set
            {
                _brani = value;
                if (gridBrani != null)
                    gridBrani.ItemsSource = Brani;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private List<DiscoDTO> _dischi;

        public List<DiscoDTO> Dischi
        {
            get => _dischi;
            set
            {
                _dischi = value;
                OnPropertyChanged("Dischi");
            }
        }


        private ICommand _selDiscoChange;
        public ICommand SelDiscoChange
        {
            get
            {
                if (_selDiscoChange == null)
                    _selDiscoChange = new RelayCommand(o => SelectionDiscoChange_Event(o), o => true);
                return _selDiscoChange;
            }
            set
            {
                _selDiscoChange = value;
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


        private ICommand _mouseEnter;
        public ICommand MouseEnter
        {
            get
            {
                if (_mouseEnter == null)
                    _mouseEnter = new RelayCommand(o => mouseenterevent(o), o => true);
                return _mouseEnter;
            }
            set
            {
                _updateDisco = value;
            }
        }


        private void mouseenterevent(object parameter)
        {
            MouseEventArgs x = (MouseEventArgs)parameter;

            DataGridRow row = x.Source as DataGridRow;

            var y = (ToolTip)row.ToolTip;

            y.Placement = PlacementMode.MousePoint;
        }


        public MainWindowModel()
        {
            this.ClientHelper = new ClientHelper();
            
            Brani = new List<BranoDTO>();

            gridBrani = new XDataGrid();
            
            gridBrani.UpdateHappened += new RoutedEventHandler(update_eventHandler);
            gridBrani.DeleteHappened += new RoutedEventHandler(delete_eventHandler);
        }



        public void ShowCreateBranoView(MainWindow owner)
        {
            var inputBranoView = new CreateBranoWindow(owner);
            inputBranoView.addBranoEvent += new RoutedEventHandler(addBrano_Event);
            inputBranoView.Show();
        }



        private void addBrano_Event(object sender, RoutedEventArgs e)
        {
            var branoBO = ((CreateBranoWindow)sender).BO;
            ClientHelper.AddBrano(branoBO);
        }



        private void update_eventHandler(object sender, RoutedEventArgs e)
        {
            var DTO = ((ButtonBase)sender).DataContext as BranoDTO;
            ClientHelper.UpdateBrano(DTO);
        }



        private void delete_eventHandler(object sender, EventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Are you sure?", "Delete Confirmation", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                var row = ((ButtonBase)sender).DataContext as BranoDTO;
                ClientHelper.DeleteBrano(row.Id.Value);
            }
            
        }



        private async void SelectionDiscoChange_Event(object sender)
        {
            DataGrid grid = (DataGrid)sender;
            DataGridRow Row = (DataGridRow)grid.ItemContainerGenerator.ContainerFromIndex(grid.SelectedIndex);

            if (Row != null)
            {
                int id = int.Parse((grid.SelectedCells[0].Column.GetCellContent(Row.Item) as TextBlock).Text);
                Brani = await ClientHelper.LoadBraniDisco(id);

                RenderGrid(gridBrani);
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


        private void DiscoUpdate_Click(object sender)
        {
            DataGrid grid = (DataGrid)sender;
            DataGridRow Row = (DataGridRow)grid.ItemContainerGenerator.ContainerFromIndex(grid.SelectedIndex);
            ClientHelper.UpdateDisco(Row.Item);
            Row.Background = Brushes.White;
        }


        private void DiscoDelete_Click(object item)
        {

            MessageBoxResult messageBoxResult = MessageBox.Show("Are you sure?", "Delete Confirmation", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                ClientHelper.DeleteDisco(item);
            }

        }

        public void RenderGrid(DataGrid grid)
        {
            Storyboard sb = new Storyboard();
            DoubleAnimation da = new DoubleAnimation();

            da.From = grid.ActualHeight;
            da.To = (grid.Items.Count + 1) * 30.10;
            da.Duration = new Duration(TimeSpan.FromSeconds(0.2));
            Storyboard.SetTargetProperty(da, new PropertyPath(FrameworkElement.HeightProperty));
            sb.Children.Add(da);
            grid.BeginStoryboard(sb);
            grid.VerticalScrollBarVisibility = ScrollBarVisibility.Disabled;
        }


    }
}

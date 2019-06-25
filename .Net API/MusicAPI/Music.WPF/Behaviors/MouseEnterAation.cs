using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Interactivity;
using System.Windows.Media.Imaging;
using System;
using Client;

namespace Music.WPF.Behaviors
{
    public class MouseEnterAction : TriggerAction<DependencyObject>
    {
        public string MouseEnter
        {
            get { return (string)GetValue(MouseEnterProperty); }
            set { SetValue(MouseEnterProperty, value); }
        }

        public static readonly DependencyProperty MouseEnterProperty =
            DependencyProperty.Register("MouseEnter", typeof(string), typeof(MouseEnterAction), new UIPropertyMetadata(""));

        public object MouseEnterParameter
        {
            get { return GetValue(MouseEnterParameterProperty); }
            set { SetValue(MouseEnterParameterProperty, value); }
        }

        public static readonly DependencyProperty MouseEnterParameterProperty =
            DependencyProperty.Register("MouseEnterParameter", typeof(object), typeof(MouseEnterAction), new UIPropertyMetadata(null));


        protected override void Invoke(object parameter)
        {
            DataGridRow row = MouseEnterParameter as DataGridRow;

            var y = row.ToolTip as ToolTip;

            DiscoDTO disco = (DiscoDTO)row.Item;

            if (disco.Img != null)
            {
                BitmapImage src = new BitmapImage();

                src.BeginInit();
                src.UriSource = new Uri(disco.Img, UriKind.Absolute);
                src.CacheOption = BitmapCacheOption.OnLoad;
                src.EndInit();

                Image img = new Image();
                img.Source = src;

                y.Content = img;

                y.Placement = PlacementMode.MousePoint;
                y.Visibility = Visibility.Visible;
            }
            else
                y.Visibility = Visibility.Hidden;
        }
    }
}

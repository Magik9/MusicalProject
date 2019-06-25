using Client;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace Converters
{
    public class TooltipConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ToolTip tooltip = new ToolTip();
            StackPanel panel = new StackPanel();
            BitmapImage src = new BitmapImage();
            //DataGridRow row = (DataGridRow)values[0];

            if (value != null)
            {
                //DiscoDTO disco = (DiscoDTO)row.Item;
                //string imagePath =disco.Img;
                src.BeginInit();
                src.UriSource = new Uri((string)value, UriKind.Absolute);
                src.CacheOption = BitmapCacheOption.OnLoad;
                src.EndInit();

                Image img = new Image();
                img.Source = src;

                panel.Children.Add(img);
                tooltip.SetValue(ContentControl.ContentProperty, panel);
            }
            return tooltip;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

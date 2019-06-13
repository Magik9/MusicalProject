using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;

namespace Music.WPF
{
    public class Converter : IEventArgsConverter
    {
        public object Convert(object value, object parameter)
        {
            var element = parameter;
            object[] result = new object[] {value, element };

            return result;
        }
    }
}



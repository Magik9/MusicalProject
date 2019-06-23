using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converters
{
    public class ArgsConverter : IEventArgsConverter
    {
        public object Convert(object value, object parameter)
        {
            object[] obj = new object[] { value, parameter };

            return obj;
        }
    }
}

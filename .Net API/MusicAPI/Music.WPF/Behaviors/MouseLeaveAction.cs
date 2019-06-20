using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace Music.WPF.Behaviors
{
    public class MouseLeaveAction : TriggerAction<DependencyObject>
    {
        public string MouseLeave
        {
            get { return (string)GetValue(MouseLeaveProperty); }
            set { SetValue(MouseLeaveProperty, value); }
        }

        public static readonly DependencyProperty MouseLeaveProperty =
            DependencyProperty.Register("MouseLeave", typeof(string), typeof(MouseLeaveAction), new UIPropertyMetadata(""));

        public object MouseLeaveParameter
        {
            get { return (object)GetValue(MouseLeaveParameterProperty); }
            set { SetValue(MouseLeaveParameterProperty, value); }
        }

        public static readonly DependencyProperty MouseLeaveParameterProperty =
            DependencyProperty.Register("MouseLeaveParameter", typeof(object), typeof(MouseLeaveAction), new UIPropertyMetadata(null));


        protected override void Invoke(object parameter)
        {
            MouseEventArgs x = (MouseEventArgs)parameter;

            DataGridRow row = x.Source as DataGridRow;

            var y = (ToolTip)row.ToolTip;

            y.IsOpen = false;
        }
    }
}

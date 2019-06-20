
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Interactivity;

namespace Music.WPF.Behaviors
{
    public class DebugAction : TriggerAction<DependencyObject>
    {
        public string Message
        {
            get { return (string)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }

        public static readonly DependencyProperty MessageProperty =
            DependencyProperty.Register("Message", typeof(string), typeof(DebugAction), new UIPropertyMetadata(""));

        public object MessageParameter
        {
            get { return (object)GetValue(MessageParameterProperty); }
            set { SetValue(MessageParameterProperty, value); }
        }

        public static readonly DependencyProperty MessageParameterProperty =
            DependencyProperty.Register("MessageParameter", typeof(object), typeof(DebugAction), new UIPropertyMetadata(null));


        protected override void Invoke(object parameter)
        {
            MouseEventArgs x = (MouseEventArgs)parameter;

            DataGridRow row = x.Source as DataGridRow;

            var y = (ToolTip)row.ToolTip;

            y.Placement = PlacementMode.MousePoint;
        }
    }
}

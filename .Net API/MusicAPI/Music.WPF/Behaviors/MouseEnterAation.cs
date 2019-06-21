using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Interactivity;

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
            MouseEventArgs x = (MouseEventArgs)parameter;

            DataGridRow row = x.Source as DataGridRow;

            var y = (ToolTip)row.ToolTip;

            y.Placement = PlacementMode.MousePoint;
        }
    }
}

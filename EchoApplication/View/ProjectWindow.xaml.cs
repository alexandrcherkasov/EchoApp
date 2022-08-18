using EchoApplication.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EchoApplication.View
{
    /// <summary>
    /// Логика взаимодействия для ProjectWindow.xaml
    /// </summary>
    public partial class ProjectWindow : UserControl
    {
        public ProjectWindow()
        {
            InitializeComponent();
        }

        private void DataGrid_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is DataGrid dataGrid &&
       e.OriginalSource is FrameworkElement frameworkElement &&
       frameworkElement.DataContext == dataGrid.SelectedItem)
            {
                if (dataGrid.RowDetailsVisibilityMode == DataGridRowDetailsVisibilityMode.VisibleWhenSelected)
                    dataGrid.RowDetailsVisibilityMode = DataGridRowDetailsVisibilityMode.Collapsed;
                else
                    dataGrid.RowDetailsVisibilityMode = DataGridRowDetailsVisibilityMode.VisibleWhenSelected;
            }
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }

    public class FixScrollingBehaviorOn
    {
        public static readonly DependencyProperty ParentDataGridProperty = DependencyProperty.RegisterAttached("ParentDataGrid", typeof(DataGrid), typeof(FixScrollingBehaviorOn),
            new FrameworkPropertyMetadata(default(DataGrid), OnParentDataGridPropertyChanged));

        public static bool GetParentDataGrid(DependencyObject obj)

        {
            return (bool)obj.GetValue(ParentDataGridProperty);
        }

        public static void SetParentDataGrid(DependencyObject obj, bool value)

        {
            obj.SetValue(ParentDataGridProperty, value);
        }


        public static void OnParentDataGridPropertyChanged(object sender, DependencyPropertyChangedEventArgs e)

        {
            var dataGrid = sender as DataGrid;

            if (dataGrid == null)

            {
                throw new ArgumentException("The dependency property can only be attached to a DataGrid", "sender");
            }

            if (e.NewValue is DataGrid parentGrid)
            {
                dataGrid.PreviewMouseWheel += HandlePreviewMouseWheel;
                parentGrid.SetValue(ScrollViewer.CanContentScrollProperty, false);
            }
            else
            {
                dataGrid.PreviewMouseWheel -= HandlePreviewMouseWheel;

                if (e.OldValue is DataGrid oldParentGrid)
                {
                    oldParentGrid.SetValue(ScrollViewer.CanContentScrollProperty, ScrollViewer.CanContentScrollProperty.DefaultMetadata.DefaultValue);
                }
            }
        }

        private static void HandlePreviewMouseWheel(object sender, MouseWheelEventArgs e)

        {
            if (e.Handled)
            {
                return;
            }
            var control = sender as DataGrid;
            if (control == null)
            {
                return;
            }
            e.Handled = true;
            var wheelArgs = new MouseWheelEventArgs(e.MouseDevice, e.Timestamp, e.Delta)
            {
                RoutedEvent = UIElement.MouseWheelEvent,
                Source = control
            };
            var parent = VisualTreeHelper.GetParent(control) as UIElement;
            parent?.RaiseEvent(wheelArgs);
        }
    }

}


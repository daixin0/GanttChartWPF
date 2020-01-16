using GanttChartControl.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace GanttChartControl
{
    public class GridCell : ContentControl
    {

    }
    public class RowsGridPresenter : ItemsControl
    {
        protected override DependencyObject GetContainerForItemOverride()
        {
            GridCell gridCell = new GridCell();
            return gridCell;
        }
        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            bool _isITV = item is GridCell;
            return _isITV;
        }
    }
    public class ColumnsGridPresenter : ItemsControl
    {
        protected override DependencyObject GetContainerForItemOverride()
        {
            GridCell gridCell = new GridCell();
            return gridCell;
        }
        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            bool _isITV = item is GridCell;
            return _isITV;
        }
    }
    public class GanttChartGridControl : Control
    {

        public ObservableCollection<GanttProjectModel> GanttRowsItem
        {
            get { return (ObservableCollection<GanttProjectModel>)GetValue(GanttRowsItemProperty); }
            set { SetValue(GanttRowsItemProperty, value); }
        }

        // Using a DependencyProperty as the backing store for GanttRowsItem.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GanttRowsItemProperty =
            DependencyProperty.Register("GanttRowsItem", typeof(ObservableCollection<GanttProjectModel>), typeof(GanttChartGridControl));



        public ObservableCollection<TimeItemModel> GanttColumnsItem
        {
            get { return (ObservableCollection<TimeItemModel>)GetValue(GanttColumnsItemProperty); }
            set { SetValue(GanttColumnsItemProperty, value); }
        }

        // Using a DependencyProperty as the backing store for GanttColumnsItem.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GanttColumnsItemProperty =
            DependencyProperty.Register("GanttColumnsItem", typeof(ObservableCollection<TimeItemModel>), typeof(GanttChartGridControl));


    }
}

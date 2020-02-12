using GanttChartControl.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace GanttChartControl
{

    public class GanttChartGridControl : Control
    {
        public static void GetTreeChildren(ObservableCollection<GanttProjectModel> list, GanttProjectModel tree)
        {
            foreach (var item in tree.Children)
            {
                if (item.Children == null || item.Children.Count <= 0)
                {
                    list.Add(item);
                }
                else
                {
                    GetTreeChildren(list, item);
                }
            }
        }

        public ObservableCollection<TimeItemModel> GanttItemsSourceHeader
        {
            get { return (ObservableCollection<TimeItemModel>)GetValue(GanttItemsSourceHeaderProperty); }
            set { SetValue(GanttItemsSourceHeaderProperty, value); }
        }

        // Using a DependencyProperty as the backing store for GanttItemsSourceHeader.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GanttItemsSourceHeaderProperty =
            DependencyProperty.Register("GanttItemsSourceHeader", typeof(ObservableCollection<TimeItemModel>), typeof(GanttChartGridControl), new PropertyMetadata(OnGanttItemsSourceHeaderChanged));

        private static void OnGanttItemsSourceHeaderChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            GanttChartGridControl ganttChartGridControl = d as GanttChartGridControl;
            ObservableCollection<TimeItemModel> timeItemModels = new ObservableCollection<TimeItemModel>();
            foreach (var item in ganttChartGridControl.GanttItemsSourceHeader)
            {
                timeItemModels.Add(new TimeItemModel() { TimeName = item.TimeName });
                foreach (var time in item.DateTimeList)
                {
                    timeItemModels.Add(new TimeItemModel() { TimeName = time });
                }
            }
            ganttChartGridControl.GanttColumnsItem = new ObservableCollection<TimeItemModel>(timeItemModels);
        }


        public GanttProjectModel GanttItemsSourceTree
        {
            get { return (GanttProjectModel)GetValue(GanttItemsSourceTreeProperty); }
            set { SetValue(GanttItemsSourceTreeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for GanttItemsSourceTree.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GanttItemsSourceTreeProperty =
            DependencyProperty.Register("GanttItemsSourceTree", typeof(GanttProjectModel), typeof(GanttChartGridControl), new PropertyMetadata(OnGanttItemsSourceTreeChanged));

        private static void OnGanttItemsSourceTreeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            GanttChartGridControl ganttChartGridControl = d as GanttChartGridControl;

            ObservableCollection<GanttProjectModel> ganttProjectModels = new ObservableCollection<GanttProjectModel>();
            GetTreeChildren(ganttProjectModels, ganttChartGridControl.GanttItemsSourceTree);
            ganttChartGridControl.GanttRowsItem = new ObservableCollection<GanttProjectModel>(ganttProjectModels);
        }

        public ObservableCollection<GanttProjectModel> GanttRowsItem
        {
            get { return (ObservableCollection<GanttProjectModel>)GetValue(GanttRowsItemProperty); }
            set { SetValue(GanttRowsItemProperty, value); }
        }

        // Using a DependencyProperty as the backing store for GanttRowsItem.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GanttRowsItemProperty =
            DependencyProperty.Register("GanttRowsItem", typeof(ObservableCollection<GanttProjectModel>), typeof(GanttChartGridControl), new PropertyMetadata(new ObservableCollection<GanttProjectModel>()));

        public ObservableCollection<TimeItemModel> GanttColumnsItem
        {
            get { return (ObservableCollection<TimeItemModel>)GetValue(GanttColumnsItemProperty); }
            set { SetValue(GanttColumnsItemProperty, value); }
        }

        // Using a DependencyProperty as the backing store for GanttColumnsItem.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GanttColumnsItemProperty =
            DependencyProperty.Register("GanttColumnsItem", typeof(ObservableCollection<TimeItemModel>), typeof(GanttChartGridControl), new PropertyMetadata(new ObservableCollection<TimeItemModel>()));




        public string HeaderTitle
        {
            get { return (string)GetValue(HeaderTitleProperty); }
            set { SetValue(HeaderTitleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for HeaderTitle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HeaderTitleProperty =
            DependencyProperty.Register("HeaderTitle", typeof(string), typeof(GanttChartGridControl));



    }
}

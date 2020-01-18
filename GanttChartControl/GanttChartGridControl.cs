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
    public class GridCell : ContentControl
    {

        public DateTime ProjectStartTime
        {
            get { return (DateTime)GetValue(ProjectStartTimeProperty); }
            set { SetValue(ProjectStartTimeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ProjectStartTime.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ProjectStartTimeProperty =
            DependencyProperty.Register("ProjectStartTime", typeof(DateTime), typeof(GridCell));


        public DateTime ProjectEndTime
        {
            get { return (DateTime)GetValue(ProjectEndTimeProperty); }
            set { SetValue(ProjectEndTimeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ProjectEndTime.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ProjectEndTimeProperty =
            DependencyProperty.Register("ProjectEndTime", typeof(DateTime), typeof(GridCell));

        public DateTime StartTime
        {
            get { return (DateTime)GetValue(StartTimeProperty); }
            set { SetValue(StartTimeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for StartTime.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StartTimeProperty =
            DependencyProperty.Register("StartTime", typeof(DateTime), typeof(GridCell));


        public DateTime EndTime
        {
            get { return (DateTime)GetValue(EndTimeProperty); }
            set { SetValue(EndTimeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for EndTime.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EndTimeProperty =
            DependencyProperty.Register("EndTime", typeof(DateTime), typeof(GridCell));



        public Visibility IsVisibleLine
        {
            get { return (Visibility)GetValue(IsVisibleLineProperty); }
            set { SetValue(IsVisibleLineProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsVisibleLine.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsVisibleLineProperty =
            DependencyProperty.Register("IsVisibleLine", typeof(Visibility), typeof(GridCell), new PropertyMetadata(Visibility.Collapsed));



        public Visibility IsVisiableStartLine
        {
            get { return (Visibility)GetValue(IsVisiableStartLineProperty); }
            set { SetValue(IsVisiableStartLineProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsVisiableStartLine.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsVisiableStartLineProperty =
            DependencyProperty.Register("IsVisiableStartLine", typeof(Visibility), typeof(GridCell), new PropertyMetadata(Visibility.Collapsed));


        public Visibility IsVisiableEndLine
        {
            get { return (Visibility)GetValue(IsVisiableEndLineProperty); }
            set { SetValue(IsVisiableEndLineProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsVisiableEndLine.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsVisiableEndLineProperty =
            DependencyProperty.Register("IsVisiableEndLine", typeof(Visibility), typeof(GridCell), new PropertyMetadata(Visibility.Collapsed));



        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            DateTime defaultTime = new DateTime(2000, 1, 1);
            if (e.Property.Name == "ProjectStartTime" || e.Property.Name == "ProjectEndTime" || e.Property.Name == "StartTime" || e.Property.Name == "EndTime")
            {
                if (ProjectStartTime > defaultTime && ProjectEndTime > defaultTime && StartTime > defaultTime && EndTime > defaultTime)
                {
                    Drawing();
                }
            }
        }

        public void Drawing()
        {
            if (ProjectStartTime == StartTime)
            {
                IsVisiableStartLine = Visibility.Visible;
            }
            if (ProjectEndTime == EndTime)
            {
                IsVisiableEndLine = Visibility.Visible;
            }
            if (StartTime >= ProjectStartTime && EndTime <= ProjectEndTime)
            {
                IsVisibleLine = Visibility.Visible;
            }

        }

    }
    public class RowsGridPresenter : ItemsControl
    {
        protected override DependencyObject GetContainerForItemOverride()
        {
            ColumnsGridPresenter gridCell = new ColumnsGridPresenter();
            return gridCell;
        }
        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            bool _isITV = item is ColumnsGridPresenter;
            return _isITV;
        }
        public ObservableCollection<TimeItemModel> GanttColumnsItem
        {
            get { return (ObservableCollection<TimeItemModel>)GetValue(GanttColumnsItemProperty); }
            set { SetValue(GanttColumnsItemProperty, value); }
        }

        // Using a DependencyProperty as the backing store for GanttColumnsItem.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GanttColumnsItemProperty =
            DependencyProperty.Register("GanttColumnsItem", typeof(ObservableCollection<TimeItemModel>), typeof(RowsGridPresenter));
        
        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            if(e.Property.Name== "GanttColumnsItem")
            {
                foreach (var item in this.ItemsSource)
                {
                    ColumnsGridPresenter col = this.ItemContainerGenerator.ContainerFromItem(item) as ColumnsGridPresenter;
                    col.GanttProjectRow = item as GanttProjectModel;
                    col.ItemsSource = GanttColumnsItem;
                }
            }
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


        public GanttProjectModel GanttProjectRow
        {
            get { return (GanttProjectModel)GetValue(GanttProjectRowProperty); }
            set { SetValue(GanttProjectRowProperty, value); }
        }

        // Using a DependencyProperty as the backing store for GanttProjectRow.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GanttProjectRowProperty =
            DependencyProperty.Register("GanttProjectRow", typeof(GanttProjectModel), typeof(ColumnsGridPresenter));


        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            for (int i = 0; i < Items.Count-1; i++)
            {
                TimeItemModel timeItemModel1 = Items[i] as TimeItemModel;
                TimeItemModel timeItemModel2 = Items[i + 1] as TimeItemModel;
                GridCell gridCell = this.ItemContainerGenerator.ContainerFromIndex(i) as GridCell;
                if (gridCell == null)
                    continue;
                gridCell.StartTime = timeItemModel1.TimeName;
                gridCell.EndTime = timeItemModel2.TimeName;
                gridCell.ProjectEndTime = GanttProjectRow.EndTime;
                gridCell.ProjectStartTime = GanttProjectRow.StartTime;
                gridCell.Content = null;
            }
        }

    }
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
            DependencyProperty.Register("GanttItemsSourceHeader", typeof(ObservableCollection<TimeItemModel>), typeof(GanttChartGridControl),new PropertyMetadata(OnGanttItemsSourceHeaderChanged));

        private static void OnGanttItemsSourceHeaderChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            GanttChartGridControl ganttChartGridControl = d as GanttChartGridControl;
            ObservableCollection<TimeItemModel> timeItemModels = new ObservableCollection<TimeItemModel>();
            foreach (var item in ganttChartGridControl.GanttItemsSourceHeader)
            {
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
            DependencyProperty.Register("GanttItemsSourceTree", typeof(GanttProjectModel), typeof(GanttChartGridControl),new PropertyMetadata(OnGanttItemsSourceTreeChanged));

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
            DependencyProperty.Register("GanttRowsItem", typeof(ObservableCollection<GanttProjectModel>), typeof(GanttChartGridControl),new PropertyMetadata(new ObservableCollection<GanttProjectModel>()));

        public ObservableCollection<TimeItemModel> GanttColumnsItem
        {
            get { return (ObservableCollection<TimeItemModel>)GetValue(GanttColumnsItemProperty); }
            set { SetValue(GanttColumnsItemProperty, value); }
        }

        // Using a DependencyProperty as the backing store for GanttColumnsItem.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GanttColumnsItemProperty =
            DependencyProperty.Register("GanttColumnsItem", typeof(ObservableCollection<TimeItemModel>), typeof(GanttChartGridControl),new PropertyMetadata(new ObservableCollection<TimeItemModel>()));


    }
}

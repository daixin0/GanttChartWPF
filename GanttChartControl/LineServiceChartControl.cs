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
    public class LineServiceChartControl : Control
    {

        public ObservableCollection<LineLegendItemModel> LegendItems
        {
            get { return (ObservableCollection<LineLegendItemModel>)GetValue(LegendItemsProperty); }
            set { SetValue(LegendItemsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LegendItems.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LegendItemsProperty =
            DependencyProperty.Register("LegendItems", typeof(ObservableCollection<LineLegendItemModel>), typeof(LineServiceChartControl));


        public ObservableCollection<LineService> LineServiceData
        {
            get { return (ObservableCollection<LineService>)GetValue(LineServiceDataProperty); }
            set { SetValue(LineServiceDataProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LineServiceData.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LineServiceDataProperty =
            DependencyProperty.Register("LineServiceData", typeof(ObservableCollection<LineService>), typeof(LineServiceChartControl),new PropertyMetadata(OnLineServiceDataChanged));

        private static void OnLineServiceDataChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            LineServiceChartControl lineServiceChart = d as LineServiceChartControl;
            ObservableCollection<LineLegendItemModel> legendItemModels = new ObservableCollection<LineLegendItemModel>();
            foreach (var item in lineServiceChart.LineServiceData)
            {
                legendItemModels.Add(item.LineLegendItem);
            }
            lineServiceChart.LegendItems = new ObservableCollection<LineLegendItemModel>();
        }


        public ObservableCollection<TimeItemModel> LineXTimeSource
        {
            get { return (ObservableCollection<TimeItemModel>)GetValue(LineXTimeSourceProperty); }
            set { SetValue(LineXTimeSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for GanttItemsSourceHeader.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LineXTimeSourceProperty =
            DependencyProperty.Register("LineXTimeSource", typeof(ObservableCollection<TimeItemModel>), typeof(LineServiceChartControl), new PropertyMetadata(OnLineXTimeSourceChanged));

        private static void OnLineXTimeSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            LineServiceChartControl lineServiceChart = d as LineServiceChartControl;
            ObservableCollection<TimeItemModel> timeItemModels = new ObservableCollection<TimeItemModel>();
            foreach (var item in lineServiceChart.LineXTimeSource)
            {
                foreach (var time in item.DateTimeList)
                {
                    timeItemModels.Add(new TimeItemModel() { TimeName = time });
                }
            }
            lineServiceChart.LineColumnsItem = new ObservableCollection<TimeItemModel>(timeItemModels);
        }

        public ObservableCollection<GanttProjectModel> LineRowsItem
        {
            get { return (ObservableCollection<GanttProjectModel>)GetValue(LineRowsItemProperty); }
            set { SetValue(LineRowsItemProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LineRowsItem.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LineRowsItemProperty =
            DependencyProperty.Register("LineRowsItem", typeof(ObservableCollection<GanttProjectModel>), typeof(LineServiceChartControl));



        public ObservableCollection<TimeItemModel> LineColumnsItem
        {
            get { return (ObservableCollection<TimeItemModel>)GetValue(LineColumnsItemProperty); }
            set { SetValue(LineColumnsItemProperty, value); }
        }

        // Using a DependencyProperty as the backing store for GanttColumnsItem.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LineColumnsItemProperty =
            DependencyProperty.Register("LineColumnsItem", typeof(ObservableCollection<TimeItemModel>), typeof(LineServiceChartControl));

    }
}

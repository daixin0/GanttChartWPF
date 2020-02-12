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

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Title.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(LineServiceChartControl));


        public string Y1AxisScaleTitle
        {
            get { return (string)GetValue(Y1AxisScaleTitleProperty); }
            set { SetValue(Y1AxisScaleTitleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Y1AxisScaleTitle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Y1AxisScaleTitleProperty =
            DependencyProperty.Register("Y1AxisScaleTitle", typeof(string), typeof(LineServiceChartControl));

        public ObservableCollection<double> Y1AxisScale
        {
            get { return (ObservableCollection<double>)GetValue(Y1AxisScaleProperty); }
            set { SetValue(Y1AxisScaleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Y1AxisScale.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Y1AxisScaleProperty =
            DependencyProperty.Register("Y1AxisScale", typeof(ObservableCollection<double>), typeof(LineServiceChartControl));

        public string Y2AxisScaleTitle
        {
            get { return (string)GetValue(Y2AxisScaleTitleProperty); }
            set { SetValue(Y2AxisScaleTitleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Y2AxisScaleTitle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Y2AxisScaleTitleProperty =
            DependencyProperty.Register("Y2AxisScaleTitle", typeof(string), typeof(LineServiceChartControl));



        public ObservableCollection<double> Y2AxisScale
        {
            get { return (ObservableCollection<double>)GetValue(Y2AxisScaleProperty); }
            set { SetValue(Y2AxisScaleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Y2AxisScale.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Y2AxisScaleProperty =
            DependencyProperty.Register("Y2AxisScale", typeof(ObservableCollection<double>), typeof(LineServiceChartControl));



        public ObservableCollection<LineLegendItemModel> LegendItems
        {
            get { return (ObservableCollection<LineLegendItemModel>)GetValue(LegendItemsProperty); }
            set { SetValue(LegendItemsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LegendItems.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LegendItemsProperty =
            DependencyProperty.Register("LegendItems", typeof(ObservableCollection<LineLegendItemModel>), typeof(LineServiceChartControl));


        public ObservableCollection<LineLegendItemModel> LineLegendTopItem
        {
            get { return (ObservableCollection<LineLegendItemModel>)GetValue(LineLegendTopItemProperty); }
            set { SetValue(LineLegendTopItemProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LineLegendTopItem.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LineLegendTopItemProperty =
            DependencyProperty.Register("LineLegendTopItem", typeof(ObservableCollection<LineLegendItemModel>), typeof(LineServiceChartControl));


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
            ObservableCollection<LineLegendItemModel> legendTopItemModels = new ObservableCollection<LineLegendItemModel>();
            foreach (var item in lineServiceChart.LineServiceData)
            {
                if (item.LineLegendItem != null)
                    legendItemModels.Add(item.LineLegendItem);
                if (item.LineLegendTopItem != null)
                    legendTopItemModels.Add(item.LineLegendTopItem);
            }
            lineServiceChart.LegendItems = new ObservableCollection<LineLegendItemModel>(legendItemModels);
            lineServiceChart.LineLegendTopItem = new ObservableCollection<LineLegendItemModel>(legendTopItemModels);
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
                timeItemModels.Add(new TimeItemModel() { TimeName = item.TimeName });
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

        public ObservableCollection<LineLegendGroupModel> ProjectGroupInfo
        {
            get { return (ObservableCollection<LineLegendGroupModel>)GetValue(ProjectGroupInfoProperty); }
            set { SetValue(ProjectGroupInfoProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ProjectGroupInfo.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ProjectGroupInfoProperty =
            DependencyProperty.Register("ProjectGroupInfo", typeof(ObservableCollection<LineLegendGroupModel>), typeof(LineServiceChartControl));


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

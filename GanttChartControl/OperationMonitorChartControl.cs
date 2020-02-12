using CommonLib;
using GanttChartControl.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing.Printing;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace GanttChartControl
{
    public class OperationMonitorChartPageControl:ItemsControl
    {

        protected override DependencyObject GetContainerForItemOverride()
        {
            OperationMonitorChartControl gridCell = new OperationMonitorChartControl();
            return gridCell;
        }
        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            bool _isITV = item is OperationMonitorChartControl;
            return _isITV;
        }


        public int SumPage
        {
            get { return (int)GetValue(SumPageProperty); }
            set { SetValue(SumPageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SumPage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SumPageProperty =
            DependencyProperty.Register("SumPage", typeof(int), typeof(OperationMonitorChartPageControl));


        public string HeaderTimeTitle
        {
            get { return (string)GetValue(HeaderTimeTitleProperty); }
            set { SetValue(HeaderTimeTitleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for HeaderTimeTitle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HeaderTimeTitleProperty =
            DependencyProperty.Register("HeaderTimeTitle", typeof(string), typeof(OperationMonitorChartPageControl));
        public string LineChartTitle
        {
            get { return (string)GetValue(LineChartTitleProperty); }
            set { SetValue(LineChartTitleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LineChartTitle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LineChartTitleProperty =
            DependencyProperty.Register("LineChartTitle", typeof(string), typeof(OperationMonitorChartPageControl));


        public GanttProjectModel GanttItemsSourceTree
        {
            get { return (GanttProjectModel)GetValue(GanttItemsSourceTreeProperty); }
            set { SetValue(GanttItemsSourceTreeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for GanttItemsSourceTree.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GanttItemsSourceTreeProperty =
            DependencyProperty.Register("GanttItemsSourceTree", typeof(GanttProjectModel), typeof(OperationMonitorChartPageControl));


        public ObservableCollection<double> Y1AxisScale
        {
            get { return (ObservableCollection<double>)GetValue(Y1AxisScaleProperty); }
            set { SetValue(Y1AxisScaleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Y1AxisScale.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Y1AxisScaleProperty =
            DependencyProperty.Register("Y1AxisScale", typeof(ObservableCollection<double>), typeof(OperationMonitorChartPageControl));
        public string Y1AxisScaleTitle
        {
            get { return (string)GetValue(Y1AxisScaleTitleProperty); }
            set { SetValue(Y1AxisScaleTitleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Y1AxisScaleTitle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Y1AxisScaleTitleProperty =
            DependencyProperty.Register("Y1AxisScaleTitle", typeof(string), typeof(OperationMonitorChartPageControl));
        public ObservableCollection<double> Y2AxisScale
        {
            get { return (ObservableCollection<double>)GetValue(Y2AxisScaleProperty); }
            set { SetValue(Y2AxisScaleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Y2AxisScale.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Y2AxisScaleProperty =
            DependencyProperty.Register("Y2AxisScale", typeof(ObservableCollection<double>), typeof(OperationMonitorChartPageControl));
        public string Y2AxisScaleTitle
        {
            get { return (string)GetValue(Y2AxisScaleTitleProperty); }
            set { SetValue(Y2AxisScaleTitleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Y2AxisScaleTitle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Y2AxisScaleTitleProperty =
            DependencyProperty.Register("Y2AxisScaleTitle", typeof(string), typeof(OperationMonitorChartPageControl));


        public ObservableCollection<TimeItemModel> GanttItemsSourceHeader
        {
            get { return (ObservableCollection<TimeItemModel>)GetValue(GanttItemsSourceHeaderProperty); }
            set { SetValue(GanttItemsSourceHeaderProperty, value); }
        }

        // Using a DependencyProperty as the backing store for GanttItemsSourceHeader.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GanttItemsSourceHeaderProperty =
            DependencyProperty.Register("GanttItemsSourceHeader", typeof(ObservableCollection<TimeItemModel>), typeof(OperationMonitorChartPageControl));

        public ObservableCollection<LineLegendGroupModel> ProjectGroupInfo
        {
            get { return (ObservableCollection<LineLegendGroupModel>)GetValue(ProjectGroupInfoProperty); }
            set { SetValue(ProjectGroupInfoProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ProjectGroupInfo.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ProjectGroupInfoProperty =
            DependencyProperty.Register("ProjectGroupInfo", typeof(ObservableCollection<LineLegendGroupModel>), typeof(OperationMonitorChartPageControl));


        public ObservableCollection<GanttProjectModel> LineRowsItem
        {
            get { return (ObservableCollection<GanttProjectModel>)GetValue(LineRowsItemProperty); }
            set { SetValue(LineRowsItemProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LineRowsItem.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LineRowsItemProperty =
            DependencyProperty.Register("LineRowsItem", typeof(ObservableCollection<GanttProjectModel>), typeof(OperationMonitorChartPageControl));

        public ObservableCollection<LineService> LineServiceData
        {
            get { return (ObservableCollection<LineService>)GetValue(LineServiceDataProperty); }
            set { SetValue(LineServiceDataProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LineServiceData.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LineServiceDataProperty =
            DependencyProperty.Register("LineServiceData", typeof(ObservableCollection<LineService>), typeof(OperationMonitorChartPageControl));



        public ObservableCollection<PageChartModel> PageChartList
        {
            get { return (ObservableCollection<PageChartModel>)GetValue(PageChartListProperty); }
            set { SetValue(PageChartListProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PageChartList.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PageChartListProperty =
            DependencyProperty.Register("PageChartList", typeof(ObservableCollection<PageChartModel>), typeof(OperationMonitorChartPageControl));



        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            if (e.Property.Name == "GanttItemsSourceHeader")
            {
                PageChartList = new ObservableCollection<PageChartModel>();
                if (GanttItemsSourceHeader.Count <= 16)
                {
                    PageChartList.Add(new PageChartModel() { PageIndex = 1 });

                }
                else
                {
                    for (int i = 0; i < Convert.ToInt32(Math.Ceiling(GanttItemsSourceHeader.Count / Convert.ToDouble(16))); i++)
                    {
                        PageChartList.Add(new PageChartModel() { PageIndex = i + 1 });
                    }
                }
                this.ItemsSource = PageChartList;

                foreach (var item in this.ItemsSource)
                {
                    int index = (item as PageChartModel).PageIndex;
                    OperationMonitorChartControl chart = this.ItemContainerGenerator.ContainerFromItem(item) as OperationMonitorChartControl;
                    int count = (GanttItemsSourceHeader.Count - (index - 1) * 16) >= 16 ? (index - 1) * 16 + 16 : GanttItemsSourceHeader.Count;
                    ObservableCollection<TimeItemModel> temp = new ObservableCollection<TimeItemModel>();
                    for (int i = (index - 1) * 16; i < count; i++)
                    {
                        temp.Add(GanttItemsSourceHeader[i]);
                    }
                    chart.StartTime = temp[0].TimeName;
                    chart.EndTime = temp[temp.Count - 1].DateTimeList[temp[temp.Count - 1].DateTimeList.Count-1];
                    chart.GanttItemsSourceHeader = new ObservableCollection<TimeItemModel>(temp);
                }
            }
            else if (e.Property.Name == "ProjectGroupInfo")
            {
                foreach (var item in this.ItemsSource)
                {
                    int index = (item as PageChartModel).PageIndex;
                    OperationMonitorChartControl chart = this.ItemContainerGenerator.ContainerFromItem(item) as OperationMonitorChartControl;
                    ObservableCollection<LineLegendGroupModel> temp = new ObservableCollection<LineLegendGroupModel>();
                    LineLegendGroupModel tempGroup = null;
                    int count = 1;

                    foreach (var group in ProjectGroupInfo)
                    {
                        foreach (var legend in group.LegendItemList)
                        {
                            if (legend.ProjectTime >= chart.StartTime && legend.ProjectTime <= chart.EndTime)
                            {
                                if (count == 9)
                                {
                                    tempGroup = new LineLegendGroupModel();
                                    temp.Add(tempGroup);
                                    count = 0;
                                }
                                if (count < 10)
                                {
                                    if (tempGroup == null)
                                    {
                                        tempGroup = new LineLegendGroupModel();
                                        temp.Add(tempGroup);
                                    }
                                    tempGroup.LegendItemList.Add(legend);

                                }
                                count++;
                            }
                        }
                    }
                    chart.ProjectGroupInfo = new ObservableCollection<LineLegendGroupModel>(temp);
                }
            }
            else if (e.Property.Name == "LineServiceData")
            {
                foreach (var item in this.ItemsSource)
                {
                    int index = (item as PageChartModel).PageIndex;
                    OperationMonitorChartControl chart = this.ItemContainerGenerator.ContainerFromItem(item) as OperationMonitorChartControl;
                    ObservableCollection<LineService> temp = new ObservableCollection<LineService>();
                    foreach (var lineData in LineServiceData)
                    {
                        LineService lineService = ObjectMapper.CopyTo<LineService>(lineData);
                        ObservableCollection<LineData> lineDatas = new ObservableCollection<LineData>();
                        foreach (var time in lineData.LineServicesData)
                        {
                            if (time.PointXDate >= chart.StartTime && time.PointXDate <= chart.EndTime.AddMinutes(5))
                            {
                                lineDatas.Add(time);
                            }
                        }
                        lineService.LineServicesData = lineDatas;
                        temp.Add(lineService);
                    }
                    chart.LineServiceData = new ObservableCollection<LineService>(temp);
                }
            }
        }
        /// <summary>
        /// 查找并获取打印机
        /// </summary>
        /// <param name="printerServerName">服务器名字： Lee-pc</param>
        /// <param name="printerName">打印机名字：Hp laserjet m1522 mfp series pcl 6 </param>
        /// <returns></returns>
        public PrintQueue SelectedPrintServer(string printerName)
        {
            try
            {
                LocalPrintServer print = new LocalPrintServer();
                var printers = print.GetPrintQueues();

                var selectedPrinter = printers.FirstOrDefault(d => d.Name == printerName);


                return selectedPrinter;
            }
            catch (Exception)
            {
                return null;//没有找到打印机
            }
        }

        /// <summary>
        /// 设置打印格式
        /// </summary>
        /// <param name="printDialog">打印文档</param>
        /// <param name="pageSize">打印纸张大小 a4</param>
        /// <param name="pageOrientation">打印方向 竖向</param>
        public void SetPrintProperty(PrintDialog printDialog, PageMediaSizeName pageSize = PageMediaSizeName.ISOA4, PageOrientation pageOrientation = PageOrientation.Portrait)
        {
            var printTicket = printDialog.PrintTicket;
            printTicket.PageMediaSize = new PageMediaSize(pageSize);//A4纸
            printTicket.PageOrientation = pageOrientation;//默认竖向打印
        }
        public void PrintControl()
        {
            PrintListWindow window = new PrintListWindow();
            if (window.ShowDialog() == true)
            {
                foreach (var item in this.ItemsSource)
                {
                    OperationMonitorChartControl chart = this.ItemContainerGenerator.ContainerFromItem(item) as OperationMonitorChartControl;
                    var printDialog = new PrintDialog();
                    SetPrintProperty(printDialog);
                    if (window.PrintQueueSelected != null)
                    {
                        printDialog.PrintQueue = window.PrintQueueSelected;

                        Point point = chart.TransformToAncestor(this).Transform(new Point(0, 0));
                        chart.Measure(new Size(chart.ActualWidth, chart.ActualHeight));
                        chart.Arrange(new Rect(new Size(chart.ActualWidth, chart.ActualHeight)));
                        printDialog.PrintVisual(chart, "");
                        chart.Arrange(new Rect(point.X, point.Y, chart.ActualWidth, chart.ActualHeight));
                    }
                }
            }
            
            
        }
    }
    public class OperationMonitorChartControl: ContentControl
    {
        public DateTime StartTime
        {
            get { return (DateTime)GetValue(StartTimeProperty); }
            set { SetValue(StartTimeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for StartTime.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StartTimeProperty =
            DependencyProperty.Register("StartTime", typeof(DateTime), typeof(OperationMonitorChartControl));


        public DateTime EndTime
        {
            get { return (DateTime)GetValue(EndTimeProperty); }
            set { SetValue(EndTimeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for EndTime.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EndTimeProperty =
            DependencyProperty.Register("EndTime", typeof(DateTime), typeof(OperationMonitorChartControl));



        public ObservableCollection<TimeItemModel> GanttItemsSourceHeader
        {
            get { return (ObservableCollection<TimeItemModel>)GetValue(GanttItemsSourceHeaderProperty); }
            set { SetValue(GanttItemsSourceHeaderProperty, value); }
        }

        // Using a DependencyProperty as the backing store for GanttItemsSourceHeader.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GanttItemsSourceHeaderProperty =
            DependencyProperty.Register("GanttItemsSourceHeader", typeof(ObservableCollection<TimeItemModel>), typeof(OperationMonitorChartControl));

        
        public ObservableCollection<LineLegendGroupModel> ProjectGroupInfo
        {
            get { return (ObservableCollection<LineLegendGroupModel>)GetValue(ProjectGroupInfoProperty); }
            set { SetValue(ProjectGroupInfoProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ProjectGroupInfo.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ProjectGroupInfoProperty =
            DependencyProperty.Register("ProjectGroupInfo", typeof(ObservableCollection<LineLegendGroupModel>), typeof(OperationMonitorChartControl));


        public ObservableCollection<LineService> LineServiceData
        {
            get { return (ObservableCollection<LineService>)GetValue(LineServiceDataProperty); }
            set { SetValue(LineServiceDataProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LineServiceData.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LineServiceDataProperty =
            DependencyProperty.Register("LineServiceData", typeof(ObservableCollection<LineService>), typeof(OperationMonitorChartControl));

        protected override void OnRender(DrawingContext drawingContext)
        {
            //base.OnRender(drawingContext);
        }
    }
}

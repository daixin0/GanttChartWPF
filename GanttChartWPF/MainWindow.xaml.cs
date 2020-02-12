using GanttChartControl;
using GanttChartControl.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace GanttChartWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected PropertyChangedEventHandler PropertyChangedHandler
        {
            get
            {
                return PropertyChanged;
            }
        }
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }
        private GanttProjectModel _ganttProjectModel;

        /// <summary>
        /// Get or set GanttProjectModel value
        /// </summary>
        public GanttProjectModel GanttProjectModel
        {
            get { return _ganttProjectModel; }
            set { _ganttProjectModel = value;
                OnPropertyChanged("GanttProjectModel");
            }
        }
        private ObservableCollection<TimeItemModel> _timeItemModels;

        /// <summary>
        /// Get or set TimeItemModels value
        /// </summary>
        public ObservableCollection<TimeItemModel> TimeItemModels
        {
            get { return _timeItemModels; }
            set
            {
                _timeItemModels = value;
                OnPropertyChanged("TimeItemModels");
            }
        }
        private ObservableCollection<LineService> _lineServiceList;

        /// <summary>
        /// Get or set LineService value
        /// </summary>
        public ObservableCollection<LineService> LineServiceList
        {
            get { return _lineServiceList; }
            set
            {
                _lineServiceList = value;
                OnPropertyChanged("LineServiceList");
            }
        }
        private ObservableCollection<GanttProjectModel> _lineRowsItem;

        /// <summary>
        /// Get or set LineRowsItem value
        /// </summary>
        public ObservableCollection<GanttProjectModel> LineRowsItem
        {
            get { return _lineRowsItem; }
            set {
                _lineRowsItem = value;
                OnPropertyChanged("LineRowsItem");
            }
        }
        private ObservableCollection<double> _y1AxisScale;

        /// <summary>
        /// Get or set Y1AxisScale value
        /// </summary>
        public ObservableCollection<double> Y1AxisScale
        {
            get { return _y1AxisScale; }
            set
            {
                _y1AxisScale = value;
                OnPropertyChanged("Y1AxisScale");
            }
        }

        private string _y1AxisScaleTitle;

        /// <summary>
        /// Get or set Y1AxisScaleTitle value
        /// </summary>
        public string Y1AxisScaleTitle
        {
            get { return _y1AxisScaleTitle; }
            set
            {
                _y1AxisScaleTitle = value;
                OnPropertyChanged("Y1AxisScaleTitle");
            }
        }

        private ObservableCollection<double> _y2AxisScale;

        /// <summary>
        /// Get or set Y2AxisScale value
        /// </summary>
        public ObservableCollection<double> Y2AxisScale
        {
            get { return _y2AxisScale; }
            set
            {
                _y2AxisScale = value;
                OnPropertyChanged("Y2AxisScale");
            }
        }
        private string _y2AxisScaleTitle;

        /// <summary>
        /// Get or set Y2AxisScaleTitle value
        /// </summary>
        public string Y2AxisScaleTitle
        {
            get { return _y2AxisScaleTitle; }
            set
            {
                _y2AxisScaleTitle = value;
                OnPropertyChanged("Y2AxisScaleTitle");
            }
        }
        private ObservableCollection<LineLegendGroupModel> _projectInfoList;

        /// <summary>
        /// Get or set ProjectInfoList value
        /// </summary>
        public ObservableCollection<LineLegendGroupModel> ProjectInfoList
        {
            get { return _projectInfoList; }
            set
            {
                _projectInfoList = value;
                OnPropertyChanged("ProjectInfoList");
            }
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GanttProjectModel ganttProjectModel = new GanttProjectModel();
            ganttProjectModel.Children.Add(new GanttProjectModel()
            {
                ProjectName = "用药及输液情况",
                Children = new ObservableCollection<GanttProjectModel>() 
                {
                    new GanttProjectModel() {  ProjectName="1",Value=12, StartTime=new DateTime(2020,1,16,9,40,0),EndTime=new DateTime(2020,1,16,11,20,0)},
                    new GanttProjectModel() {  ProjectName="2",Value=4,UnitName="(mg)",StartTime=new DateTime(2020,1,16,11,20,0)},
                    new GanttProjectModel() {  ProjectName="3",Value=10000,UnitName="(mg)",StartTime=new DateTime(2020,1,16,8,0,0),EndTime=new DateTime(2020,1,16,10,30,0)},
                    new GanttProjectModel() {  ProjectName="4",Value=0.5,UnitName="(mg)",StartTime=new DateTime(2020,1,16,9,0,0)},
                    new GanttProjectModel() {  ProjectName="5",Value=5,UnitName="(mg)",StartTime=new DateTime(2020,1,16,9,45,0)},
                    new GanttProjectModel() {  ProjectName="6",Value=5,UnitName="(mg)",StartTime=new DateTime(2020,1,16,11,0,0)},
                    new GanttProjectModel(),
                    new GanttProjectModel(),
                    new GanttProjectModel(),
                    new GanttProjectModel(),
                    new GanttProjectModel(),
                    new GanttProjectModel()
                }
            });
            ganttProjectModel.Children.Add(new GanttProjectModel()
            {
                ProjectName = "出量",
                Children = new ObservableCollection<GanttProjectModel>() {
                    new GanttProjectModel() {  ProjectName="输液",UnitName="(mg)" ,
                        Children=new ObservableCollection<GanttProjectModel>(){
                    new GanttProjectModel(){  ProjectName="10%葡萄糖",UnitName="(mg)",Value=500,StartTime=new DateTime(2020,1,16,8,30,0),EndTime=new DateTime(2020,1,16,10,30,0)},
                    new GanttProjectModel(){  ProjectName="琥珀系名叫",UnitName="(mg)",Value=500,StartTime=new DateTime(2020,1,16,9,25,0),EndTime=new DateTime(2020,1,16,11,0,0)},
                    new GanttProjectModel(){  ProjectName="测试",UnitName="(mg)",Value=20,StartTime=new DateTime(2020,1,16,11,45,0),EndTime=new DateTime(2020,1,16,12,30,0)},
                    new GanttProjectModel(),
                    new GanttProjectModel(),
                    new GanttProjectModel()
                        } },
                    new GanttProjectModel() {  ProjectName="输血",UnitName="(mg)",Children=new ObservableCollection<GanttProjectModel>(){
                    new GanttProjectModel(){  ProjectName="全血",UnitName="(mg)",Value=300,StartTime=new DateTime(2020,1,16,8,30,0),EndTime=new DateTime(2020,1,16,11,0,0)},new GanttProjectModel()
                    } },
                    new GanttProjectModel() {  ProjectName="出量" ,Value=30,StartTime=new DateTime(2020,1,16,12,30,0),EndTime=new DateTime(2020,1,16,13,0,0)}
                }
            });
            GanttProjectModel = ganttProjectModel;

            ObservableCollection<TimeItemModel> timeItemModels = new ObservableCollection<TimeItemModel>();
            timeItemModels.Add(new TimeItemModel() { TimeName = new DateTime(2020, 1, 16, 8, 0, 0) });
            timeItemModels.Add(new TimeItemModel() { TimeName = new DateTime(2020, 1, 16, 8, 15, 0) });
            timeItemModels.Add(new TimeItemModel() { TimeName = new DateTime(2020, 1, 16, 8, 30, 0) });
            timeItemModels.Add(new TimeItemModel() { TimeName = new DateTime(2020, 1, 16, 8, 45, 0) });
            timeItemModels.Add(new TimeItemModel() { TimeName = new DateTime(2020, 1, 16, 9, 0, 0) });
            timeItemModels.Add(new TimeItemModel() { TimeName = new DateTime(2020, 1, 16, 9, 15, 0) });
            timeItemModels.Add(new TimeItemModel() { TimeName = new DateTime(2020, 1, 16, 9, 30, 0) });
            timeItemModels.Add(new TimeItemModel() { TimeName = new DateTime(2020, 1, 16, 9, 45, 0) });
            timeItemModels.Add(new TimeItemModel() { TimeName = new DateTime(2020, 1, 16, 10, 0, 0) });
            timeItemModels.Add(new TimeItemModel() { TimeName = new DateTime(2020, 1, 16, 10, 15, 0) });
            timeItemModels.Add(new TimeItemModel() { TimeName = new DateTime(2020, 1, 16, 10, 30, 0) });
            timeItemModels.Add(new TimeItemModel() { TimeName = new DateTime(2020, 1, 16, 10, 45, 0) });
            timeItemModels.Add(new TimeItemModel() { TimeName = new DateTime(2020, 1, 16, 11, 0, 0) });
            timeItemModels.Add(new TimeItemModel() { TimeName = new DateTime(2020, 1, 16, 11, 15, 0) });
            timeItemModels.Add(new TimeItemModel() { TimeName = new DateTime(2020, 1, 16, 11, 30, 0) });
            timeItemModels.Add(new TimeItemModel() { TimeName = new DateTime(2020, 1, 16, 11, 45, 0) });
            timeItemModels.Add(new TimeItemModel() { TimeName = new DateTime(2020, 1, 16, 12, 0, 0) });
            timeItemModels.Add(new TimeItemModel() { TimeName = new DateTime(2020, 1, 16, 12, 15, 0) });
            timeItemModels.Add(new TimeItemModel() { TimeName = new DateTime(2020, 1, 16, 12, 30, 0) });
            timeItemModels.Add(new TimeItemModel() { TimeName = new DateTime(2020, 1, 16, 12, 45, 0) });
            timeItemModels.Add(new TimeItemModel() { TimeName = new DateTime(2020, 1, 16, 13, 0, 0) });
            timeItemModels.Add(new TimeItemModel() { TimeName = new DateTime(2020, 1, 16, 13, 15, 0) });
            timeItemModels.Add(new TimeItemModel() { TimeName = new DateTime(2020, 1, 16, 13, 30, 0) });
            timeItemModels.Add(new TimeItemModel() { TimeName = new DateTime(2020, 1, 16, 13, 45, 0) });
            timeItemModels.Add(new TimeItemModel() { TimeName = new DateTime(2020, 1, 16, 14, 0, 0) });
            timeItemModels.Add(new TimeItemModel() { TimeName = new DateTime(2020, 1, 16, 14, 15, 0) });
            timeItemModels.Add(new TimeItemModel() { TimeName = new DateTime(2020, 1, 16, 14, 30, 0) });
            timeItemModels.Add(new TimeItemModel() { TimeName = new DateTime(2020, 1, 16, 14, 45, 0) });
            timeItemModels.Add(new TimeItemModel() { TimeName = new DateTime(2020, 1, 16, 15, 0, 0) });
            timeItemModels.Add(new TimeItemModel() { TimeName = new DateTime(2020, 1, 16, 15, 15, 0) });
            timeItemModels.Add(new TimeItemModel() { TimeName = new DateTime(2020, 1, 16, 15, 30, 0) });
            timeItemModels.Add(new TimeItemModel() { TimeName = new DateTime(2020, 1, 16, 15, 45, 0) });
            TimeItemModels = new ObservableCollection<TimeItemModel>(timeItemModels);




            ObservableCollection<LineService> lineServices = new ObservableCollection<LineService>();
            LineService lineService1 = new LineService();
            LineLegendItemModel legendItemModel1 = new LineLegendItemModel();
            legendItemModel1.Title = "控制呼吸";
            legendItemModel1.Color = new SolidColorBrush(Colors.Red);
            legendItemModel1.TitleIconPath = "M318.25521,252.25 C319.08854,250.65625 319.10959,250.69825 319.09918,250.667 319.08876,250.63575 319.81878,252.2191 319.81878,252.2191 L320.68339,250.76221 321.27771,252.21911 322.02812,250.73099";
            lineService1.LineLegendItem = legendItemModel1;
            lineService1.ChartLineType = ChartLineType.PolylineKnotsType;
            ObservableCollection<LineData> lineDatas1 = new ObservableCollection<LineData>();
            lineDatas1.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 8, 0, 0), PointY = 125 });
            lineDatas1.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 8, 5, 0), PointY = 125 });
            lineDatas1.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 8, 10, 0), PointY = 125 });
            lineDatas1.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 8, 15, 0), PointY = 113 });
            lineDatas1.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 8, 20, 0), PointY = 125 });
            lineDatas1.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 8, 25, 0), PointY = 125 });
            lineDatas1.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 8, 30, 0), PointY = 108 });
            lineDatas1.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 8, 35, 0), PointY = 105 });
            lineDatas1.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 8, 40, 0), PointY = 125 });
            lineDatas1.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 8, 45, 0), PointY = 105 });
            lineDatas1.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 8, 50, 0), PointY = 125 });
            lineDatas1.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 8, 55, 0), PointY = 140 });
            lineDatas1.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 9, 0, 0), PointY = 120 });
            lineDatas1.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 9, 5, 0), PointY = 120 });
            lineDatas1.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 9, 10, 0), PointY = 280 });
            lineDatas1.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 9, 15, 0), PointY = 110 });
            lineDatas1.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 9, 20, 0), PointY = 120 });
            lineDatas1.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 9, 25, 0), PointY = 120 });
            lineDatas1.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 9, 30, 0), PointY = 102 });
            lineDatas1.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 9, 35, 0), PointY = 120 });
            lineDatas1.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 9, 40, 0), PointY = 131 });
            lineDatas1.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 9, 45, 0), PointY = 120 });
            lineDatas1.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 9, 50, 0), PointY = 108 });
            lineDatas1.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 9, 55, 0), PointY = 120 });
            lineDatas1.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 10, 0, 0), PointY = 160 });
            lineDatas1.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 10, 5, 0), PointY = 120 });
            lineDatas1.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 10, 10, 0), PointY = 120 });
            lineDatas1.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 10, 15, 0), PointY = 130 });
            lineDatas1.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 10, 20, 0), PointY = 120 });
            lineDatas1.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 10, 25, 0), PointY = 120 });
            lineDatas1.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 10, 30, 0), PointY = 130 });
            lineDatas1.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 10, 35, 0), PointY = 120 });
            lineDatas1.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 10, 40, 0), PointY = 120 });
            lineDatas1.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 10, 45, 0), PointY = 135 });
            lineDatas1.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 10, 50, 0), PointY = 120 });
            lineDatas1.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 10, 55, 0), PointY = 120 });
            lineDatas1.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 11, 0, 0), PointY = 133 });
            lineDatas1.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 11, 5, 0), PointY = 120 });
            lineDatas1.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 11, 10, 0), PointY = 142 });
            lineDatas1.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 11, 15, 0), PointY = 120 });
            lineDatas1.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 11, 20, 0), PointY = 120 });
            lineDatas1.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 11, 25, 0), PointY = 120 });
            lineDatas1.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 11, 30, 0), PointY = 120 });
            lineDatas1.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 11, 35, 0), PointY = 120 });
            lineDatas1.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 11, 40, 0), PointY = 120 });
            lineDatas1.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 11, 45, 0), PointY = 120 });
            lineDatas1.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 11, 50, 0), PointY = 120 });
            lineDatas1.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 11, 55, 0), PointY = 145 });
            lineDatas1.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 12, 0, 0), PointY = 126 });
            lineDatas1.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 12, 5, 0), PointY = 137 });
            lineDatas1.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 12, 10, 0), PointY = 120 });
            lineDatas1.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 12, 15, 0), PointY = 120 });
            lineDatas1.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 12, 20, 0), PointY = 120 });
            lineDatas1.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 12, 25, 0), PointY = 120 });
            lineService1.LineServicesData = lineDatas1;
            LineService lineService2 = new LineService();
            LineLegendItemModel legendItemModel2 = new LineLegendItemModel();
            legendItemModel2.Title = "动脉舒张压";
            legendItemModel2.Color = new SolidColorBrush(Colors.Red);
            legendItemModel2.TitleIcon = "∧";
            lineService2.LineLegendItem = legendItemModel2;
            lineService2.ChartLineType = ChartLineType.PolylineKnotsType;
            ObservableCollection<LineData> lineDatas2 = new ObservableCollection<LineData>();
            lineDatas2.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 8, 0, 0), PointY = 125 });
            lineDatas2.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 8, 5, 0), PointY = 125 });
            lineDatas2.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 8, 10, 0), PointY = 125 });
            lineDatas2.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 8, 15, 0), PointY = 125 });
            lineDatas2.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 8, 20, 0), PointY = 125 });
            lineDatas2.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 8, 25, 0), PointY = 125 });
            lineDatas2.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 8, 30, 0), PointY = 125 });
            lineDatas2.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 8, 35, 0), PointY = 125 });
            lineDatas2.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 8, 40, 0), PointY = 125 });
            lineDatas2.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 8, 45, 0), PointY = 125 });
            lineDatas2.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 8, 50, 0), PointY = 125 });
            lineDatas2.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 8, 55, 0), PointY = 125 });
            lineDatas2.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 9, 0, 0), PointY = 125 });
            lineDatas2.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 9, 5, 0), PointY = 125 });
            lineDatas2.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 9, 10, 0), PointY = 125 });
            lineDatas2.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 9, 15, 0), PointY = 125 });
            lineDatas2.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 9, 20, 0), PointY = 125 });
            lineDatas2.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 9, 25, 0), PointY = 125 });
            lineDatas2.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 9, 30, 0), PointY = 125 });
            lineDatas2.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 9, 35, 0), PointY = 125 });
            lineDatas2.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 9, 40, 0), PointY = 125 });
            lineDatas2.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 9, 45, 0), PointY = 125 });
            lineDatas2.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 9, 50, 0), PointY = 125 });
            lineDatas2.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 9, 55, 0), PointY = 125 });
            lineDatas2.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 10, 0, 0), PointY = 125 });
            lineDatas2.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 10, 5, 0), PointY = 125 });
            lineDatas2.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 10, 10, 0), PointY = 125 });
            lineDatas2.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 10, 15, 0), PointY = 125 });
            lineDatas2.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 10, 20, 0), PointY = 125 });
            lineDatas2.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 10, 25, 0), PointY = 125 });
            lineDatas2.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 10, 30, 0), PointY = 125 });
            lineDatas2.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 10, 35, 0), PointY = 125 });
            lineDatas2.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 10, 40, 0), PointY = 125 });
            lineDatas2.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 10, 45, 0), PointY = 125 });
            lineDatas2.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 10, 50, 0), PointY = 125 });
            lineDatas2.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 10, 55, 0), PointY = 125 });
            lineDatas2.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 11, 0, 0), PointY = 125 });
            lineDatas2.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 11, 5, 0), PointY = 125 });
            lineDatas2.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 11, 10, 0), PointY = 125 });
            lineDatas2.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 11, 15, 0), PointY = 125 });
            lineService2.LineServicesData = lineDatas2;
            LineService lineService3 = new LineService();
            LineLegendItemModel legendItemModel3 = new LineLegendItemModel();
            legendItemModel3.Title = "动脉收缩压";
            legendItemModel3.Color = new SolidColorBrush(Colors.Red);
            legendItemModel3.TitleIcon = "∨";
            lineService3.LineLegendItem = legendItemModel3;
            lineService3.ChartLineType = ChartLineType.PolylineKnotsType;
            ObservableCollection<LineData> lineDatas3 = new ObservableCollection<LineData>();
            lineDatas3.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 8, 0, 0), PointY = 125 });
            lineDatas3.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 8, 5, 0), PointY = 125 });
            lineDatas3.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 8, 10, 0), PointY = 125 });
            lineDatas3.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 8, 15, 0), PointY = 125 });
            lineDatas3.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 8, 20, 0), PointY = 125 });
            lineDatas3.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 8, 25, 0), PointY = 125 });
            lineDatas3.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 8, 30, 0), PointY = 125 });
            lineDatas3.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 8, 35, 0), PointY = 125 });
            lineDatas3.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 8, 40, 0), PointY = 125 });
            lineDatas3.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 8, 45, 0), PointY = 125 });
            lineDatas3.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 8, 50, 0), PointY = 125 });
            lineDatas3.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 8, 55, 0), PointY = 125 });
            lineDatas3.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 9, 0, 0), PointY = 125 });
            lineDatas3.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 9, 5, 0), PointY = 125 });
            lineDatas3.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 9, 10, 0), PointY = 125 });
            lineDatas3.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 9, 15, 0), PointY = 125 });
            lineDatas3.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 9, 20, 0), PointY = 125 });
            lineDatas3.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 9, 25, 0), PointY = 125 });
            lineDatas3.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 9, 30, 0), PointY = 125 });
            lineDatas3.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 9, 35, 0), PointY = 125 });
            lineDatas3.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 9, 40, 0), PointY = 125 });
            lineDatas3.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 9, 45, 0), PointY = 125 });
            lineDatas3.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 9, 50, 0), PointY = 125 });
            lineDatas3.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 9, 55, 0), PointY = 125 });
            lineDatas3.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 10, 0, 0), PointY = 125 });
            lineDatas3.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 10, 5, 0), PointY = 125 });
            lineDatas3.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 10, 10, 0), PointY = 125 });
            lineDatas3.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 10, 15, 0), PointY = 125 });
            lineDatas3.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 10, 20, 0), PointY = 125 });
            lineDatas3.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 10, 25, 0), PointY = 125 });
            lineDatas3.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 10, 30, 0), PointY = 125 });
            lineDatas3.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 10, 35, 0), PointY = 125 });
            lineDatas3.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 10, 40, 0), PointY = 125 });
            lineDatas3.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 10, 45, 0), PointY = 125 });
            lineDatas3.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 10, 50, 0), PointY = 125 });
            lineDatas3.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 10, 55, 0), PointY = 125 });
            lineDatas3.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 11, 0, 0), PointY = 125 });
            lineDatas3.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 11, 5, 0), PointY = 125 });
            lineDatas3.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 11, 10, 0), PointY = 125 });
            lineDatas3.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 11, 15, 0), PointY = 125 });
            lineService3.LineServicesData = lineDatas3;
            LineService lineService4 = new LineService();
            LineLegendItemModel legendItemModel4 = new LineLegendItemModel();
            legendItemModel4.Title = "心率";
            legendItemModel4.Color = new SolidColorBrush(Colors.Green);
            legendItemModel4.TitleIcon = "•";
            lineService4.LineLegendItem = legendItemModel4;
            lineService4.ChartLineType = ChartLineType.PolylineKnotsType;
            ObservableCollection<LineData> lineDatas4 = new ObservableCollection<LineData>();
            lineDatas4.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 8, 0, 0), PointY = 125 });
            lineDatas4.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 8, 5, 0), PointY = 125 });
            lineDatas4.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 8, 10, 0), PointY = 125 });
            lineDatas4.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 8, 15, 0), PointY = 125 });
            lineDatas4.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 8, 20, 0), PointY = 125 });
            lineDatas4.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 8, 25, 0), PointY = 125 });
            lineDatas4.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 8, 30, 0), PointY = 125 });
            lineDatas4.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 8, 35, 0), PointY = 125 });
            lineDatas4.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 8, 40, 0), PointY = 125 });
            lineDatas4.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 8, 45, 0), PointY = 125 });
            lineDatas4.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 8, 50, 0), PointY = 125 });
            lineDatas4.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 8, 55, 0), PointY = 125 });
            lineDatas4.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 9, 0, 0), PointY = 125 });
            lineDatas4.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 9, 5, 0), PointY = 125 });
            lineDatas4.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 9, 10, 0), PointY = 125 });
            lineDatas4.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 9, 15, 0), PointY = 125 });
            lineDatas4.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 9, 20, 0), PointY = 125 });
            lineDatas4.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 9, 25, 0), PointY = 125 });
            lineDatas4.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 9, 30, 0), PointY = 125 });
            lineDatas4.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 9, 35, 0), PointY = 125 });
            lineDatas4.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 9, 40, 0), PointY = 125 });
            lineDatas4.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 9, 45, 0), PointY = 125 });
            lineDatas4.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 9, 50, 0), PointY = 125 });
            lineDatas4.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 9, 55, 0), PointY = 125 });
            lineDatas4.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 10, 0, 0), PointY = 125 });
            lineDatas4.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 10, 5, 0), PointY = 125 });
            lineDatas4.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 10, 10, 0), PointY = 125 });
            lineDatas4.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 10, 15, 0), PointY = 125 });
            lineDatas4.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 10, 20, 0), PointY = 125 });
            lineDatas4.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 10, 25, 0), PointY = 125 });
            lineDatas4.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 10, 30, 0), PointY = 125 });
            lineDatas4.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 10, 35, 0), PointY = 125 });
            lineDatas4.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 10, 40, 0), PointY = 125 });
            lineDatas4.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 10, 45, 0), PointY = 125 });
            lineDatas4.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 10, 50, 0), PointY = 125 });
            lineDatas4.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 10, 55, 0), PointY = 125 });
            lineDatas4.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 11, 0, 0), PointY = 125 });
            lineDatas4.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 11, 5, 0), PointY = 125 });
            lineDatas4.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 11, 10, 0), PointY = 125 });
            lineDatas4.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 11, 15, 0), PointY = 125 });
            lineService4.LineServicesData = lineDatas4;


            LineService lineService51 = new LineService();
            lineService51.LineLegendTopItem = new LineLegendItemModel() { Title = "Sp02", Color = new SolidColorBrush(Colors.Blue) };
            lineService51.ChartLineType = ChartLineType.Number;
            lineService51.TopItemIndex = 0;
            ObservableCollection<LineData> lineDatas51 = new ObservableCollection<LineData>();
            lineDatas51.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 8, 0, 0),DataValue=92 });
            lineDatas51.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 8, 10, 0), DataValue = 92 });
            lineDatas51.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 8, 20, 0), DataValue = 92 });
            lineDatas51.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 8, 30, 0), DataValue = 92 });
            lineDatas51.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 8, 40, 0), DataValue = 92 });
            lineDatas51.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 8, 50, 0), DataValue = 92 });
            lineDatas51.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 9, 0, 0), DataValue = 90 });
            lineDatas51.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 9, 10, 0), DataValue = 90 });
            lineDatas51.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 9, 20, 0), DataValue = 90 });
            lineDatas51.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 9, 30, 0), DataValue = 90 });
            lineDatas51.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 9, 40, 0), DataValue = 90 });
            lineDatas51.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 9, 50, 0), DataValue = 90 });
            lineDatas51.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 10, 0, 0), DataValue = 90 });
            lineDatas51.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 10, 10, 0), DataValue = 90 });
            lineDatas51.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 10, 20, 0), DataValue = 90 });
            lineDatas51.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 10, 30, 0), DataValue = 90 });
            lineDatas51.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 10, 40, 0), DataValue = 90 });
            lineDatas51.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 10, 50, 0), DataValue = 90 });
            lineDatas51.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 11, 0, 0), DataValue = 90 });
            lineDatas51.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 11, 10, 0), DataValue = 90 });
            lineService51.LineServicesData = lineDatas51;
            LineService lineService52 = new LineService();
            lineService52.LineLegendTopItem = new LineLegendItemModel() { Title = "Etc02", Color = new SolidColorBrush(Colors.Blue) };
            lineService52.ChartLineType = ChartLineType.Number;
            lineService52.TopItemIndex = 1;
            ObservableCollection<LineData> lineDatas52 = new ObservableCollection<LineData>();
            lineDatas52.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 8, 50, 0), DataValue = 20 });
            lineDatas52.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 9, 0, 0), DataValue = 20 });
            lineDatas52.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 9, 10, 0), DataValue = 20 });
            lineDatas52.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 9, 20, 0), DataValue = 20 });
            lineDatas52.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 9, 30, 0), DataValue = 20 });
            lineDatas52.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 9, 40, 0), DataValue = 20 });
            lineDatas52.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 9, 50, 0), DataValue = 20 });
            lineDatas52.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 10, 0, 0), DataValue = 20 });
            lineDatas52.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 10, 10, 0), DataValue = 20 });
            lineDatas52.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 10, 20, 0), DataValue = 20 });
            lineDatas52.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 10, 30, 0), DataValue = 20 });
            lineDatas52.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 10, 40, 0), DataValue = 20 });
            lineDatas52.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 10, 50, 0), DataValue = 20 });
            lineDatas52.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 11, 0, 0), DataValue = 20 });
            lineDatas52.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 11, 10, 0), DataValue = 20 });
            lineService52.LineServicesData = lineDatas52;

            LineService lineService5 = new LineService();
            LineLegendItemModel legendItemModel5 = new LineLegendItemModel();
            legendItemModel5.Title = "中心静脉压";
            legendItemModel5.Color = new SolidColorBrush(Colors.Red);
            legendItemModel5.TitleIcon = "＋";
            lineService5.LineLegendItem = legendItemModel5;
            lineService5.LineLegendTopItem = new LineLegendItemModel() { Title = "中心静脉压", Color = new SolidColorBrush(Colors.Red) };
            lineService5.ChartLineType = ChartLineType.Number;
            lineService5.TopItemIndex = 2;
            ObservableCollection<LineData> lineDatas5 = new ObservableCollection<LineData>();
            lineDatas5.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 8, 50, 0), DataValue = 5 });
            lineDatas5.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 9, 0, 0), DataValue = 5 });
            lineDatas5.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 9, 10, 0), DataValue = 5 });
            lineDatas5.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 9, 20, 0), DataValue = 5 });
            lineDatas5.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 9, 30, 0), DataValue = 5 });
            lineDatas5.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 9, 40, 0), DataValue = 5 });
            lineDatas5.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 9, 50, 0), DataValue = 5 });
            lineDatas5.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 10, 0, 0), DataValue = 5 });
            lineDatas5.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 10, 10, 0), DataValue = 5 });
            lineDatas5.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 10, 20, 0), DataValue = 5 });
            lineDatas5.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 10, 30, 0), DataValue = 5 });
            lineDatas5.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 10, 40, 0), DataValue = 5 });
            lineDatas5.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 10, 50, 0), DataValue = 5 });
            lineDatas5.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 11, 0, 0), DataValue = 5 });
            lineDatas5.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 11, 10, 0), DataValue = 5 });
            lineService5.LineServicesData = lineDatas5;


            LineService lineService53 = new LineService();
            lineService53.LineLegendTopItem = new LineLegendItemModel() { Color = new SolidColorBrush(Colors.Blue) };
            lineService53.ChartLineType = ChartLineType.Description;
            lineService53.TopItemIndex = 3;
            ObservableCollection<LineData> lineDatas53 = new ObservableCollection<LineData>();
            lineDatas53.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 10, 40, 0), InfoDescription = "静脉血气" });
            lineService53.LineServicesData = lineDatas53;

            LineService lineService54 = new LineService();
            lineService54.LineLegendTopItem = new LineLegendItemModel() { Color = new SolidColorBrush(Colors.Blue) };
            lineService54.ChartLineType = ChartLineType.Description;
            lineService54.TopItemIndex = 4;
            ObservableCollection<LineData> lineDatas54 = new ObservableCollection<LineData>();
            lineDatas54.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 10, 40, 0), InfoDescription = "BE(B)=0.7" });
            lineService54.LineServicesData = lineDatas54;

            LineService lineService55 = new LineService();
            lineService55.LineLegendTopItem = new LineLegendItemModel() { Color = new SolidColorBrush(Colors.Blue) };
            lineService55.ChartLineType = ChartLineType.Description;
            lineService55.TopItemIndex = 5;
            ObservableCollection<LineData> lineDatas55 = new ObservableCollection<LineData>();
            lineDatas55.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 10, 40, 0), InfoDescription = "BEecf=12" });
            lineService55.LineServicesData = lineDatas55;

            LineService lineService56 = new LineService();
            lineService56.LineLegendTopItem = new LineLegendItemModel() { Color = new SolidColorBrush(Colors.Blue) };
            lineService56.ChartLineType = ChartLineType.Description;
            lineService56.TopItemIndex = 6;
            ObservableCollection<LineData> lineDatas56 = new ObservableCollection<LineData>();
            lineDatas56.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 10, 40, 0), InfoDescription = "Ca++=6.9" });
            lineService56.LineServicesData = lineDatas56;

            LineService lineService57 = new LineService();
            lineService57.LineLegendTopItem = new LineLegendItemModel() { Color = new SolidColorBrush(Colors.Blue) };
            lineService57.ChartLineType = ChartLineType.Description;
            lineService57.TopItemIndex = 7;
            ObservableCollection<LineData> lineDatas57 = new ObservableCollection<LineData>();
            lineDatas57.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 10, 40, 0), InfoDescription = "Ca++(7.4)=5.2" });
            lineService57.LineServicesData = lineDatas57;

            LineService lineService58 = new LineService();
            lineService58.LineLegendTopItem = new LineLegendItemModel() { Color = new SolidColorBrush(Colors.Blue) };
            lineService58.ChartLineType = ChartLineType.Description;
            lineService58.TopItemIndex = 8;
            ObservableCollection<LineData> lineDatas58 = new ObservableCollection<LineData>();
            lineDatas58.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 10, 40, 0), InfoDescription = "HC03-=18" });
            lineService58.LineServicesData = lineDatas58;

            LineService lineService59 = new LineService();
            lineService59.LineLegendTopItem = new LineLegendItemModel() { Color = new SolidColorBrush(Colors.Blue) };
            lineService59.ChartLineType = ChartLineType.Description;
            lineService59.TopItemIndex = 9;
            ObservableCollection<LineData> lineDatas59 = new ObservableCollection<LineData>();
            lineDatas59.Add(new LineData() { PointXDate = new DateTime(2020, 1, 16, 10, 40, 0), InfoDescription = "HC03std=20" });
            lineService59.LineServicesData = lineDatas59;

            LineService lineService6 = new LineService();
            LineLegendItemModel legendItemModel6 = new LineLegendItemModel();
            legendItemModel6.Title = "麻醉开始";
            legendItemModel6.Color = new SolidColorBrush(Colors.Black);
            legendItemModel6.TitleIcon = "×";
            lineService6.LineLegendItem = legendItemModel6;
            lineService6.ChartLineType = ChartLineType.Knots;
            lineService6.LineServicesData = new ObservableCollection<LineData>() { new LineData() { PointXDate = new DateTime(2020, 1, 16, 8, 30, 0), PointY = 0 } };
            LineService lineService7 = new LineService();
            LineLegendItemModel legendItemModel7 = new LineLegendItemModel();
            legendItemModel7.Title = "手术开始";
            legendItemModel7.Color = new SolidColorBrush(Colors.Black);
            legendItemModel7.TitleIcon = "☉";
            lineService7.LineLegendItem = legendItemModel7;
            lineService7.ChartLineType = ChartLineType.Knots;
            lineService7.LineServicesData = new ObservableCollection<LineData>() { new LineData() { PointXDate = new DateTime(2020, 1, 16, 8, 50, 0), PointY = 0 } };
            LineService lineService8 = new LineService();
            LineLegendItemModel legendItemModel8 = new LineLegendItemModel();
            legendItemModel8.Title = "手术结束";
            legendItemModel8.Color = new SolidColorBrush(Colors.Red);
            legendItemModel8.TitleIcon = "Ⓧ";
            lineService8.LineLegendItem = legendItemModel8;
            lineService8.ChartLineType = ChartLineType.Knots;
            lineService8.LineServicesData = new ObservableCollection<LineData>() { new LineData() { PointXDate = new DateTime(2020, 1, 16, 11, 0, 0), PointY = 0 } };
            LineService lineService9 = new LineService();
            LineLegendItemModel legendItemModel9 = new LineLegendItemModel();
            legendItemModel9.Title = "麻醉结束";
            legendItemModel9.Color = new SolidColorBrush(Colors.Red);
            legendItemModel9.TitleIcon = "×";
            lineService9.LineLegendItem = legendItemModel9;
            lineService9.ChartLineType = ChartLineType.Knots;
            lineService9.LineServicesData = new ObservableCollection<LineData>() { new LineData() { PointXDate = new DateTime(2020, 1, 16, 12, 30, 0), PointY = 0 } };

            lineServices.Add(lineService1);
            lineServices.Add(lineService2);
            lineServices.Add(lineService3);
            lineServices.Add(lineService4);
            lineServices.Add(lineService51);
            lineServices.Add(lineService52);
            lineServices.Add(lineService53);
            lineServices.Add(lineService54);
            lineServices.Add(lineService55);
            lineServices.Add(lineService56);
            lineServices.Add(lineService57);
            lineServices.Add(lineService58);
            lineServices.Add(lineService59);
            lineServices.Add(lineService5);
            lineServices.Add(lineService6);
            lineServices.Add(lineService7);
            lineServices.Add(lineService8);
            lineServices.Add(lineService9);
            LineServiceList = new ObservableCollection<LineService>(lineServices);


            ObservableCollection<GanttProjectModel> ganttProjectModels = new ObservableCollection<GanttProjectModel>();

            for (int i = 0; i < 38; i++)
            {
                ganttProjectModels.Add(new GanttProjectModel());
            }

            LineRowsItem = new ObservableCollection<GanttProjectModel>(ganttProjectModels);

            Y1AxisScaleTitle = "脉搏/血压nnHg";
            ObservableCollection<double> tempY1Axis = new ObservableCollection<double>();
            tempY1Axis.Add(0);
            tempY1Axis.Add(20);
            tempY1Axis.Add(40);
            tempY1Axis.Add(60);
            tempY1Axis.Add(80);
            tempY1Axis.Add(100);
            tempY1Axis.Add(120);
            tempY1Axis.Add(140);
            tempY1Axis.Add(160);
            tempY1Axis.Add(180);
            tempY1Axis.Add(200);
            tempY1Axis.Add(220);
            tempY1Axis.Add(240);
            tempY1Axis.Add(260);
            ObservableCollection<double> temp1 = new ObservableCollection<double>();
            foreach (var item in tempY1Axis.OrderByDescending(p=>p).ToList())
            {
                temp1.Add(item);
            }

            Y1AxisScale = new ObservableCollection<double>(temp1);

            Y2AxisScaleTitle = "摄氏度";
            ObservableCollection<double> tempY2Axis = new ObservableCollection<double>();
            tempY2Axis.Add(10);
            tempY2Axis.Add(12);
            tempY2Axis.Add(14);
            tempY2Axis.Add(16);
            tempY2Axis.Add(18);
            tempY2Axis.Add(20);
            tempY2Axis.Add(22);
            tempY2Axis.Add(24);
            tempY2Axis.Add(26);
            tempY2Axis.Add(28);
            tempY2Axis.Add(30);
            tempY2Axis.Add(32);
            tempY2Axis.Add(34);
            tempY2Axis.Add(36);
            tempY2Axis.Add(38);
            tempY2Axis.Add(40);
            ObservableCollection<double> temp2 = new ObservableCollection<double>();
            foreach (var item in tempY2Axis.OrderByDescending(p => p).ToList())
            {
                temp2.Add(item);
            }

            Y2AxisScale = new ObservableCollection<double>(temp2);



            ObservableCollection<LineLegendGroupModel> lineLegendItems = new ObservableCollection<LineLegendGroupModel>();


            lineLegendItems.Add(new LineLegendGroupModel()
            {
                LegendItemList = new ObservableCollection<LineLegendProjectItemModel>()
                {
                    new LineLegendProjectItemModel() { Index = 1, ProjectTime = new DateTime(2020, 1, 16, 8, 10, 0), Title = "入手术室" },
                    new LineLegendProjectItemModel() { Index = 2, ProjectTime = new DateTime(2020, 1, 16, 8, 30, 0), Title = "麻醉开始" },
                    new LineLegendProjectItemModel() { Index = 3, ProjectTime = new DateTime(2020, 1, 16, 8, 45, 0), Title = "颈内静脉穿刺并置管" },
                    new LineLegendProjectItemModel() { Index = 4, ProjectTime = new DateTime(2020, 1, 16, 8, 50, 0), Title = "手术开始" },
                    new LineLegendProjectItemModel() { Index = 5, ProjectTime = new DateTime(2020, 1, 16, 9, 0, 0), Title = "局麻+肾上腺素" },
                    new LineLegendProjectItemModel() { Index = 6, ProjectTime = new DateTime(2020, 1, 16, 10, 0, 0), Title = "上止血带" },
                    new LineLegendProjectItemModel() { Index = 7, ProjectTime = new DateTime(2020, 1, 16, 10, 30, 0), Title = "局麻+肾上腺素" },
                    new LineLegendProjectItemModel() { Index = 8, ProjectTime = new DateTime(2020, 1, 16, 11, 0, 0), Title = "手术结束" }
                }
            });
            lineLegendItems.Add(new LineLegendGroupModel()
            {
                LegendItemList = new ObservableCollection<LineLegendProjectItemModel>()
                {
                    new LineLegendProjectItemModel() { Index = 9, ProjectTime = new DateTime(2020, 1, 16, 11, 30, 0), Title = "麻醉结束" },
                    new LineLegendProjectItemModel() { Index = 10, ProjectTime = new DateTime(2020, 1, 16, 12, 0, 0), Title = "放止血带" },
                    new LineLegendProjectItemModel() { Index = 11, ProjectTime = new DateTime(2020, 1, 16, 12, 15, 0), Title = "出手术室" },
                    new LineLegendProjectItemModel() { Index = 12, ProjectTime = new DateTime(2020, 1, 16, 12, 30, 0), Title = "测1" },
                    new LineLegendProjectItemModel() { Index = 13, ProjectTime = new DateTime(2020, 1, 16, 12, 40, 0), Title = "测2" },
                    new LineLegendProjectItemModel() { Index = 14, ProjectTime = new DateTime(2020, 1, 16, 12, 50, 0), Title = "测3" },
                    new LineLegendProjectItemModel() { Index = 15, ProjectTime = new DateTime(2020, 1, 16, 13, 10, 0), Title = "测4" },
                    new LineLegendProjectItemModel() { Index = 16, ProjectTime = new DateTime(2020, 1, 16, 13, 15, 0), Title = "测5" }
                }
            });

            ProjectInfoList = new ObservableCollection<LineLegendGroupModel>(lineLegendItems);

        }
        public void GetTreeChildren(ObservableCollection<GanttProjectModel> list,GanttProjectModel tree)
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            chart.PrintControl();
        }
    }
}

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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GanttProjectModel ganttProjectModel = new GanttProjectModel();
            ganttProjectModel.Children.Add(new GanttProjectModel()
            {
                ProjectName = "用药及输液情况",
                Children = new ObservableCollection<GanttProjectModel>() {
                    new GanttProjectModel() {  ProjectName="1",StartTime=new DateTime(2020,1,16,9,40,0),EndTime=new DateTime(2020,1,16,11,20,0)},
                    new GanttProjectModel() {  ProjectName="2"},
                    new GanttProjectModel() {  ProjectName="3",StartTime=new DateTime(2020,1,16,8,0,0),EndTime=new DateTime(2020,1,16,10,30,0)},
                    new GanttProjectModel() {  ProjectName="4"},
                    new GanttProjectModel() {  ProjectName="5"},
                    new GanttProjectModel() {  ProjectName="6"},
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
                    new GanttProjectModel() {  ProjectName="输液" ,
                        Children=new ObservableCollection<GanttProjectModel>(){
                    new GanttProjectModel(){  ProjectName="10%葡萄糖",StartTime=new DateTime(2020,1,16,8,30,0),EndTime=new DateTime(2020,1,16,10,30,0)},
                    new GanttProjectModel(){  ProjectName="琥珀系名叫",StartTime=new DateTime(2020,1,16,9,25,0),EndTime=new DateTime(2020,1,16,11,0,0)},
                    new GanttProjectModel(),
                    new GanttProjectModel(),
                    new GanttProjectModel(),
                    new GanttProjectModel()
                        } },
                    new GanttProjectModel() {  ProjectName="输血",Children=new ObservableCollection<GanttProjectModel>(){
                    new GanttProjectModel(){  ProjectName="全血",StartTime=new DateTime(2020,1,16,8,30,0),EndTime=new DateTime(2020,1,16,11,0,0)},new GanttProjectModel()
                    } },
                    new GanttProjectModel() {  ProjectName="出量" }
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
            TimeItemModels = new ObservableCollection<TimeItemModel>(timeItemModels);




            ObservableCollection<LineService> lineServices = new ObservableCollection<LineService>();
            LineService lineService1 = new LineService();
            LineLegendItemModel legendItemModel1 = new LineLegendItemModel();
            legendItemModel1.Title = "控制呼吸";
            legendItemModel1.TitleBrush = new SolidColorBrush(Colors.Red);
            lineService1.LineLegendItem = legendItemModel1;
            ObservableCollection<LineData> lineDatas1 = new ObservableCollection<LineData>();
            lineDatas1.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 8, 0, 0), PointY = 125 });
            lineDatas1.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 8, 5, 0), PointY = 125 });
            lineDatas1.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 8, 10, 0), PointY = 125 });
            lineDatas1.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 8, 15, 0), PointY = 113 });
            lineDatas1.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 8, 20, 0), PointY = 125 });
            lineDatas1.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 8, 25, 0), PointY = 125 });
            lineDatas1.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 8, 30, 0), PointY = 108 });
            lineDatas1.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 8, 35, 0), PointY = 105 });
            lineDatas1.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 8, 40, 0), PointY = 125 });
            lineDatas1.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 8, 45, 0), PointY = 105 });
            lineDatas1.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 8, 50, 0), PointY = 125 });
            lineDatas1.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 8, 55, 0), PointY = 140 });
            lineDatas1.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 9, 0, 0), PointY = 120 });
            lineDatas1.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 9, 5, 0), PointY = 120 });
            lineDatas1.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 9, 10, 0), PointY = 120 });
            lineDatas1.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 9, 15, 0), PointY = 110 });
            lineDatas1.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 9, 20, 0), PointY = 120 });
            lineDatas1.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 9, 25, 0), PointY = 120 });
            lineDatas1.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 9, 30, 0), PointY = 102 });
            lineDatas1.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 9, 35, 0), PointY = 120 });
            lineDatas1.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 9, 40, 0), PointY = 131 });
            lineDatas1.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 9, 45, 0), PointY = 120 });
            lineDatas1.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 9, 50, 0), PointY = 108 });
            lineDatas1.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 9, 55, 0), PointY = 120 });
            lineDatas1.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 10, 0, 0), PointY = 160 });
            lineDatas1.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 10, 5, 0), PointY = 120 });
            lineDatas1.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 10, 10, 0), PointY = 120 });
            lineDatas1.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 10, 15, 0), PointY = 130 });
            lineDatas1.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 10, 20, 0), PointY = 120 });
            lineDatas1.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 10, 25, 0), PointY = 120 });
            lineDatas1.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 10, 30, 0), PointY = 130 });
            lineDatas1.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 10, 35, 0), PointY = 120 });
            lineDatas1.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 10, 40, 0), PointY = 120 });
            lineDatas1.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 10, 45, 0), PointY = 135 });
            lineDatas1.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 10, 50, 0), PointY = 120 });
            lineDatas1.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 10, 55, 0), PointY = 120 });
            lineDatas1.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 11, 0, 0), PointY = 133 });
            lineDatas1.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 11, 5, 0), PointY = 120 });
            lineDatas1.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 11, 10, 0), PointY = 142 });
            lineDatas1.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 11, 15, 0), PointY = 120 });
            lineService1.LineServicesData = lineDatas1;
            LineService lineService2 = new LineService();
            LineLegendItemModel legendItemModel2 = new LineLegendItemModel();
            legendItemModel2.Title = "动脉舒张压";
            legendItemModel2.TitleBrush = new SolidColorBrush(Colors.Red);
            lineService2.LineLegendItem = legendItemModel2;
            ObservableCollection<LineData> lineDatas2 = new ObservableCollection<LineData>();
            lineDatas2.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 8, 0, 0), PointY = 125 });
            lineDatas2.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 8, 5, 0), PointY = 125 });
            lineDatas2.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 8, 10, 0), PointY = 125 });
            lineDatas2.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 8, 15, 0), PointY = 125 });
            lineDatas1.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 8, 20, 0), PointY = 125 });
            lineDatas2.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 8, 25, 0), PointY = 125 });
            lineDatas2.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 8, 30, 0), PointY = 125 });
            lineDatas2.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 8, 35, 0), PointY = 125 });
            lineDatas2.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 8, 40, 0), PointY = 125 });
            lineDatas2.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 8, 45, 0), PointY = 125 });
            lineDatas2.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 8, 50, 0), PointY = 125 });
            lineDatas2.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 8, 55, 0), PointY = 125 });
            lineDatas2.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 9, 0, 0), PointY = 125 });
            lineDatas2.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 9, 5, 0), PointY = 125 });
            lineDatas2.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 9, 10, 0), PointY = 125 });
            lineDatas2.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 9, 15, 0), PointY = 125 });
            lineDatas2.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 9, 20, 0), PointY = 125 });
            lineDatas2.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 9, 25, 0), PointY = 125 });
            lineDatas2.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 9, 30, 0), PointY = 125 });
            lineDatas2.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 9, 35, 0), PointY = 125 });
            lineDatas2.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 9, 40, 0), PointY = 125 });
            lineDatas2.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 9, 45, 0), PointY = 125 });
            lineDatas2.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 9, 50, 0), PointY = 125 });
            lineDatas2.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 9, 55, 0), PointY = 125 });
            lineDatas2.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 10, 0, 0), PointY = 125 });
            lineDatas2.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 10, 5, 0), PointY = 125 });
            lineDatas2.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 10, 10, 0), PointY = 125 });
            lineDatas2.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 10, 15, 0), PointY = 125 });
            lineDatas2.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 10, 20, 0), PointY = 125 });
            lineDatas2.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 10, 25, 0), PointY = 125 });
            lineDatas2.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 10, 30, 0), PointY = 125 });
            lineDatas2.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 10, 35, 0), PointY = 125 });
            lineDatas2.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 10, 40, 0), PointY = 125 });
            lineDatas2.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 10, 45, 0), PointY = 125 });
            lineDatas2.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 10, 50, 0), PointY = 125 });
            lineDatas2.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 10, 55, 0), PointY = 125 });
            lineDatas2.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 11, 0, 0), PointY = 125 });
            lineDatas2.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 11, 5, 0), PointY = 125 });
            lineDatas2.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 11, 10, 0), PointY = 125 });
            lineDatas2.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 11, 15, 0), PointY = 125 });
            lineService2.LineServicesData = lineDatas2;
            LineService lineService3 = new LineService();
            LineLegendItemModel legendItemModel3 = new LineLegendItemModel();
            legendItemModel3.Title = "动脉收缩压";
            legendItemModel3.TitleBrush = new SolidColorBrush(Colors.Red);
            lineService3.LineLegendItem = legendItemModel3;
            ObservableCollection<LineData> lineDatas3 = new ObservableCollection<LineData>();
            lineDatas3.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 8, 0, 0), PointY = 125 });
            lineDatas3.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 8, 5, 0), PointY = 125 });
            lineDatas3.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 8, 10, 0), PointY = 125 });
            lineDatas3.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 8, 15, 0), PointY = 125 });
            lineDatas3.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 8, 20, 0), PointY = 125 });
            lineDatas3.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 8, 25, 0), PointY = 125 });
            lineDatas3.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 8, 30, 0), PointY = 125 });
            lineDatas3.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 8, 35, 0), PointY = 125 });
            lineDatas3.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 8, 40, 0), PointY = 125 });
            lineDatas3.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 8, 45, 0), PointY = 125 });
            lineDatas3.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 8, 50, 0), PointY = 125 });
            lineDatas3.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 8, 55, 0), PointY = 125 });
            lineDatas3.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 9, 0, 0), PointY = 125 });
            lineDatas3.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 9, 5, 0), PointY = 125 });
            lineDatas3.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 9, 10, 0), PointY = 125 });
            lineDatas3.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 9, 15, 0), PointY = 125 });
            lineDatas3.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 9, 20, 0), PointY = 125 });
            lineDatas3.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 9, 25, 0), PointY = 125 });
            lineDatas3.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 9, 30, 0), PointY = 125 });
            lineDatas3.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 9, 35, 0), PointY = 125 });
            lineDatas3.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 9, 40, 0), PointY = 125 });
            lineDatas3.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 9, 45, 0), PointY = 125 });
            lineDatas3.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 9, 50, 0), PointY = 125 });
            lineDatas3.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 9, 55, 0), PointY = 125 });
            lineDatas3.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 10, 0, 0), PointY = 125 });
            lineDatas3.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 10, 5, 0), PointY = 125 });
            lineDatas3.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 10, 10, 0), PointY = 125 });
            lineDatas3.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 10, 15, 0), PointY = 125 });
            lineDatas3.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 10, 20, 0), PointY = 125 });
            lineDatas3.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 10, 25, 0), PointY = 125 });
            lineDatas3.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 10, 30, 0), PointY = 125 });
            lineDatas3.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 10, 35, 0), PointY = 125 });
            lineDatas3.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 10, 40, 0), PointY = 125 });
            lineDatas3.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 10, 45, 0), PointY = 125 });
            lineDatas3.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 10, 50, 0), PointY = 125 });
            lineDatas3.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 10, 55, 0), PointY = 125 });
            lineDatas3.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 11, 0, 0), PointY = 125 });
            lineDatas3.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 11, 5, 0), PointY = 125 });
            lineDatas3.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 11, 10, 0), PointY = 125 });
            lineDatas3.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 11, 15, 0), PointY = 125 });
            lineService3.LineServicesData = lineDatas3;
            LineService lineService4 = new LineService();
            LineLegendItemModel legendItemModel4 = new LineLegendItemModel();
            legendItemModel4.Title = "心率";
            legendItemModel4.TitleBrush = new SolidColorBrush(Colors.Red);
            lineService4.LineLegendItem = legendItemModel4;
            ObservableCollection<LineData> lineDatas4 = new ObservableCollection<LineData>();
            lineDatas4.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 8, 0, 0), PointY = 125 });
            lineDatas4.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 8, 5, 0), PointY = 125 });
            lineDatas4.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 8, 10, 0), PointY = 125 });
            lineDatas4.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 8, 15, 0), PointY = 125 });
            lineDatas4.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 8, 20, 0), PointY = 125 });
            lineDatas4.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 8, 25, 0), PointY = 125 });
            lineDatas4.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 8, 30, 0), PointY = 125 });
            lineDatas4.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 8, 35, 0), PointY = 125 });
            lineDatas4.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 8, 40, 0), PointY = 125 });
            lineDatas4.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 8, 45, 0), PointY = 125 });
            lineDatas4.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 8, 50, 0), PointY = 125 });
            lineDatas4.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 8, 55, 0), PointY = 125 });
            lineDatas4.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 9, 0, 0), PointY = 125 });
            lineDatas4.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 9, 5, 0), PointY = 125 });
            lineDatas4.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 9, 10, 0), PointY = 125 });
            lineDatas4.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 9, 15, 0), PointY = 125 });
            lineDatas4.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 9, 20, 0), PointY = 125 });
            lineDatas4.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 9, 25, 0), PointY = 125 });
            lineDatas4.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 9, 30, 0), PointY = 125 });
            lineDatas4.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 9, 35, 0), PointY = 125 });
            lineDatas4.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 9, 40, 0), PointY = 125 });
            lineDatas4.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 9, 45, 0), PointY = 125 });
            lineDatas4.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 9, 50, 0), PointY = 125 });
            lineDatas4.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 9, 55, 0), PointY = 125 });
            lineDatas4.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 10, 0, 0), PointY = 125 });
            lineDatas4.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 10, 5, 0), PointY = 125 });
            lineDatas4.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 10, 10, 0), PointY = 125 });
            lineDatas4.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 10, 15, 0), PointY = 125 });
            lineDatas4.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 10, 20, 0), PointY = 125 });
            lineDatas4.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 10, 25, 0), PointY = 125 });
            lineDatas4.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 10, 30, 0), PointY = 125 });
            lineDatas4.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 10, 35, 0), PointY = 125 });
            lineDatas4.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 10, 40, 0), PointY = 125 });
            lineDatas4.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 10, 45, 0), PointY = 125 });
            lineDatas4.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 10, 50, 0), PointY = 125 });
            lineDatas4.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 10, 55, 0), PointY = 125 });
            lineDatas4.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 11, 0, 0), PointY = 125 });
            lineDatas4.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 11, 5, 0), PointY = 125 });
            lineDatas4.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 11, 10, 0), PointY = 125 });
            lineDatas4.Add(new LineData() { PointX = new DateTime(2020, 1, 16, 11, 15, 0), PointY = 125 });
            lineService4.LineServicesData = lineDatas4;
            lineServices.Add(lineService1);
            lineServices.Add(lineService2);
            lineServices.Add(lineService3);
            lineServices.Add(lineService4);
            LineServiceList = new ObservableCollection<LineService>(lineServices);


            ObservableCollection<GanttProjectModel> ganttProjectModels = new ObservableCollection<GanttProjectModel>();

            for (int i = 0; i < 38; i++)
            {
                ganttProjectModels.Add(new GanttProjectModel());
            }

            LineRowsItem = new ObservableCollection<GanttProjectModel>(ganttProjectModels);

            //GetTreeChildren(RowItemList, GanttProjectModel);

            //foreach (var item in TimeItemModels)
            //{
            //    foreach (var time in item.DateTimeList)
            //    {
            //        ColumnItemList.Add(new TimeItemModel() { TimeName = time });
            //    }
            //}
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
    }
}

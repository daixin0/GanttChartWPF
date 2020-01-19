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

using CommonLib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace GanttChartControl.Models
{   
    public class LineLegendGroupModel: NotifyPropertyChanged
    {
        private ObservableCollection<LineLegendProjectItemModel> _legendItemList = new ObservableCollection<LineLegendProjectItemModel>();

        /// <summary>
        /// Get or set LegendItemList value
        /// </summary>
        public ObservableCollection<LineLegendProjectItemModel> LegendItemList
        {
            get { return _legendItemList; }
            set { Set(ref _legendItemList, value); }
        }

    }
    public class LineLegendProjectItemModel : NotifyPropertyChanged
    {
        private string _title;

        /// <summary>
        /// Get or set Title value
        /// </summary>
        public string Title
        {
            get { return _title; }
            set { Set(ref _title, value); }
        }
        private DateTime _projectTime;

        /// <summary>
        /// Get or set ProjectTime value
        /// </summary>
        public DateTime ProjectTime
        {
            get { return _projectTime; }
            set { Set(ref _projectTime, value); }
        }
        private int _index;

        /// <summary>
        /// Get or set Index value
        /// </summary>
        public int Index
        {
            get { return _index; }
            set { Set(ref _index, value); }
        }

    }
    public class LineLegendItemModel : NotifyPropertyChanged
    {
        private string _title;

        /// <summary>
        /// Get or set Title value
        /// </summary>
        public string Title
        {
            get { return _title; }
            set { Set(ref _title, value); }
        }
        private SolidColorBrush _color;

        /// <summary>
        /// Get or set TitleBrush value
        /// </summary>
        public SolidColorBrush Color
        {
            get { return _color; }
            set { Set(ref _color, value); }
        }
        private string _titleIcon;

        /// <summary>
        /// Get or set TitleIcon value
        /// </summary>
        public string TitleIcon
        {
            get { return _titleIcon; }
            set { Set(ref _titleIcon, value); }
        }
        private string _titleIconPath;

        /// <summary>
        /// Get or set TitleIconPath value
        /// </summary>
        public string TitleIconPath
        {
            get { return _titleIconPath; }
            set {
                TitleIconGeometry = Geometry.Parse(value);
                Set(ref _titleIconPath, value); }
        }
        private Geometry _titleIconGeometry;

        /// <summary>
        /// Get or set TitleIconGeometry value
        /// </summary>
        public Geometry TitleIconGeometry
        {
            get { return _titleIconGeometry; }
            set { Set(ref _titleIconGeometry, value); }
        }


        private DateTime _projectTime;

        /// <summary>
        /// Get or set ProjectTime value
        /// </summary>
        public DateTime ProjectTime
        {
            get { return _projectTime; }
            set { Set(ref _projectTime, value); }
        }
        private int _index;

        /// <summary>
        /// Get or set Index value
        /// </summary>
        public int Index
        {
            get { return _index; }
            set { Set(ref _index, value); }
        }

    }
}

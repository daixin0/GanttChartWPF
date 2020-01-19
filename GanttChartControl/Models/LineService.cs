using CommonLib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GanttChartControl.Models
{
    public class LineService: NotifyPropertyChanged
    {
        private ObservableCollection<LineData> _lineServicesData;

        /// <summary>
        /// Get or set LineServicesData value
        /// </summary>
        public ObservableCollection<LineData> LineServicesData
        {
            get { return _lineServicesData; }
            set { Set(ref _lineServicesData, value); }
        }
        private LineLegendItemModel _lineLegendItem;

        /// <summary>
        /// Get or set LineLegendItem value
        /// </summary>
        public LineLegendItemModel LineLegendItem
        {
            get { return _lineLegendItem; }
            set { Set(ref _lineLegendItem, value); }
        }


    }
    public class LineData: NotifyPropertyChanged
    {
        private DateTime _pointX;

        /// <summary>
        /// Get or set PointX value
        /// </summary>
        public DateTime PointX
        {
            get { return _pointX; }
            set { Set(ref _pointX, value); }
        }
        private double _pointY;

        /// <summary>
        /// Get or set PointY value
        /// </summary>
        public double PointY
        {
            get { return _pointY; }
            set { Set(ref _pointY, value); }
        }

    }
}

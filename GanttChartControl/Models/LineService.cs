using CommonLib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

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
        private LineLegendItemModel _lineLegendTopItem;

        /// <summary>
        /// Get or set LineLegendTopItem value
        /// </summary>
        public LineLegendItemModel LineLegendTopItem
        {
            get { return _lineLegendTopItem; }
            set { Set(ref _lineLegendTopItem, value); }
        }

        private int _topItemIndex;

        /// <summary>
        /// Get or set TopItemIndex value
        /// </summary>
        public int TopItemIndex
        {
            get { return _topItemIndex; }
            set { Set(ref _topItemIndex, value); }
        }


        private ChartLineType _chartLineType;

        /// <summary>
        /// Get or set ChartLineType value
        /// </summary>
        public ChartLineType ChartLineType
        {
            get { return _chartLineType; }
            set { Set(ref _chartLineType, value); }
        }


    }
    public class LineData: NotifyPropertyChanged
    {
        private DateTime _pointXDate;

        /// <summary>
        /// Get or set PointX value
        /// </summary>
        public DateTime PointXDate
        {
            get { return _pointXDate; }
            set { Set(ref _pointXDate, value); }
        }
        private int _dataValue;

        /// <summary>
        /// Get or set DataValue value
        /// </summary>
        public int DataValue
        {
            get { return _dataValue; }
            set { Set(ref _dataValue, value); }
        }
        private string _infoDescription;

        /// <summary>
        /// Get or set InfoDescription value
        /// </summary>
        public string InfoDescription
        {
            get { return _infoDescription; }
            set { Set(ref _infoDescription, value); }
        }

        private double _pointX;

        /// <summary>
        /// Get or set PointX value
        /// </summary>
        public double PointX
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
        private double _screenPointY;

        /// <summary>
        /// Get or set ScreenPointY value
        /// </summary>
        public double ScreenPointY
        {
            get { return _screenPointY; }
            set { Set(ref _screenPointY, value); }
        }

    }
}

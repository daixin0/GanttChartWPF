using CommonLib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GanttChartControl.Models
{
    public class GanttProjectModel: NotifyPropertyChanged
    {
		private string _projectName;

		/// <summary>
		/// Get or set ProjectName value
		/// </summary>
		public string ProjectName
		{
			get { return _projectName; }
			set { Set(ref _projectName, value); }
		}
		private DateTime _startTime;

		/// <summary>
		/// Get or set StartTime value
		/// </summary>
		public DateTime StartTime
		{
			get { return _startTime; }
			set { Set(ref _startTime, value); }
		}
		private double _value;

		/// <summary>
		/// Get or set Value value
		/// </summary>
		public double Value
		{
			get { return _value; }
			set { Set(ref _value, value); }
		}
		private string _unitName;

		/// <summary>
		/// Get or set UnitName value
		/// </summary>
		public string UnitName
		{
			get { return _unitName; }
			set { Set(ref _unitName, value); }
		}


		private DateTime _endTime;

		/// <summary>
		/// Get or set EndTime value
		/// </summary>
		public DateTime EndTime
		{
			get { return _endTime; }
			set { Set(ref _endTime, value); }
		}
		private double _startPointX;

		/// <summary>
		/// Get or set StartPointX value
		/// </summary>
		public double StartPointX
		{
			get { return _startPointX; }
			set { Set(ref _startPointX, value); }
		}
		private double _startPointY;

		/// <summary>
		/// Get or set StartPointY value
		/// </summary>
		public double StartPointY
		{
			get { return _startPointY; }
			set { Set(ref _startPointY, value); }
		}
		private double _endPointX;

		/// <summary>
		/// Get or set EndPointX value
		/// </summary>
		public double EndPointX
		{
			get { return _endPointX; }
			set { Set(ref _endPointX, value); }
		}
		private double _endPointY;

		/// <summary>
		/// Get or set EndPointY value
		/// </summary>
		public double EndPointY
		{
			get { return _endPointY; }
			set { Set(ref _endPointY, value); }
		}
		private bool _isSinglePoint;

		/// <summary>
		/// Get or set IsSinglePoint value
		/// </summary>
		public bool IsSinglePoint
		{
			get { return _isSinglePoint; }
			set { Set(ref _isSinglePoint, value); }
		}

		private bool _isEnd;

		/// <summary>
		/// Get or set IsEnd value
		/// </summary>
		public bool IsEnd
		{
			get { return _isEnd; }
			set { Set(ref _isEnd, value); }
		}
		private bool _isStart;

		/// <summary>
		/// Get or set IsStart value
		/// </summary>
		public bool IsStart
		{
			get { return _isStart; }
			set { Set(ref _isStart, value); }
		}


		private ObservableCollection<GanttProjectModel> _children = new ObservableCollection<GanttProjectModel>();

		/// <summary>
		/// Get or set Children value
		/// </summary>
		public ObservableCollection<GanttProjectModel> Children
		{
			get { return _children; }
			set { Set(ref _children, value); }
		}

	}
}

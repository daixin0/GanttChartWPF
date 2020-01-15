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
		private DateTime _endTime;

		/// <summary>
		/// Get or set EndTime value
		/// </summary>
		public DateTime EndTime
		{
			get { return _endTime; }
			set { Set(ref _endTime, value); }
		}

		private ObservableCollection<GanttProjectModel> _children;

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

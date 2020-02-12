using CommonLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GanttChartControl.Models
{
    public class PageChartModel: NotifyPropertyChanged
    {
		private int _pageIndex;

		/// <summary>
		/// Get or set PageIndex value
		/// </summary>
		public int PageIndex
		{
			get { return _pageIndex; }
			set { Set(ref _pageIndex, value); }
		}


	}
}

using CommonLib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GanttChartControl.Models
{

    public class TimeItemModel: NotifyPropertyChanged
    {
        private DateTime _timeName;

        /// <summary>
        /// Get or set TimeName value
        /// </summary>
        public DateTime TimeName
        {
            get { return _timeName; }
            set {

                DateTimeList.Add(value.AddMinutes(5));
                DateTimeList.Add(value.AddMinutes(10));
                Set(ref _timeName, value); }
        }
        private ObservableCollection<DateTime> _dateTimeList = new ObservableCollection<DateTime>();

        /// <summary>
        /// Get or set DateTimeList value
        /// </summary>
        public ObservableCollection<DateTime> DateTimeList
        {
            get { return _dateTimeList; }
            set { Set(ref _dateTimeList, value); }
        }


    }
}

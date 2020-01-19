using CommonLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace GanttChartControl.Models
{
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
        private SolidColorBrush _titleBrush;

        /// <summary>
        /// Get or set TitleBrush value
        /// </summary>
        public SolidColorBrush TitleBrush
        {
            get { return _titleBrush; }
            set { Set(ref _titleBrush, value); }
        }
        private Geometry _titleIcon;

        /// <summary>
        /// Get or set TitleIcon value
        /// </summary>
        public Geometry TitleIcon
        {
            get { return _titleIcon; }
            set { Set(ref _titleIcon, value); }
        }

    }
}

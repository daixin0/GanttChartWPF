using GanttChartControl.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
 
namespace GanttChartControl
{
    public class ProjectItemControl : ItemsControl
    {
        
    }
    public class ElectrocardiogramControl : Control
    {

        public ObservableCollection<LineLegendItemModel> LegendItems
        {
            get { return (ObservableCollection<LineLegendItemModel>)GetValue(LegendItemsProperty); }
            set { SetValue(LegendItemsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LegendItems.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LegendItemsProperty =
            DependencyProperty.Register("LegendItems", typeof(ObservableCollection<LineLegendItemModel>), typeof(ElectrocardiogramControl));


    }
}

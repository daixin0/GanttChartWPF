using GanttChartControl.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace GanttChartControl
{
    public class TimeHeaderControl : ItemsControl
    {
        protected override DependencyObject GetContainerForItemOverride()
        {
            TimeContentControl timeContent = new TimeContentControl();
            return timeContent;
        }
        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            bool _isITV = item is TimeContentControl;
            return _isITV;
        }
        protected override void OnItemsSourceChanged(IEnumerable oldValue, IEnumerable newValue)
        {
            base.OnItemsSourceChanged(oldValue, newValue);
            foreach (var item in Items)
            {
                if(item is TimeItemModel)
                {
                    TimeItemModel itemModel = item as TimeItemModel;
                }
            }
            
        }

    }
    public class TimeContentControl : ContentControl
    {
        
    }
}

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
    public class YAxisControl : ItemsControl
    {

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Title.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(YAxisControl));

        protected override DependencyObject GetContainerForItemOverride()
        {
            YAxisTitleControl gridCell = new YAxisTitleControl();
            return gridCell;
        }
        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            bool _isITV = item is YAxisTitleControl;
            return _isITV;
        }
        protected override void OnItemsSourceChanged(IEnumerable oldValue, IEnumerable newValue)
        {
            base.OnItemsSourceChanged(oldValue, newValue);
            if (this.Items != null && this.Items.Count > 0)
            {
                YAxisTitleControl yaxis = this.ItemContainerGenerator.ContainerFromItem(this.Items[Items.Count-1]) as YAxisTitleControl;
                yaxis.FirstMargin = new Thickness(0,-7,0,0);
            }
                
        }
    }
    public class YAxisTitleControl : ContentControl
    {
        public Thickness FirstMargin
        {
            get { return (Thickness)GetValue(FirstMarginProperty); }
            set { SetValue(FirstMarginProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FirstMargin.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FirstMarginProperty =
            DependencyProperty.Register("FirstMargin", typeof(Thickness), typeof(YAxisTitleControl));




    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace GanttChartControl
{
    public class ProjectTreeControl:TreeView
    {
        protected override DependencyObject GetContainerForItemOverride()
        {
            ProjectTreeItemControl item = new ProjectTreeItemControl();
            return item;
        }

        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            bool _isTreeLVI = item is ProjectTreeItemControl;
            return _isTreeLVI;
        }

    }
    public class ProjectTreeItemControl : TreeViewItem
    {
        private int _level = -1;
        public int Level
        {
            get
            {
                if (_level == -1)
                {
                    ProjectTreeItemControl parent =
                        ItemsControl.ItemsControlFromItemContainer(this) as ProjectTreeItemControl;
                    _level = (parent != null) ? parent.Level + 1 : 0;
                }
                return _level;
            }
        }
        protected override DependencyObject GetContainerForItemOverride()
        {
            ProjectTreeItemControl item = new ProjectTreeItemControl();
            return item;
        }
        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            bool _isITV = item is ProjectTreeItemControl;
            return _isITV;
        }
    }
}

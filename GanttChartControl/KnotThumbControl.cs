using GanttChartControl.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Shapes;

namespace GanttChartControl
{
    public class KnotThumbControl:Thumb
    {
        public string KnotString
        {
            get { return (string)GetValue(KnotStringProperty); }
            set { SetValue(KnotStringProperty, value); }
        }

        // Using a DependencyProperty as the backing store for KnotString.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty KnotStringProperty =
            DependencyProperty.Register("KnotString", typeof(string), typeof(KnotThumbControl));



        public Geometry KnotPath
        {
            get { return (Geometry)GetValue(KnotPathProperty); }
            set { SetValue(KnotPathProperty, value); }
        }

        // Using a DependencyProperty as the backing store for KnotPath.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty KnotPathProperty =
            DependencyProperty.Register("KnotPath", typeof(Geometry), typeof(KnotThumbControl));



        public SolidColorBrush KnotColor
        {
            get { return (SolidColorBrush)GetValue(KnotColorProperty); }
            set { SetValue(KnotColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for KnotColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty KnotColorProperty =
            DependencyProperty.Register("KnotColor", typeof(SolidColorBrush), typeof(KnotThumbControl));


        public LineService LineChartDataSelected
        {
            get { return (LineService)GetValue(LineChartDataSelectedProperty); }
            set { SetValue(LineChartDataSelectedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LineChartDataSelected.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LineChartDataSelectedProperty =
            DependencyProperty.Register("LineChartDataSelected", typeof(LineService), typeof(KnotThumbControl));



        public double SelectedPointX
        {
            get { return (double)GetValue(SelectedPointXProperty); }
            set { SetValue(SelectedPointXProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedPointX.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedPointXProperty =
            DependencyProperty.Register("SelectedPointX", typeof(double), typeof(KnotThumbControl));



        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            AddHandler(Thumb.DragDeltaEvent, new DragDeltaEventHandler(OnDragDelta));
            AddHandler(Thumb.DragCompletedEvent, new RoutedEventHandler(OnDragCompleted));
        }
        private void ConvertData(Canvas canvas,double newTop)
        {
            double num3 = Convert.ToDouble(10) / Convert.ToDouble(18);
            for (int i = 0; i < LineChartDataSelected.LineServicesData.Count; i++)
            {
                if (LineChartDataSelected.LineServicesData[i].PointX == SelectedPointX)
                    LineChartDataSelected.LineServicesData[i].PointY = (canvas.Height- newTop) * num3;

            }
            
        }

        private void OnDragDelta(object sender, DragDeltaEventArgs e)
        {
            KnotThumbControl thumb = e.OriginalSource as KnotThumbControl;
            if (thumb == null)
            {
                return;
            }
            double VerticalChange = e.VerticalChange;
            Canvas canvas = thumb.Parent as Canvas;
            if (canvas == null)
                return;
            Canvas.SetTop(thumb, Canvas.GetTop(thumb) + VerticalChange);

            ConvertData(canvas, Canvas.GetTop(thumb) + VerticalChange);
            if (DragDeltaEvent != null)
            {
                DelCanvasLine();
                DragDeltaEvent(LineChartDataSelected, e); 
               
            }

            e.Handled = true;
        }
        public event EventHandler DragDeltaEvent;
        public event EventHandler DragComplatedEvent;
        private void DelCanvasLine()
        {
            Canvas canvas = this.Parent as Canvas;
            if (canvas == null)
                return;
            ObservableCollection<UIElement> temp = new ObservableCollection<UIElement>();
            foreach (var item in canvas.Children)
            {
                if (item is Polyline)
                {
                    Polyline line = item as Polyline;
                    if (line.Tag == LineChartDataSelected)
                    {
                        temp.Add(line);
                    }
                }
                else if (item is KnotThumbControl)
                {
                    KnotThumbControl knotThumb = item as KnotThumbControl;
                    if (knotThumb.LineChartDataSelected == LineChartDataSelected)
                    {
                        temp.Add(knotThumb);
                        
                    }
                }
            }
            foreach (var item in temp)
            {
                canvas.Children.Remove(item);
            }
        }
        private void OnDragCompleted(object sender, RoutedEventArgs e)
        {
            if (DragComplatedEvent != null)
            {
                DelCanvasLine();
                DragComplatedEvent(LineChartDataSelected, e);
            }
            e.Handled = true;
        }
    }
}

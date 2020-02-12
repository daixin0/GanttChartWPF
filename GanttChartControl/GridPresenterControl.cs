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
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace GanttChartControl
{
    public enum ChartLineType
    {
        PolylineType,
        BezierType,
        PolylineKnotsType,
        BezierKnotsType,
        Knots,
        Number,
        Description
    }
    public class RowsGridPresenter : ContentControl
    {
        public RowsGridPresenter()
        {
            this.DataContext = this;
        }
        public ObservableCollection<TimeItemModel> GanttColumnsItem
        {
            get { return (ObservableCollection<TimeItemModel>)GetValue(GanttColumnsItemProperty); }
            set { SetValue(GanttColumnsItemProperty, value); }
        }

        // Using a DependencyProperty as the backing store for GanttColumnsItem.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GanttColumnsItemProperty =
            DependencyProperty.Register("GanttColumnsItem", typeof(ObservableCollection<TimeItemModel>), typeof(RowsGridPresenter));



        public bool IsGanttChart
        {
            get { return (bool)GetValue(IsGanttChartProperty); }
            set { SetValue(IsGanttChartProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsGanttChart.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsGanttChartProperty =
            DependencyProperty.Register("IsGanttChart", typeof(bool), typeof(RowsGridPresenter));



        public ObservableCollection<LineService> LineServicesData
        {
            get { return (ObservableCollection<LineService>)GetValue(LineServicesDataProperty); }
            set { SetValue(LineServicesDataProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LineServicesData.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LineServicesDataProperty =
            DependencyProperty.Register("LineServicesData", typeof(ObservableCollection<LineService>), typeof(RowsGridPresenter));


        public ObservableCollection<GanttProjectModel> LineRowsItem
        {
            get { return (ObservableCollection<GanttProjectModel>)GetValue(LineRowsItemProperty); }
            set { SetValue(LineRowsItemProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LineRowsItem.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LineRowsItemProperty =
            DependencyProperty.Register("LineRowsItem", typeof(ObservableCollection<GanttProjectModel>), typeof(RowsGridPresenter));


        private void DrawingGrid()
        {
            for (int i = 1; i < LineRowsItem.Count; i++)
            {
                Line element = new Line();
                element.X1 = 0;
                element.X2 = GanttColumnsItem.Count * 18;
                element.Y1 = i * 18;
                element.Y2 = i * 18;
                element.StrokeThickness = 1;
                element.Stroke = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFCECECE"));
                BorderChart.Children.Add(element);
            }

            for (int i = 0; i < GanttColumnsItem.Count; i++)
            {
                Line element = new Line();
                element.X1 = i * 18;
                element.X2 = i * 18;
                element.Y1 = 0;
                element.Y2 = LineRowsItem.Count * 18;
                element.StrokeThickness = 1;
                if ((i) % 3 != 0)
                {
                    element.StrokeDashArray = new DoubleCollection() { 2, 2 };
                    element.StrokeDashCap = PenLineCap.Triangle;
                    element.StrokeEndLineCap = PenLineCap.Square;
                    element.StrokeStartLineCap = PenLineCap.Round;
                }
                element.Stroke = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFCECECE"));
                BorderChart.Children.Add(element);
            }
            BorderChart.Width = GanttColumnsItem.Count * 18;
            BorderChart.Height = LineRowsItem.Count * 18;
        }

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            if (e.Property.Name == "GanttColumnsItem")
            {
                if (LineRowsItem == null)
                    return;
                DrawingGrid();
                if (IsGanttChart)
                    DrawingGantt();
                if (LineServicesData == null)
                    return;
                DrawingLineList();
            }
            if (e.Property.Name == "LineRowsItem")
            {
                if (GanttColumnsItem == null)
                    return;
                DrawingGrid();
                if (IsGanttChart)
                    DrawingGantt();
                if (LineServicesData == null)
                    return;
                DrawingLineList();
            }
            if (e.Property.Name == "LineServicesData")
            {
                if (GanttColumnsItem == null)
                    return;
                DrawingGrid();
            }
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            BorderChart = this.Template.FindName("borderChart", this) as Canvas;

        }
        Canvas BorderChart { get; set; }

        private void DrawBezierChartData(SolidColorBrush color, Point[] points, Point[] firstControlPoints, Point[] secondControlPoints)
        {
            PathSegmentCollection segments = new PathSegmentCollection();
            for (int i = 0; i < (points.Length - 1); i++)
            {
                segments.Add(new BezierSegment(firstControlPoints[i], secondControlPoints[i], points[i + 1], true));
            }
            PathFigure figure = new PathFigure(points[0], segments, false);
            PathGeometry geometry = new PathGeometry(new PathFigure[] { figure });
            Path element = new Path
            {
                Stroke = color,
                Data = geometry
            };
            element.Style = base.Resources["pathStyleKey"] as Style;
            this.BorderChart.Children.Add(element);
        }

        private void DrawPolylineChartData(Point[] points, LineService curve)
        {
            Polyline element = new Polyline();
            for (int i = 0; i < points.Length; i++)
            {
                element.Points.Add(points[i]);
            }
            element.Tag = curve;
            element.Stroke = curve.LineLegendItem.Color;
            this.BorderChart.Children.Add(element);
        }
        private void DrawPolylineKnotsChartData(Point[] points, LineService curve)
        {
            for (int i = 0; i < points.Length; i++)
            {
                KnotThumbControl knotThumbControl = new KnotThumbControl();
                //knotThumbControl.DragDeltaEvent += KnotThumbControl_DragDeltaEvent;
                knotThumbControl.DragComplatedEvent += KnotThumbControl_DragComplatedEvent;
                knotThumbControl.KnotString = curve.LineLegendItem.TitleIcon;
                knotThumbControl.KnotPath = Geometry.Parse(curve.LineLegendItem.TitleIconPath);
                knotThumbControl.KnotColor = curve.LineLegendItem.Color;
                knotThumbControl.LineChartDataSelected = curve;
                knotThumbControl.SelectedPointX = points[i].X;
                if (curve.LineLegendItem.TitleIcon == "•")
                {
                    Canvas.SetLeft(knotThumbControl, points[i].X);
                    Canvas.SetTop(knotThumbControl, points[i].Y-3);
                }
                else
                {
                    Canvas.SetLeft(knotThumbControl, points[i].X - 2);
                    Canvas.SetTop(knotThumbControl, points[i].Y - 3);
                }
                
                this.BorderChart.Children.Add(knotThumbControl);
            }
        }

        private void KnotThumbControl_DragComplatedEvent(object sender, EventArgs e)
        {
            DrawingLine(sender as LineService);
        }

        private void KnotThumbControl_DragDeltaEvent(object sender, EventArgs e)
        {
            DrawingLine(sender as LineService);
        }

        private void DrawKnotsChartData(SolidColorBrush color, Point[] points, string knots)
        {
            for (int i = 0; i < points.Length; i++)
            {
                TextBlock tb = new TextBlock();
                tb.Text = knots;
                tb.FontSize = 20;
                tb.Foreground = color;
                Canvas.SetLeft(tb, points[i].X - 3);
                Canvas.SetTop(tb, points[i].Y + 32);
                this.BorderChart.Children.Add(tb);
            }
        }
        private void DrawNumberChartData(SolidColorBrush color, Point[] points, ObservableCollection<int> data)
        {
            for (int i = 0; i < points.Length; i++)
            {
                TextBlock tb = new TextBlock();
                tb.Text = data[i].ToString();
                tb.Foreground = color;
                Canvas.SetLeft(tb, points[i].X);
                Canvas.SetTop(tb, points[i].Y);
                this.BorderChart.Children.Add(tb);
            }
        }
        private void DrawDescriptionChartData(SolidColorBrush color, Point[] points, string description)
        {
            for (int i = 0; i < points.Length; i++)
            {
                TextBlock tb = new TextBlock();
                tb.Text = description;
                tb.Foreground = color;
                Canvas.SetLeft(tb, points[i].X);
                Canvas.SetTop(tb, points[i].Y);
                this.BorderChart.Children.Add(tb);
            }
        }
        public void DrawingLineList()
        {
            if (this.LineServicesData != null)
            {
                foreach (LineService info in this.LineServicesData)
                {
                    if (info.LineServicesData == null)
                        continue;
                    double num2 = 18;
                    double num3 = Convert.ToDouble(18) / Convert.ToDouble(10);
                    for (int i = 0; i < info.LineServicesData.Count; i++)
                    {
                        info.LineServicesData[i].PointX = num2 * ((info.LineServicesData[i].PointXDate.TimeOfDay.TotalMinutes - GanttColumnsItem[0].TimeName.TimeOfDay.TotalMinutes) / 5);
                        if (info.ChartLineType == ChartLineType.Number)
                        {
                            info.LineServicesData[i].ScreenPointY = info.TopItemIndex * 18;
                        }
                        else if(info.ChartLineType== ChartLineType.Description)
                        {
                            info.LineServicesData[i].ScreenPointY = 18 + info.TopItemIndex * 18;
                        }
                        else
                        {
                            info.LineServicesData[i].ScreenPointY = BorderChart.Height - (info.LineServicesData[i].PointY * num3);
                        }

                    }
                }
                foreach (LineService curve in this.LineServicesData)
                {
                    if (curve.LineServicesData == null)
                        continue;
                    Point[] array = new Point[curve.LineServicesData.Count];
                    for (int i = 0; i < curve.LineServicesData.Count; i++)
                    {
                        array[i] = new Point(curve.LineServicesData[i].PointX, curve.LineServicesData[i].ScreenPointY);
                    }
                    if ((curve.ChartLineType == ChartLineType.BezierType) || (curve.ChartLineType == ChartLineType.BezierKnotsType))
                    {
                        Point[] pointArray2;
                        Point[] pointArray3;
                        BezierSpline.GetCurveControlPoints(array, out pointArray2, out pointArray3);
                        this.DrawBezierChartData(curve.LineLegendItem.Color, array, pointArray2, pointArray3);
                        if (curve.ChartLineType == ChartLineType.BezierKnotsType)
                        {
                        }
                    }
                    else if ((curve.ChartLineType == ChartLineType.PolylineType) || (curve.ChartLineType == ChartLineType.PolylineKnotsType))
                    {
                        this.DrawPolylineChartData(array, curve);
                        if (curve.ChartLineType == ChartLineType.PolylineKnotsType)
                        {
                            DrawPolylineKnotsChartData(array, curve);
                        }
                    }
                    else if (curve.ChartLineType == ChartLineType.Knots)
                    {
                        DrawKnotsChartData(curve.LineLegendItem.Color, array, curve.LineLegendItem.TitleIcon);
                    }
                    else if (curve.ChartLineType == ChartLineType.Number)
                    {
                        ObservableCollection<int> dataList = new ObservableCollection<int>();
                        foreach (var item in curve.LineServicesData)
                        {
                            dataList.Add(item.DataValue);
                        }
                        DrawNumberChartData(curve.LineLegendTopItem.Color, array, dataList);
                    }
                    else if (curve.ChartLineType == ChartLineType.Description)
                    {
                        if (curve.LineServicesData.Count > 0)
                            DrawDescriptionChartData(curve.LineLegendTopItem.Color, array, curve.LineServicesData[0].InfoDescription);
                    }
                }

            }
        }

        public void DrawingLine(LineService lineService)
        {
            if (lineService != null)
            {
                if (lineService.LineServicesData == null)
                    return;
                double num2 = 18;
                double num3 = Convert.ToDouble(18) / Convert.ToDouble(10);
                for (int i = 0; i < lineService.LineServicesData.Count; i++)
                {
                    lineService.LineServicesData[i].PointX = num2 * ((lineService.LineServicesData[i].PointXDate.TimeOfDay.TotalMinutes - GanttColumnsItem[0].TimeName.TimeOfDay.TotalMinutes) / 5);
                    if (lineService.ChartLineType == ChartLineType.Number)
                    {
                        lineService.LineServicesData[i].ScreenPointY = lineService.TopItemIndex * 18;
                    }
                    else
                    {
                        lineService.LineServicesData[i].ScreenPointY = BorderChart.Height - (lineService.LineServicesData[i].PointY * num3);
                    }

                }

                Point[] array = new Point[lineService.LineServicesData.Count];
                for (int i = 0; i < lineService.LineServicesData.Count; i++)
                {
                    array[i] = new Point(lineService.LineServicesData[i].PointX, lineService.LineServicesData[i].ScreenPointY);
                }
                if ((lineService.ChartLineType == ChartLineType.BezierType) || (lineService.ChartLineType == ChartLineType.BezierKnotsType))
                {
                    Point[] pointArray2;
                    Point[] pointArray3;
                    BezierSpline.GetCurveControlPoints(array, out pointArray2, out pointArray3);
                    this.DrawBezierChartData(lineService.LineLegendItem.Color, array, pointArray2, pointArray3);
                    if (lineService.ChartLineType == ChartLineType.BezierKnotsType)
                    {
                    }
                }
                else if ((lineService.ChartLineType == ChartLineType.PolylineType) || (lineService.ChartLineType == ChartLineType.PolylineKnotsType))
                {
                    this.DrawPolylineChartData(array, lineService);
                    if (lineService.ChartLineType == ChartLineType.PolylineKnotsType)
                    {
                        DrawPolylineKnotsChartData(array, lineService);
                    }
                }

            }
        }
        public void DrawingGantt()
        {
            if (GanttColumnsItem != null && LineRowsItem != null)
            {
                DateTime defaultTime = new DateTime(2000, 1, 1);
                foreach (var row in LineRowsItem)
                {
                    row.StartPointX = 0;
                    row.StartPointY = 0;
                    row.EndPointX = 0;
                    row.EndPointY = 0;
                    row.IsStart = false;
                    row.IsEnd = false;
                    int rowIndex = LineRowsItem.IndexOf(row);
                    DateTime maxTime = GanttColumnsItem.Max(p => p.TimeName);
                    foreach (var col in GanttColumnsItem)
                    {
                        int colIndex = GanttColumnsItem.IndexOf(col);
                        if (row.StartTime == col.TimeName)
                        {
                            row.StartPointX = colIndex * 18;
                            row.StartPointY = rowIndex * 18;
                            row.IsStart = true;
                        }
                        else if (row.EndTime == col.TimeName)
                        {
                            row.EndPointX = colIndex * 18;
                            row.EndPointY = rowIndex * 18;
                            row.IsEnd = true;
                        }
                        else if (row.EndTime > maxTime)
                        {
                            row.EndPointX = GanttColumnsItem.Count * 18;
                            row.EndPointY = rowIndex * 18;
                        }
                        else if (row.StartTime > maxTime)
                        {
                            row.StartPointX = 0;
                            row.StartPointY = 0;
                            row.EndPointX = 0;
                            row.EndPointY = 0;
                        }
                        else if (row.EndTime < defaultTime)
                        {
                            row.IsSinglePoint = true;
                        }
                        else if (row.StartTime < GanttColumnsItem[0].TimeName && row.StartTime > defaultTime && !row.IsStart)
                        {
                            row.StartPointX = 0;
                            row.StartPointY = rowIndex * 18;
                        }
                    }

                }

                foreach (var item in LineRowsItem)
                {
                    if (item.StartPointX == 0 && item.StartPointY == 0)
                        continue;
                    if (item.IsSinglePoint)
                    {
                        TextBlock tb = new TextBlock();
                        tb.Text = item.Value.ToString() + item.UnitName;
                        tb.Foreground = new SolidColorBrush(Colors.Blue);
                        Canvas.SetLeft(tb, item.StartPointX);
                        Canvas.SetTop(tb, item.StartPointY);
                        this.BorderChart.Children.Add(tb);
                    }
                    else
                    {
                        if (item.StartPointY != item.EndPointY)
                            continue;
                        TextBlock tb = new TextBlock();
                        tb.Text = item.Value.ToString() + item.UnitName;
                        tb.Foreground = new SolidColorBrush(Colors.Blue);
                        Canvas.SetLeft(tb, item.StartPointX + (item.EndPointX - item.StartPointX) / 2 - tb.Text.Length * 7 / 2);
                        Canvas.SetTop(tb, item.StartPointY);

                        Line line = new Line();
                        line.StrokeThickness = 1;
                        line.Stroke = new SolidColorBrush(Colors.Blue);
                        line.X1 = item.StartPointX;
                        line.X2 = item.StartPointX + (item.EndPointX - item.StartPointX) / 2 - tb.Text.Length * 7 / 2;
                        
                        line.Y1 = item.StartPointY + 8;
                        line.Y2 = item.EndPointY + 8;
                        Line line2 = new Line();
                        line2.StrokeThickness = 1;
                        line2.Stroke = new SolidColorBrush(Colors.Blue);
                        line2.X1 = item.StartPointX + (item.EndPointX - item.StartPointX) / 2 + tb.Text.Length * 7 / 2;
                        line2.X2 = item.EndPointX;
                        line2.Y1 = item.StartPointY + 8;
                        line2.Y2 = item.EndPointY + 8;
                       
                        this.BorderChart.Children.Add(tb);
                        if (item.IsStart)
                        {
                            Line startLine = new Line();
                            startLine.StrokeThickness = 2;
                            startLine.Stroke = new SolidColorBrush(Colors.Blue);
                            startLine.X1 = item.StartPointX;
                            startLine.X2 = item.StartPointX;
                            startLine.Y1 = item.StartPointY + 3;
                            startLine.Y2 = item.StartPointY + 12;
                            BorderChart.Children.Add(startLine);
                        }

                        if (item.IsEnd)
                        {
                            Line endLine = new Line();
                            endLine.StrokeThickness = 2;
                            endLine.Stroke = new SolidColorBrush(Colors.Blue);
                            endLine.X1 = item.EndPointX;
                            endLine.X2 = item.EndPointX;
                            endLine.Y1 = item.EndPointY + 3;
                            endLine.Y2 = item.EndPointY + 12;
                            BorderChart.Children.Add(endLine);
                        }
                        BorderChart.Children.Add(line);
                        BorderChart.Children.Add(line2);
                    }
                    

                }
            }
        }
    }

}

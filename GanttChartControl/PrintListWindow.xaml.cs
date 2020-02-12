using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GanttChartControl
{
    /// <summary>
    /// PrintListWindow.xaml 的交互逻辑
    /// </summary>
    public partial class PrintListWindow : Window
    {
        public PrintListWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }


        public ObservableCollection<string> PrintNameList
        {
            get { return (ObservableCollection<string>)GetValue(PrintNameListProperty); }
            set { SetValue(PrintNameListProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PrintNameList.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PrintNameListProperty =
            DependencyProperty.Register("PrintNameList", typeof(ObservableCollection<string>), typeof(PrintListWindow));



        public string PrintSelected
        {
            get { return (string)GetValue(PrintSelectedProperty); }
            set { SetValue(PrintSelectedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PrintSelected.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PrintSelectedProperty =
            DependencyProperty.Register("PrintSelected", typeof(string), typeof(PrintListWindow));



        public PrintQueue PrintQueueSelected
        {
            get { return (PrintQueue)GetValue(PrintQueueSelectedProperty); }
            set { SetValue(PrintQueueSelectedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PrintQueueSelected.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PrintQueueSelectedProperty =
            DependencyProperty.Register("PrintQueueSelected", typeof(PrintQueue), typeof(PrintListWindow));


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var printers = print.GetPrintQueues();
            foreach (var item in printers)
            {
                if (item.Name == PrintSelected)
                {
                    PrintQueueSelected = item;
                    break;
                }
            }
            this.DialogResult = true;
        }
        LocalPrintServer print = new LocalPrintServer();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PrintNameList = new ObservableCollection<string>();
            
            var printers = print.GetPrintQueues();
            foreach (var item in printers)
            {
                PrintNameList.Add(item.Name);
            }
        }
    }
}

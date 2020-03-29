using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProcessWatcher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public ManagementEventWatcher processStartEvent { get; set; }
        public ManagementEventWatcher processStopEvent { get; set; }
        public string ExeFileName { get; set; }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var processStartTrace = new WqlEventQuery("SELECT * FROM Win32_ProcessStartTrace");

            processStartEvent = new ManagementEventWatcher(processStartTrace);
            processStartEvent.EventArrived += new EventArrivedEventHandler(ProcessStartEvent_EventArrived);

            var processStopTrace = new WqlEventQuery("SELECT * FROM Win32_ProcessStopTrace");
            processStopEvent = new ManagementEventWatcher(processStopTrace);
            processStopEvent.EventArrived += new EventArrivedEventHandler(ProcessStopEvent_EventArrived);

            processStartEvent.Start();
            processStopEvent.Start();

            ExeFileName = "myTube.exe";
        }

        /// <summary>
        /// Process start handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProcessStartEvent_EventArrived(object sender, EventArrivedEventArgs e)
        {
            if (e.NewEvent.Properties["ProcessName"].Value.ToString() == ExeFileName)
            {
                // hedef process başladığında yapılacaklar
            }
        }

        /// <summary>
        /// Process stop handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProcessStopEvent_EventArrived(object sender, EventArrivedEventArgs e)
        {
            if (e.NewEvent.Properties["ProcessName"].Value.ToString() == ExeFileName)
            {
                // hedef process durduğunda yapılacaklar
            }
        }
    }
}

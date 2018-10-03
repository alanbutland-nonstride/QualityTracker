using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Diagnostics;

namespace QualityTracker
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Setup();
        }

        public static void Setup()
        {
            // Initialize TrackerOptions
            Globals.trackerOptions = new TrackerOptions();
            Globals.trackerOptions.GetAll();

            // Start up main window
            var MainWindow = new MainWindow();
            MainWindow.Show();
        }
    }
}

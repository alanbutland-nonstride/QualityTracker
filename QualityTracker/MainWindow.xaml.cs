using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Diagnostics;

namespace QualityTracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Directorate> directorateList;
        public List<Region> regionList;
        public List<Site> siteList;

        public MainWindow()
        {
            InitializeComponent();

            directorateList = new List<Directorate>();
            regionList = new List<Region>();
            siteList = new List<Site>();

            Pages.SelectedIndex = 0;
            WriteStatus("Quality Tracker v1.1");
        }

        private void PopulateDirectorates()
        {
            cmbDirectorates.Items.Clear();
            directorateList = new List<Directorate>();

            foreach (Directorate directorate in Globals.trackerOptions.directorates)
            {
                cmbDirectorates.Items.Add(directorate.directorate_text);
                directorateList.Add(directorate);
            }
            if (cmbDirectorates.Items.Count > 0)
            {
                cmbDirectorates.SelectedIndex = 0;
                PopulateRegions(directorateList[0]);
            }
        }
        private void PopulateRegions(Directorate directorate)
        {
            cmbRegions.Items.Clear();
            regionList = new List<Region>();
            foreach (Region region in Globals.trackerOptions.regions)
            {
                if(region.directorate_id == directorate.directorate_id)
                {
                    cmbRegions.Items.Add(region.region_text);
                    regionList.Add(region);
                }
            }
            if(cmbRegions.Items.Count > 0)
            {
                cmbRegions.SelectedIndex = 0;
                PopulateSites(regionList[0]);
            }
        }
        private void PopulateSites(Region region)
        {
            cmbSites.Items.Clear();
            siteList = new List<Site>();
            foreach (Site site in Globals.trackerOptions.sites)
            {
                Debug.WriteLine(site.site_text + ", " + site.region_id);
                if (site.region_id == region.region_id)
                {
                    cmbSites.Items.Add(site.site_text);
                    siteList.Add(site);
                }
            }
            if(cmbSites.Items.Count > 0)
            {
                cmbSites.SelectedIndex = 0;
            }
        }

        private void cmbDirectorates_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cmbDirectorates.SelectedIndex >= 0)
            {
                Directorate dir = directorateList[cmbDirectorates.SelectedIndex];
                PopulateRegions(dir);
                WriteStatus(dir.directorate_text);
            }
        }

        private void cmbRegions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbRegions.SelectedIndex >= 0)
            {
                Region region = regionList[cmbRegions.SelectedIndex];
                PopulateSites(region);
                WriteStatus(region.region_text);
            }
        }

        private void cmbSites_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbSites.SelectedIndex >=0)
            {
                Site site = siteList[cmbSites.SelectedIndex];
                WriteStatus(site.site_text);
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            stStatusBar.Items.Clear();
            stStatusBar.Items.Add("Exit");
            System.Windows.Application.Current.Shutdown();
        }
        private void btnReport_Click(object sender, RoutedEventArgs e)
        {
            Pages.SelectedIndex = 1;
        }
        private void btnFLMCheck_Click(object sender, RoutedEventArgs e)
        {
            Pages.SelectedIndex = 2;
            PopulateDirectorates();
        }

        private void WriteStatus(string txt)
        {
            stStatusBar.Items.Clear();
            stStatusBar.Items.Add(txt);
        }

        private void TestButton_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Clicked");
        }


    }
}

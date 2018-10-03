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
                cmbDirectorates.Items.Add(directorate.directorateName);
                directorateList.Add(directorate);
            }
            cmbDirectorates.SelectedIndex = 0;
        }
        private void PopulateRegions(Directorate directorate)
        {
            cmbRegions.Items.Clear();
            regionList = new List<Region>();

            foreach (Region region in Globals.trackerOptions.regions)
            {
                if(region.directorateID == directorate.directorateID)
                {
                    cmbRegions.Items.Add(region.regionName);
                    regionList.Add(region);
                }
            }
        }
        private void PopulateSites(Region region)
        {
            cmbSites.Items.Clear();
            siteList = new List<Site>();

            foreach (Site site in Globals.trackerOptions.sites)
            {
                if (site.regionID == region.regionID)
                {
                    cmbSites.Items.Add(site.siteName);
                    siteList.Add(site);
                }
            }
        }

        private void cmbDirectorates_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cmbDirectorates.SelectedIndex >= 0)
            {
                Directorate directorate = directorateList[cmbDirectorates.SelectedIndex];
                PopulateRegions(directorate);
                cmbSites.Items.Clear();
                siteList.Clear();
            }
        }
        private void cmbRegions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbRegions.SelectedIndex >= 0)
            {
                Region region = regionList[cmbRegions.SelectedIndex];
                PopulateSites(region);
                WriteStatus(region.regionName);
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            stStatusBar.Items.Clear();
            stStatusBar.Items.Add("Exit");
            //System.Windows.Application.Current.Shutdown();
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
    }
}

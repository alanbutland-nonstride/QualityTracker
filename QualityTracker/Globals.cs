using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualityTracker
{
    public static class Globals
    {
        public static TrackerOptions trackerOptions;
    }

    public class TrackerOptions
    {
        public List<Directorate> directorates;
        public List<Region> regions;
        public List<Site> sites;

        public TrackerOptions()
        {
            this.directorates = new List<Directorate>();
            this.regions = new List<Region>();
            this.sites = new List<Site>();
        }

        public void GetAll()
        {
            DBFunctions.GetDirectorates();
            DBFunctions.GetRegions();
            DBFunctions.GetSites();
        }
    }

    public class Directorate
    {
        public int directorateID;
        public string directorateName;

        public Directorate(int directorateID, string directorateName)
        {
            this.directorateID = directorateID;
            this.directorateName = directorateName;
        }
    }

    public class Region
    {
        public int regionID;
        public string regionName;
        public int directorateID;

        public Region(int regionID, string regionName, int directorateID)
        {
            this.regionID = regionID;
            this.regionName = regionName;
            this.directorateID = directorateID;
        }
    }

    public class Site
    {
        public int siteID;
        public string siteName;
        public int regionID;
        public int directorateID;

        public Site(int siteID, string siteName, int regionID, int directorateID)
        {
            this.siteID = siteID;
            this.siteName = siteName;
            this.regionID = regionID;
            this.directorateID = directorateID;
        }
    }
}

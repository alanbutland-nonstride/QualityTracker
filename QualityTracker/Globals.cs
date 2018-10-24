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
        public List<Op> ops;

        public TrackerOptions()
        {
            this.directorates = new List<Directorate>();
            this.regions = new List<Region>();
            this.sites = new List<Site>();
            this.ops = new List<Op>();
        }

        public void GetAll()
        {
            DBFunctions.GetDirectorates();
            DBFunctions.GetRegions();
            DBFunctions.GetSites();
            DBFunctions.GetOps();
        }
    }

    public class Directorate
    {
        public int directorate_id;
        public string directorate_text;
        public bool directorate_inactive;

        public Directorate(int directorate_id, string directorate_text, bool directorate_inactive)
        {
            this.directorate_id = directorate_id;
            this.directorate_text = directorate_text;
            this.directorate_inactive = directorate_inactive;
        }
    }
    public class Region
    {
        public int region_id;
        public string region_text;
        public int directorate_id;
        public bool region_inactive;

        public Region(int region_id, string region_text, int directorate_id, bool region_inactive)
        {
            this.region_id = region_id;
            this.region_text = region_text;
            this.directorate_id = directorate_id;
            this.region_inactive = region_inactive;
        }
    }
    public class Site
    {
        public int site_id;
        public string site_text;
        public int site_business_units;
        public int directorate_id;
        public int region_id;
        public bool site_inactive;

        public Site(int site_id, string site_text, int site_business_units, int directorate_id, int region_id, bool site_inactive)
        {
            this.site_id = site_id;
            this.site_text = site_text;
            this.site_business_units = site_business_units;
            this.directorate_id = directorate_id;
            this.region_id = region_id;
            this.site_inactive = site_inactive;
        }
    }
    public class Op
    {
        public int op_id;
        public string op_text;
        public int op_manager_pid;
        public string op_manager_name;
        public int site_id;
        public int op_business_unit;
        public bool op_inactive;

        public Op(int op_id, string op_text, int op_manager_pid, string op_manager_name, int site_id, int op_business_unit, bool op_inactive)
        {
            this.op_id = op_id;
            this.op_text = op_text;
            this.op_manager_pid = op_manager_pid;
            this.op_manager_name = op_manager_name;
            this.site_id = site_id;
            this.op_business_unit = op_business_unit;
            this.op_inactive = op_inactive;
        }
    }
}

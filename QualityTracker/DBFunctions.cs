using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Data.Common;

namespace QualityTracker
{
    public static class DBFunctions
    {
        public static SqlConnection dbConn;

        public static void OpenDB()
        {
            dbConn = new SqlConnection();
            try
            {
                Debug.WriteLine("Connecting to Database ...");
                dbConn = new SqlConnection("Data Source=DESKTOP-939S9AC;Initial Catalog=QualityTracker;Integrated Security=True");
                dbConn.Open();
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error : " + e.Message);
            }
        }
        public static void GetDirectorates()
        {
            OpenDB();

            SqlCommand sqlQuery = new SqlCommand();
            sqlQuery.Connection = dbConn;
            sqlQuery.CommandText = "SELECT * FROM tbl_org_directorate";

            using (DbDataReader reader = sqlQuery.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int directorate_id = reader.GetByte(0);
                        string directorate_text = reader.GetString(1);
                        bool directorate_inactive = reader.GetBoolean(2);

                        Directorate dir = new Directorate(directorate_id, directorate_text, directorate_inactive);
                        Globals.trackerOptions.directorates.Add(dir);
                    }
                    reader.NextResult();
                }
                else
                {
                    Debug.WriteLine("Error : Empty Table");
                }
            }
        }
        public static void GetRegions()
        {
            OpenDB();

            SqlCommand sqlQuery = new SqlCommand();
            sqlQuery.Connection = dbConn;
            sqlQuery.CommandText = "SELECT * FROM tbl_org_region";

            using (DbDataReader reader = sqlQuery.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int region_id = reader.GetByte(0);
                        string region_text = reader.GetString(1);
                        int directorate_id = reader.GetByte(2);
                        bool directorate_inactive = reader.GetBoolean(3);

                        Region region = new Region(region_id, region_text, directorate_id, directorate_inactive);
                        Globals.trackerOptions.regions.Add(region);
                    }
                    reader.NextResult();
                }
                else
                {
                    Debug.WriteLine("Error : Empty Table");
                }
            }
        }
        public static void GetSites()
        {
            OpenDB();

            SqlCommand sqlQuery = new SqlCommand();
            sqlQuery.Connection = dbConn;
            sqlQuery.CommandText = "SELECT * FROM tbl_org_site";

            using (DbDataReader reader = sqlQuery.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int site_id = reader.GetInt16(0);
                        string site_text = reader.GetString(1);
                        int site_business_units = reader.GetByte(2);
                        int directorate_id = reader.GetByte(3);
                        int region_id = reader.GetByte(4);
                        bool site_inactive = reader.GetBoolean(5);

                        Site site = new Site(site_id, site_text, site_business_units, directorate_id, region_id, site_inactive);
                        Globals.trackerOptions.sites.Add(site);
                    }
                    reader.NextResult();
                }
                else
                {
                    Debug.WriteLine("Error : Empty Table");
                }
            }
        }
        public static void GetOps()
        {
            OpenDB();

            SqlCommand sqlQuery = new SqlCommand();
            sqlQuery.Connection = dbConn;
            sqlQuery.CommandText = "SELECT * FROM tbl_org_op";

            using (DbDataReader reader = sqlQuery.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int op_id = reader.GetInt16(0);
                        string op_text = reader.GetString(1);
                        int op_manager_pid = reader.GetInt32(2);
                        string op_manager_name = reader.GetString(3);
                        int site_id = reader.GetInt16(4);
                        int op_business_unit = reader.GetByte(5);
                        bool op_inactive = reader.GetBoolean(6);

                        Op op = new Op(op_id, op_text, op_manager_pid, op_manager_name, site_id, op_business_unit, op_inactive);
                        Globals.trackerOptions.ops.Add(op);
                    }
                    reader.NextResult();
                }
                else
                {
                    Debug.WriteLine("Error : Empty Table");
                }
            }
        }

        //public void EditTestTableRecord(Adviser adv)
        //{
        //    OpenDB();

        //    SqlCommand sqlQuery = new SqlCommand();
        //    sqlQuery.Connection = dbConn;
        //    sqlQuery.CommandText = "UPDATE TestTable SET colName = '" + adv.name + "', colPID = " + adv.pid + " WHERE id = " + adv.id;
        //    Debug.WriteLine(sqlQuery.CommandText);
        //    sqlQuery.ExecuteNonQuery();
        //}
    }
}

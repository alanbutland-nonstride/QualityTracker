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
            sqlQuery.CommandText = "SELECT * FROM tblDirectorates";

            using (DbDataReader reader = sqlQuery.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int directorateID = reader.GetByte(0);
                        string directorateName = reader.GetString(1);

                        Directorate dir = new Directorate(directorateID, directorateName);
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
            sqlQuery.CommandText = "SELECT * FROM tblRegions";

            using (DbDataReader reader = sqlQuery.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int regionID = reader.GetByte(0);
                        string regionName = reader.GetString(1);
                        int directorateID = reader.GetByte(2);

                        Region region = new Region(regionID, regionName, directorateID);
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
            sqlQuery.CommandText = "SELECT * FROM tblSites";

            using (DbDataReader reader = sqlQuery.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int siteID = reader.GetByte(0);
                        string siteName = reader.GetString(1);
                        int regionID = reader.GetByte(2);
                        int directorateID = reader.GetByte(3);

                        Site site = new Site(siteID, siteName, regionID, directorateID);
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

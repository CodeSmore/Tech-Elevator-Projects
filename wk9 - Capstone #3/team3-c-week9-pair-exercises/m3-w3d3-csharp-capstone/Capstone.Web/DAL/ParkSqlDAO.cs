using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Capstone.Web.Models;

namespace Capstone.Web.DAL
{
    public class ParkSqlDAO : IParkDAO
    {
        private const string Sql_GetAllParks = "SELECT * FROM park";
        private const string SQL_GetParkDetails = "SELECT * FROM park WHERE parkCode = @parkCode";

        private string connectionString;
        public ParkSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Park> GetAllParks()
        {
            List<Park> result = new List<Park>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(Sql_GetAllParks);
                    cmd.Connection = conn;

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        result.Add(MapRowToPark(reader));
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }

            return result;
        }

        public Park GetParkDetails(string parkCode)
        {
            Park userPark = new Park();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_GetParkDetails);
                    cmd.Connection = conn;

                    cmd.Parameters.AddWithValue("@parkCode", parkCode);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        userPark.ParkCode = parkCode;
                        userPark = MapRowToPark(reader);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }

            return userPark;
        }
    

    private Park MapRowToPark(SqlDataReader sdr)
    {
        return new Park()
        {
            ParkCode = Convert.ToString(sdr["parkCode"]),
            ParkName = Convert.ToString(sdr["parkName"]),
            State = Convert.ToString(sdr["state"]),
            Acreage = Convert.ToInt32(sdr["acreage"]),
            ElevationInFeet = Convert.ToInt32(sdr["elevationInFeet"]),
            MilesOfTrail = Convert.ToDouble(sdr["milesOfTrail"]),
            NumberOfCampsites = Convert.ToInt32(sdr["numberOfCampsites"]),
            Climate = Convert.ToString(sdr["climate"]),
            YearFounded = Convert.ToInt32(sdr["yearFounded"]),
            AnnualVisitorCount = Convert.ToInt32(sdr["annualVisitorCount"]),
            InspirationalQuote = Convert.ToString(sdr["inspirationalQuote"]),
            InspirationalQuoteSource = Convert.ToString(sdr["inspirationalQuoteSource"]),
            ParkDescription = Convert.ToString(sdr["parkDescription"]),
            EntryFee = Convert.ToInt32(sdr["entryFee"]),
            NumberOfAnimalSpecies = Convert.ToInt32(sdr["numberOfAnimalSpecies"]),
        };
    }
}
}
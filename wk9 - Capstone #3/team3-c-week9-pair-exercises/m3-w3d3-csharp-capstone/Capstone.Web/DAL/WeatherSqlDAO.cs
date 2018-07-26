using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capstone.Web.Models;
using System.Data.SqlClient;

namespace Capstone.Web.DAL
{
    public class WeatherSqlDAO : IWeatherDAO
    {
        private const string Sql_GetForcast = "SELECT * FROM weather WHERE parkCode = @parkCode";

        private string connectionString;
        public WeatherSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Weather> GetForcast(string parkCode)
        {
            List<Weather> result = new List<Weather>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(Sql_GetForcast);
                    cmd.Connection = conn;
                    cmd.Parameters.AddWithValue("@parkCode", parkCode);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        result.Add(MapRowToWeather(reader));
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }

            return result;
        }

        private Weather MapRowToWeather(SqlDataReader sdr)
        {
            return new Weather()
            {
                ParkCode = Convert.ToString(sdr["parkCode"]),
                FiveDayForecastValue = Convert.ToInt32(sdr["fiveDayForecastValue"]),
                Low = Convert.ToInt32(sdr["low"]),
                High = Convert.ToInt32(sdr["high"]),
                Forecast = Convert.ToString(sdr["forecast"])
            };
        }
    }
}
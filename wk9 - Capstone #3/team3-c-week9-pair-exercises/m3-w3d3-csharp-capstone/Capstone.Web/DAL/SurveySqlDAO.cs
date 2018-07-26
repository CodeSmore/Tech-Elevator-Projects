using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Capstone.Web.Models;

namespace Capstone.Web.DAL
{
    public class SurveySqlDAO : ISurveyDAO
    {
        private const string Sql_InsertSurvey = @"INSERT INTO survey_result VALUES (@parkCode, @emailAddress, @state, @activityLevel)";
        private const string Sql_GetTopFive = @"SELECT TOP 5 COUNT(sr.parkCode) AS surveyCount, p.parkName, p.parkCode FROM survey_result sr JOIN park p on sr.parkCode = p.parkCode GROUP BY p.parkName, p.parkCode ORDER BY COUNT(sr.parkCode) DESC";

        private string connectionString;
        public SurveySqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public bool InsertSurvey(SurveyEntry newReview)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(Sql_InsertSurvey);
                    cmd.Connection = conn;
                    cmd.Parameters.AddWithValue("@parkCode", newReview.ParkCode);
                    cmd.Parameters.AddWithValue("@emailAddress", newReview.EmailAddress);
                    cmd.Parameters.AddWithValue("@state", newReview.State);
                    cmd.Parameters.AddWithValue("@activityLevel", newReview.ActivityLevel);
                    
                    int num = cmd.ExecuteNonQuery();

                    return (num > 0);
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
        }

        public List<SurveyResult> GetTopFiveParks()
        {
            List<SurveyResult> resultList = new List<SurveyResult>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(Sql_GetTopFive);
                    cmd.Connection = conn;

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        resultList.Add(MapRowToSurveyResult(reader));
                    }
                    
                }
            }
            catch (SqlException ex)
            {
                throw;
            }

            return resultList;
        }

        private SurveyResult MapRowToSurveyResult(SqlDataReader sdr)
        {
            return new SurveyResult()
            {
                Count = Convert.ToInt32(sdr["surveyCount"]),
                ParkName = Convert.ToString(sdr["parkName"]),
                ParkCode = Convert.ToString(sdr["parkCode"]),
            };
        }
    }
}
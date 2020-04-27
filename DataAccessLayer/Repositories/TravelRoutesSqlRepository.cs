using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class TravelRoutesSqlRepository : SqlRepository<TravelRoute>
    {

        private static readonly string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

        public override bool Create(TravelRoute travelRoute)
        {
            int numOfRowsAffected = 0;

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();

                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "InsertTravelRoute";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DateIssued", SqlDbType.Date).Value = travelRoute.DateIssued;
                    cmd.Parameters.Add("@TimeIssued", SqlDbType.Time).Value = travelRoute.TimeIssued;
                    cmd.Parameters.Add("@Origin", SqlDbType.NVarChar).Value = travelRoute.Origin;
                    cmd.Parameters.Add("@Destination", SqlDbType.NVarChar).Value = travelRoute.Destination;
                    cmd.Parameters.Add("@KilometersTraveled", SqlDbType.Real).Value = travelRoute.KilometersTraveled;
                    cmd.Parameters.Add("@AverageSpeed", SqlDbType.Real).Value = travelRoute.AverageSpeed;
                    cmd.Parameters.Add("@SpentFuel", SqlDbType.Real).Value = travelRoute.SpentFuel;

                    numOfRowsAffected = cmd.ExecuteNonQuery();
                }
            }
            if (numOfRowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override bool Delete(int id)
        {
            int numOfRowsAffected = 0;

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();

                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "DeleteTravelRoute";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                    numOfRowsAffected = cmd.ExecuteNonQuery();
                }
            }
            if (numOfRowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override List<TravelRoute> ReadAll()
        {
            List<TravelRoute> travelRoutes = new List<TravelRoute>();

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();

                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "GetTravelRoutes";
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                travelRoutes.Add(new TravelRoute
                                {
                                    Id = (int)reader["Id"],
                                    DateIssued = (DateTime)reader["DateIssued"],
                                    TimeIssued = (TimeSpan)reader["TimeIssued"],
                                    Origin = reader["Origin"].ToString(),
                                    Destination = reader["Destination"].ToString(),
                                    KilometersTraveled = (float)reader["KilometersTraveled"],
                                    AverageSpeed = (float)reader["AverageSpeed"],
                                    SpentFuel = (float)reader["SpentFuel"]
                                });
                            }
                        }
                    }
                }
            }

            return travelRoutes;
        }

        public override TravelRoute ReadById(int id)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();

                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "GetTravelRoute";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                return new TravelRoute
                                {
                                    Id = (int)reader["Id"],
                                    DateIssued = (DateTime)reader["DateIssued"],
                                    TimeIssued = (TimeSpan)reader["TimeIssued"],
                                    Origin = reader["Origin"].ToString(),
                                    Destination = reader["Destination"].ToString(),
                                    KilometersTraveled = (float)reader["KilometersTraveled"],
                                    AverageSpeed = (float)reader["AverageSpeed"],
                                    SpentFuel = (float)reader["SpentFuel"]
                                };
                            }
                        }
                    }
                }
                return null;
            }
        }

        public override bool Update(TravelRoute t)
        {
            throw new NotImplementedException();
        }
    }
}

using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DataAccessLayer.Repositories
{
    public class TravelWarrantsSqlRepository : SqlRepository<TravelWarrant>
    {
        private static readonly string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

        public override bool Create(TravelWarrant travelWarrant)
        {
            int numOfRowsAffected = 0;

            SqlTransaction sqlTransaction = null;

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.InfoMessage += new SqlInfoMessageEventHandler(Con_InfoMessage);
                con.FireInfoMessageEventOnUserErrors = true;

                con.Open();

                sqlTransaction = con.BeginTransaction();

                try
                {
                    using (SqlCommand cmd = con.CreateCommand())
                    {
                        cmd.Transaction = sqlTransaction;

                        cmd.CommandText = "InsertTravelWarrant";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@WarrantStatus", SqlDbType.NVarChar).Value = travelWarrant.WarrantStatus;
                        cmd.Parameters.Add("@DateIssued", SqlDbType.Date).Value = travelWarrant.DateIssued;
                        cmd.Parameters.Add("@TimeIssued", SqlDbType.Time).Value = travelWarrant.TimeIssued;
                        cmd.Parameters.Add("@DriverId", SqlDbType.Int).Value = travelWarrant.DriverId;
                        cmd.Parameters.Add("@VehicleId", SqlDbType.Int).Value = travelWarrant.VehicleId;
                        cmd.Parameters.Add("@FuelCostId", SqlDbType.Int).Value = travelWarrant.FuelCostId;
                        cmd.Parameters.Add("@TravelRouteId", SqlDbType.Int).Value = travelWarrant.TravelRouteId;

                        numOfRowsAffected = cmd.ExecuteNonQuery();
                    }

                    sqlTransaction.Commit();

                    if (numOfRowsAffected > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);

                    sqlTransaction.Rollback();

                    return false;
                }
            }
        }

        public override bool Delete(int id)
        {
            int numOfRowsAffected = 0;

            SqlTransaction sqlTransaction = null;

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.InfoMessage += new SqlInfoMessageEventHandler(Con_InfoMessage);
                con.FireInfoMessageEventOnUserErrors = true;

                con.Open();

                sqlTransaction = con.BeginTransaction();

                try
                {
                    using (SqlCommand cmd = con.CreateCommand())
                    {
                        cmd.Transaction = sqlTransaction;

                        cmd.CommandText = "DeleteTravelWarrant";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                        numOfRowsAffected = cmd.ExecuteNonQuery();
                    }

                    sqlTransaction.Commit();

                    if (numOfRowsAffected > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);

                    sqlTransaction.Rollback();

                    return false;
                }
            }
        }

        public override List<TravelWarrant> ReadAll()
        {
            List<TravelWarrant> travelWarrants = new List<TravelWarrant>();

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();

                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "GetTravelWarrants";
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                travelWarrants.Add(new TravelWarrant
                                {
                                    Id = (int)reader["Id"],
                                    WarrantStatus = reader["WarrantStatus"].ToString(),
                                    DateIssued = (DateTime)reader["DateIssued"],
                                    TimeIssued = (TimeSpan)reader["TimeIssued"],
                                    DriverId = (int)reader["DriverId"],
                                    VehicleId = (int)reader["VehicleId"],
                                    FuelCostId = (int)reader["FuelCostId"],
                                    TravelRouteId = (int)reader["TravelRouteId"],
                                });

                            }
                        }
                    }
                }
            }
            return travelWarrants;
        }

        public override TravelWarrant ReadById(int id)
        {
            throw new NotImplementedException();
        }

        public override bool Update(TravelWarrant travelWarrant)
        {
            int numOfRowsAffected = 0;

            SqlTransaction sqlTransaction = null;

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.InfoMessage += new SqlInfoMessageEventHandler(Con_InfoMessage);
                con.FireInfoMessageEventOnUserErrors = true;

                con.Open();

                sqlTransaction = con.BeginTransaction();

                try
                {
                    using (SqlCommand cmd = con.CreateCommand())
                    {
                        cmd.Transaction = sqlTransaction;

                        cmd.CommandText = "UpdateTravelWarrant";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@WarrantStatus", SqlDbType.NVarChar).Value = travelWarrant.WarrantStatus;
                        cmd.Parameters.Add("@DateIssued", SqlDbType.Date).Value = travelWarrant.DateIssued;
                        cmd.Parameters.Add("@TimeIssued", SqlDbType.Time).Value = travelWarrant.TimeIssued;
                        cmd.Parameters.Add("@DriverId", SqlDbType.Int).Value = travelWarrant.DriverId;
                        cmd.Parameters.Add("@VehicleId", SqlDbType.Int).Value = travelWarrant.VehicleId;
                        cmd.Parameters.Add("@FuelCostId", SqlDbType.Int).Value = travelWarrant.FuelCostId;
                        cmd.Parameters.Add("@TravelRouteId", SqlDbType.Int).Value = travelWarrant.TravelRouteId;
                        cmd.Parameters.Add("@Id", SqlDbType.Int).Value = travelWarrant.Id;

                        numOfRowsAffected = cmd.ExecuteNonQuery();
                    }

                    sqlTransaction.Commit();

                    if (numOfRowsAffected > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);

                    sqlTransaction.Rollback();

                    return false;
                }
            }
        }

        private static void Con_InfoMessage(object sender, SqlInfoMessageEventArgs args)
        {
            MessageBox.Show($"InfoMessage Handled Error Level - { args.Errors[0].Class }: { args.Message } ");
        }

        public override void Restore(TravelWarrant travelWarrant)
        {
            SqlTransaction sqlTransaction = null;

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.InfoMessage += new SqlInfoMessageEventHandler(Con_InfoMessage);
                con.FireInfoMessageEventOnUserErrors = true;

                con.Open();

                sqlTransaction = con.BeginTransaction();

                try
                {
                    using (SqlCommand cmd = con.CreateCommand())
                    {
                        cmd.Transaction = sqlTransaction;

                        cmd.CommandText = "RestoreTravelWarrant";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@Id", SqlDbType.NVarChar).Value = travelWarrant.Id;
                        cmd.Parameters.Add("@WarrantStatus", SqlDbType.NVarChar).Value = travelWarrant.WarrantStatus;
                        cmd.Parameters.Add("@DateIssued", SqlDbType.Date).Value = travelWarrant.DateIssued;
                        cmd.Parameters.Add("@TimeIssued", SqlDbType.Time).Value = travelWarrant.TimeIssued;
                        cmd.Parameters.Add("@DriverId", SqlDbType.Int).Value = travelWarrant.DriverId;
                        cmd.Parameters.Add("@VehicleId", SqlDbType.Int).Value = travelWarrant.VehicleId;
                        cmd.Parameters.Add("@FuelCostId", SqlDbType.Int).Value = travelWarrant.FuelCostId;
                        cmd.Parameters.Add("@TravelRouteId", SqlDbType.Int).Value = travelWarrant.TravelRouteId;

                        cmd.ExecuteNonQuery();
                    }

                    sqlTransaction.Commit();                    
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);

                    sqlTransaction.Rollback();
                }
            }
        }
    }
}

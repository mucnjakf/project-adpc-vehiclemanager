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
    public class FuelCostsSqlRepository : SqlRepository<FuelCost>
    {
        private static readonly string cs = ConfigurationManager.ConnectionStrings["VehicleManagerDbContext"].ConnectionString;

        public override bool Create(FuelCost fuelCost)
        {
            int numOfRowsAffected = 0;

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();

                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "InsertFuelCost";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Date", SqlDbType.Date).Value = fuelCost.DateIssued;
                    cmd.Parameters.Add("@Time", SqlDbType.Time).Value = fuelCost.TimeIssued;
                    cmd.Parameters.Add("@Position", SqlDbType.NVarChar).Value = fuelCost.Position;
                    cmd.Parameters.Add("@Amount", SqlDbType.Real).Value = fuelCost.Amount;
                    cmd.Parameters.Add("@Price", SqlDbType.Money).Value = fuelCost.Price;

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
                    cmd.CommandText = "DeleteFuelCost";
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

        public override List<FuelCost> ReadAll()
        {
            List<FuelCost> fuelCosts = new List<FuelCost>();

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();

                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "GetFuelCosts";
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                fuelCosts.Add(new FuelCost
                                {
                                    Id = (int)reader["Id"],
                                    DateIssued = (DateTime)reader["DateIssued"],
                                    TimeIssued = (TimeSpan)reader["TimeIssued"],
                                    Position = reader["Position"].ToString(),
                                    Amount = (float)reader["Amount"],
                                    Price = (decimal)reader["Price"]
                                });
                            }
                        }
                    }
                }
            }
            return fuelCosts;
        }

        public override bool Update(FuelCost fuelCost)
        {
            throw new NotImplementedException();
        }

        public override FuelCost ReadById(int id)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();

                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "GetFuelCost";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                return new FuelCost
                                {
                                    Id = (int)reader["Id"],
                                    DateIssued = (DateTime)reader["DateIssued"],
                                    TimeIssued = (TimeSpan)reader["TimeIssued"],
                                    Position = reader["Position"].ToString(),
                                    Amount = (float)reader["Amount"],
                                    Price = (decimal)reader["Price"]
                                };
                            }
                        }
                    }
                }
            }
            return null;
        }

        public override void Restore(FuelCost fuelCost)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();

                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "RestoreFuelCost";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = fuelCost.Id;
                    cmd.Parameters.Add("@Date", SqlDbType.Date).Value = fuelCost.DateIssued;
                    cmd.Parameters.Add("@Time", SqlDbType.Time).Value = fuelCost.TimeIssued;
                    cmd.Parameters.Add("@Position", SqlDbType.NVarChar).Value = fuelCost.Position;
                    cmd.Parameters.Add("@Amount", SqlDbType.Real).Value = fuelCost.Amount;
                    cmd.Parameters.Add("@Price", SqlDbType.Money).Value = fuelCost.Price;

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public override void DeleteAll()
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();

                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "DeleteAllFuelCosts";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
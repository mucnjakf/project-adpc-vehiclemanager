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
    public class VehiclesSqlRepository : SqlRepository<Vehicle>
    {
        private static readonly string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

        public override bool Create(Vehicle vehicle)
        {
            int numOfRowsAffected = 0;

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();

                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "InsertVehicle";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Make", SqlDbType.NVarChar).Value = vehicle.Make;
                    cmd.Parameters.Add("@Model", SqlDbType.NVarChar).Value = vehicle.Model;
                    cmd.Parameters.Add("@YearOfManufacture", SqlDbType.Int).Value = vehicle.YearOfManufacture;
                    cmd.Parameters.Add("@InitialMileage", SqlDbType.Int).Value = vehicle.InitialMileage;
                    cmd.Parameters.Add("@Available", SqlDbType.Bit).Value = vehicle.Available;

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
                    cmd.CommandText = "DeleteVehicle";
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

        public override List<Vehicle> ReadAll()
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();

                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "GetVehicles";
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                vehicles.Add(new Vehicle
                                {
                                    Id = (int)reader["Id"],
                                    Make = reader["Make"].ToString(),
                                    Model = reader["Model"].ToString(),
                                    YearOfManufacture = (int)reader["YearOfManufacture"],
                                    InitialMileage = (int)reader["InitialMileAge"],
                                    Available = (bool)reader["Available"]
                                });

                            }
                        }
                    }
                }
            }
            return vehicles;
        }

        public override bool Update(Vehicle vehicle)
        {
            int numOfRowsAffected = 0;

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();

                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "UpdateVehicle";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Make", SqlDbType.NVarChar).Value = vehicle.Make;
                    cmd.Parameters.Add("@Model", SqlDbType.NVarChar).Value = vehicle.Model;
                    cmd.Parameters.Add("@YearOfManufacture", SqlDbType.Int).Value = vehicle.YearOfManufacture;
                    cmd.Parameters.Add("@InitialMileage", SqlDbType.Int).Value = vehicle.InitialMileage;
                    cmd.Parameters.Add("@Available", SqlDbType.Bit).Value = vehicle.Available;
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = vehicle.Id;

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

        public override Vehicle ReadById(int id)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();

                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "GetVehicle";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                return new Vehicle
                                {
                                    Id = (int)reader["Id"],
                                    Make = reader["Make"].ToString(),
                                    Model = reader["Model"].ToString(),
                                    YearOfManufacture = (int)reader["YearOfManufacture"],
                                    InitialMileage = (int)reader["InitialMileage"],
                                    Available = (bool)reader["Available"]
                                };
                            }
                        }
                    }
                }
                return null;
            }
        }

        public override void Restore(Vehicle vehicle)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();

                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "RestoreVehicle";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = vehicle.Id;
                    cmd.Parameters.Add("@Make", SqlDbType.NVarChar).Value = vehicle.Make;
                    cmd.Parameters.Add("@Model", SqlDbType.NVarChar).Value = vehicle.Model;
                    cmd.Parameters.Add("@YearOfManufacture", SqlDbType.Int).Value = vehicle.YearOfManufacture;
                    cmd.Parameters.Add("@InitialMileage", SqlDbType.Int).Value = vehicle.InitialMileage;
                    cmd.Parameters.Add("@Available", SqlDbType.Bit).Value = vehicle.Available;

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
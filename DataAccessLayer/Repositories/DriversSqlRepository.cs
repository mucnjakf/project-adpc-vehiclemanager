using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class DriversSqlRepository : SqlRepository<Driver>
    {
        public readonly string cs = ConfigurationManager.ConnectionStrings["VehicleManagerDbContext"].ConnectionString;

        public override List<Driver> ReadAll()
        {
            List<Driver> drivers = new List<Driver>();

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();

                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Drivers";

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                drivers.Add(new Driver
                                {
                                    Id = (int)reader["Id"],
                                    FirstName = reader["FirstName"].ToString(),
                                    LastName = reader["LastName"].ToString(),
                                    PhoneNumber = reader["PhoneNumber"].ToString(),
                                    DriversLicenceNumber = reader["DriversLicenceNumber"].ToString()
                                });

                            }
                        }
                    }
                }
            }
            return drivers;
        }

        public override bool Create(Driver driver)
        {
            int numOfRowsAffected = 0;

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();

                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = $"INSERT INTO Drivers VALUES ('{ driver.FirstName }', '{ driver.LastName }', '{ driver.PhoneNumber }', '{ driver.DriversLicenceNumber }')";

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

        public override bool Update(Driver driver)
        {
            int numOfRowsAffected = 0;

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();

                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = $"UPDATE Drivers SET FirstName = '{ driver.FirstName }', LastName = '{ driver.LastName }', PhoneNumber = '{ driver.PhoneNumber }', DriversLicenceNumber = '{ driver.DriversLicenceNumber }' WHERE Id = { driver.Id }";

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
                    cmd.CommandText = $"DELETE FROM TravelWarrants WHERE DriverId = {id} DELETE FROM Drivers WHERE Id = {id}";
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

        public override Driver ReadById(int id)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();

                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = $"SELECT * FROM Drivers WHERE Id = {id}";

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                return new Driver
                                {
                                    Id = (int)reader["Id"],
                                    FirstName = reader["FirstName"].ToString(),
                                    LastName = reader["LastName"].ToString(),
                                    PhoneNumber = reader["PhoneNumber"].ToString(),
                                    DriversLicenceNumber = reader["DriversLicenceNumber"].ToString()
                                };
                            }
                        }
                    }
                }
                return null;
            }
        }

        public override void Restore(Driver driver)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();

                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText =
                        $"IF NOT EXISTS (SELECT * FROM Drivers WHERE Id = {driver.Id}) " +
                        $"BEGIN " +
                        $"SET IDENTITY_INSERT Drivers ON " +
                        $"INSERT INTO Drivers(Id, FirstName, LastName, PhoneNumber, DriversLicenceNumber) VALUES({driver.Id}, '{driver.FirstName}', '{driver.LastName}', '{driver.PhoneNumber}', '{driver.DriversLicenceNumber}') " +
                        $"SET IDENTITY_INSERT Drivers OFF " +
                        $"END";

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
                    cmd.CommandText = "DELETE FROM Drivers";

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}


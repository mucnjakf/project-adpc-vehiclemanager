using DataAccessLayer.Models;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
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
    public class TravelRoutesSqlRepository
    {
        private static readonly string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        private static readonly SqlDatabase db = new SqlDatabase(cs);

        public bool Create(TravelRoute travelRoute)
        {
            int numOfRowsAffected = db.ExecuteNonQuery("InsertTravelRoute", travelRoute.DateIssued, travelRoute.TimeIssued, travelRoute.Origin, travelRoute.Destination, travelRoute.KilometersTraveled, travelRoute.AverageSpeed, travelRoute.SpentFuel);

            if (numOfRowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            int numOfRowsAffected = db.ExecuteNonQuery("DeleteTravelRoute", id);

            if (numOfRowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<TravelRoute> ReadAll()
        {
           
        }


    }
}

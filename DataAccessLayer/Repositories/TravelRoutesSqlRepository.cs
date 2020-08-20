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
    public class TravelRoutesSqlRepository : SqlRepository<TravelRoute>
    {
        private static readonly string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        private static readonly SqlDatabase db = new SqlDatabase(cs);

        public override bool Create(TravelRoute travelRoute)
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

        public override bool Delete(int id)
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

        public override List<TravelRoute> ReadAll()
        {
            List<TravelRoute> travelRoutes = new List<TravelRoute>();
            DataSet ds = db.ExecuteDataSet("GetTravelRoutes");

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                TravelRoute travelRoute = new TravelRoute()
                {
                    Id = (int)row["Id"],
                    DateIssued = (DateTime)row["DateIssued"],
                    TimeIssued = (TimeSpan)row["TimeIssued"],
                    Origin = row["Origin"].ToString(),
                    Destination = row["Destination"].ToString(),
                    KilometersTraveled = (float)row["KilometersTraveled"],
                    AverageSpeed = (float)row["AverageSpeed"],
                    SpentFuel = (float)row["SpentFuel"]
                };

                travelRoutes.Add(travelRoute);
            }

            return travelRoutes;
        }

        public override TravelRoute ReadById(int id)
        {
            TravelRoute travelRoute = new TravelRoute();
            DataSet ds = db.ExecuteDataSet("GetTravelRoute", id);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                travelRoute.Id = (int)row["Id"];
                travelRoute.DateIssued = (DateTime)row["DateIssued"];
                travelRoute.TimeIssued = (TimeSpan)row["TimeIssued"];
                travelRoute.Origin = row["Origin"].ToString();
                travelRoute.Destination = row["Destination"].ToString();
                travelRoute.KilometersTraveled = (float)row["KilometersTraveled"];
                travelRoute.AverageSpeed = (float)row["AverageSpeed"];
                travelRoute.SpentFuel = (float)row["SpentFuel"];
            }

            return travelRoute;
        }

        public override void Restore(TravelRoute travelRoute)
        {
            db.ExecuteNonQuery("RestoreTravelRoute", travelRoute.Id, travelRoute.DateIssued, travelRoute.TimeIssued, travelRoute.Origin, travelRoute.Destination, travelRoute.KilometersTraveled, travelRoute.AverageSpeed, travelRoute.SpentFuel);
        }

        public override bool Update(TravelRoute t)
        {
            throw new NotImplementedException();
        }
    }
}

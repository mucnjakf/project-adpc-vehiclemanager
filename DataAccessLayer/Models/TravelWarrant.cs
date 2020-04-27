using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class TravelWarrant
    {
        public int Id { get; set; }

        public string WarrantStatus { get; set; }

        public DateTime DateIssued { get; set; }

        public TimeSpan TimeIssued { get; set; }

        public int DriverId { get; set; }

        public int VehicleId { get; set; }

        public int FuelCostId { get; set; }

        public int TravelRouteId { get; set; }
    }
}

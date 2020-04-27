using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class TravelRoute
    {
        public int Id { get; set; }
        public DateTime DateIssued { get; set; }
        public TimeSpan TimeIssued { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public float KilometersTraveled { get; set; }
        public float AverageSpeed { get; set; }
        public float SpentFuel { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int YearOfManufacture { get; set; }
        public int InitialMileage { get; set; }
        public bool Available { get; set; }

        public override string ToString()
        {
            return $"{Id} - {Make} {Model}";
        }

    }
}

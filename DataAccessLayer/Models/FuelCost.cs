using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class FuelCost
    {
        public int Id { get; set; }
        public DateTime DateIssued { get; set; }
        public TimeSpan TimeIssued { get; set; }
        public string Position { get; set; }
        public float Amount { get; set; }
        public decimal Price { get; set; }
    }
}

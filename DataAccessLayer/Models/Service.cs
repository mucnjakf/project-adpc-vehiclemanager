using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Service
    {
        public int Id { get; set; }
        public DateTime DateIssued { get; set; }
        public TimeSpan TimeIssued { get; set; }
        public decimal TotalPrice { get; set; }
        public List<ServiceItem> ServiceItems { get; set; }
        public Vehicle Vehicle { get; set; }        
    }
}

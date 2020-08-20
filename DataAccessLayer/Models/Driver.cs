using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Driver
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string DriversLicenceNumber { get; set; }

        public override string ToString()
        {
            return $"{Id} - {FirstName} {LastName}";
        }

        public string TestPrint()
        {
            return $"{Id}\n{FirstName}\n{LastName}\n{PhoneNumber}\n{DriversLicenceNumber}";
        }
    }
}

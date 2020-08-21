using DataAccessLayer.DatabaseContext;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class ServiceItemsSqlRepository : SqlRepository<ServiceItem>
    {
        readonly VehicleManagerDbContext db = new VehicleManagerDbContext();

        public override bool Create(ServiceItem serviceItem)
        {
            db.ServiceItems.Add(serviceItem);
            int success = db.SaveChanges();

            return success > 0;
        }

        public override bool Delete(int id)
        {
            ServiceItem serviceItem = db.ServiceItems.Where(s => s.Id == id).FirstOrDefault();

            db.ServiceItems.Remove(serviceItem);
            int success = db.SaveChanges();

            return success > 0;
        }

        public override void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public override List<ServiceItem> ReadAll()
        {
            return db.ServiceItems.ToList();
        }

        public override ServiceItem ReadById(int id)
        {
            return db.ServiceItems.ToList().FirstOrDefault(s => s.Id == id);
        }

        public override void Restore(ServiceItem serviceItem)
        {
            throw new NotImplementedException();
        }

        public override bool Update(ServiceItem inputServiceItem)
        {
            ServiceItem serviceItem = db.ServiceItems.Where(s => s.Id == inputServiceItem.Id).FirstOrDefault();

            serviceItem.Name = inputServiceItem.Name;
            serviceItem.Price = inputServiceItem.Price;

            int success = db.SaveChanges();

            return success > 0;
        }
    }
}

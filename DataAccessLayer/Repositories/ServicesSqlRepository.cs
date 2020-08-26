using DataAccessLayer.DatabaseContext;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DataAccessLayer.Repositories
{
    public class ServicesSqlRepository : SqlRepository<Service>
    {
        readonly VehicleManagerDbContext db = new VehicleManagerDbContext();

        public bool Create(Service service, Vehicle vehicle, List<ServiceItem> serviceItems)
        {
            service.Vehicle = vehicle;
            service.ServiceItems = serviceItems;

            db.Services.Add(service);

            db.Entry(vehicle).State = EntityState.Unchanged;
            serviceItems.ForEach(s => db.Entry(s).State = EntityState.Unchanged);
                      
            int success = db.SaveChanges();

            return success > 0;
        }

        [Obsolete("Method is deprecated, please use Create(Service service, Vehicle vehicle) instead.")]
        public override bool Create(Service t)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(int id)
        {
            Service service = db.Services.Where(s => s.Id == id).FirstOrDefault();

            db.Services.Remove(service);
            int success = db.SaveChanges();

            return success > 0;
        }

        public override void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public override List<Service> ReadAll()
        {
            return db.Services.Include("ServiceItems").Include("Vehicle").ToList();
        }

        public override Service ReadById(int id)
        {
            return db.Services.ToList().FirstOrDefault(s => s.Id == id);
        }

        public override void Restore(Service service)
        {
            throw new NotImplementedException();
        }

        public override bool Update(Service inputService)
        {
            Service service = db.Services.Where(s => s.Id == inputService.Id).FirstOrDefault();

            service.DateIssued = inputService.DateIssued;
            service.TimeIssued = inputService.TimeIssued;
            service.TotalPrice = inputService.TotalPrice;
            service.ServiceItems = inputService.ServiceItems;
            service.Vehicle = inputService.Vehicle;

            int success = db.SaveChanges();

            return success > 0;
        }
    }
}

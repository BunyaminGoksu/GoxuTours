using GoxuTour.Application.Repositories;
using GoxuTour.Domain;
using GoxuTour.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoxuTour.DataAccess
{
    public class BusManufacturerRepository : IBusManufacturerRepository
    {
        public void Create(BusManufacturer busManufacturer)
        {
            var dbContext = new GoxuTourDbContext();
            dbContext.busManufacturers.Add(busManufacturer);
            dbContext.SaveChanges();       
        }

        public void Delete(BusManufacturer busManufacturer)
        {
            var dbContext = new GoxuTourDbContext();
            var busManuEntity = dbContext.busManufacturers.Find(busManufacturer.Id);
            dbContext.busManufacturers.Remove(busManuEntity);
            dbContext.SaveChanges();
        }

        public IEnumerable<BusManufacturer> GetAll()
        {
            var dbContext = new GoxuTourDbContext();
            return dbContext.busManufacturers.ToList();
        }

        public BusManufacturer GetById(int id)
        {
            var dbContext = new GoxuTourDbContext();
            return dbContext.busManufacturers.Find(id);
        }

        public void Update(BusManufacturer busManufacturer)
        {
            var dbContext = new GoxuTourDbContext();
            dbContext.busManufacturers.Update(busManufacturer);
            dbContext.SaveChanges();
        }
    }
}

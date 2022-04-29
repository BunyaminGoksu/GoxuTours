using GoxuTour.Application.Repositories;
using GoxuTour.Domain;
using GoxuTour.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoxuTour.DataAccess
{
    public class BusModelRepository : IBusModelRepository
    {
        public void Create(BusModel busModel)
        {
            var dbContext = new GoxuTourDbContext();
           dbContext.Add(busModel);
            dbContext.SaveChanges();    
        }

        public void Delete(BusModel busModel)
        {
            var dbContext = new GoxuTourDbContext();
            dbContext.busModels.Remove(busModel);
            dbContext.SaveChanges();
        }

        public IEnumerable<BusModel> GetAll()
        {
            var dbContext = new GoxuTourDbContext();
            return dbContext.busModels.ToList();
        }

        public BusModel GetById(int id)
        {
            var dbContext = new GoxuTourDbContext();
            return dbContext.busModels.Find(id);
        }

        public void Update(BusModel busModel)
        {
            var dbContext = new GoxuTourDbContext();
            dbContext.busModels.Update(busModel);
            dbContext.SaveChanges();
        }
    }
}

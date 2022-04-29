using GoxuTour.Application.Repositories;
using GoxuTour.Domain;
using GoxuTour.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoxuTour.DataAccess
{
    public class StationRepository : IStationRepository
    {
        public void Create(Station station)
        {
            var dbContext = new GoxuTourDbContext();
            dbContext.Stations.Add(station);
            dbContext.SaveChanges();
        }

        public void Delete(Station station)
        {
            var dbContext = new GoxuTourDbContext();
            dbContext.Stations.Remove(station);
            dbContext.SaveChanges();
        }

        public IEnumerable<Station> GetAll()
        {
            var dbContext = new GoxuTourDbContext();
            return dbContext.Stations.ToList();
        }

        public Station GetById(int id)
        {
           var dbContext = new GoxuTourDbContext();
          return  dbContext.Stations.Find(id);  

        }

        public void Update(Station station)
        {
            var dbContext = new GoxuTourDbContext();

            dbContext.Stations.Update(station);
            dbContext.SaveChanges();

        }
    }
}
